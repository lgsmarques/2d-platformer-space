using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Movement")]
    public float speed = 10f;
    public float speedRun = 20f;
    public float forceJump = 20f;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("Animation")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;
    public string boolRun = "Run";
    public Animator animator;

    private float _currentSpeed;
    private bool _isRunning = false;   

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        _isRunning = Input.GetKey(KeyCode.LeftControl);
        _currentSpeed = _isRunning ? speedRun : speed;
            

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            myRigidbody.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            myRigidbody.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidbody.velocity = Vector2.up * forceJump;
            //myRigidbody.transform.localScale = Vector2.one;

            //DOTween.Kill(myRigidbody.transform);
            //HandleScaleJump();
        }
    }

    //private void HandleScaleJump()
    //{
    //    myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    //    myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    //}
}
