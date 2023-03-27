using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;
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
        animator.SetTrigger(soPlayerSetup.triggerDeath);
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
        _currentSpeed = _isRunning ? soPlayerSetup.speedRun : soPlayerSetup.speed;
            

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            myRigidbody.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool(soPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            myRigidbody.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            animator.SetBool(soPlayerSetup.boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
