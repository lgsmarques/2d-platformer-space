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
    public string triggerDeath = "Death";
    public Animator animator;

    private float _currentSpeed;
    private bool _isRunning = false;
    private bool _isPlayerDead = false;

    private HealthBase _healthBase;

    private void Awake()
    {
        _healthBase = GetComponent<HealthBase>();

        if (_healthBase != null)
        {
            _healthBase.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        _healthBase.OnKill -= OnPlayerKill;
        _isPlayerDead = true;
        animator.SetTrigger(triggerDeath);
    }

    private void Update()
    {
        if (!_isPlayerDead)
        { 
            HandleJump();
            HandleMovement();
        }
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
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
