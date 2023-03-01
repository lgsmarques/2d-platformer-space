using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Movement")]
    public float speed = 10f;
    public float speedRun = 20f;
    public float forceJump = 20f;
    public Vector2 friction = new Vector2(.1f, 0);

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
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
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
}
