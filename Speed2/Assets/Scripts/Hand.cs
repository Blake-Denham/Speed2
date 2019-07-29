using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static float CurrentSpeed = 10;
    public float JumpForce;
    public float FistForce = 100;
    public float MaximumHeight = 10f;
    public float FistSpeed = 25;
    public float NormalSpeed = 10;
    [Range(1f, 3f)] public float FallMultiplier = 2f;

    private Rigidbody _rigidbody;
    private bool _canJump = true;
    private bool _fistMode = false;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        CurrentSpeed = NormalSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _fistMode = !_fistMode;
            CurrentSpeed = _fistMode ? FistSpeed : NormalSpeed;
            _rigidbody.mass = _fistMode ? 1000f : 1f;
            _animator.SetBool("isBoosting", _fistMode);
        }
    }

    void FixedUpdate()
    {
        if (_fistMode)
        {
            if (Input.GetButton("Jump") && transform.position.y < MaximumHeight)
            {
                _rigidbody.AddForce(FistForce * Vector3.up, ForceMode.Force);
            }
        }
        else
        {
            if (_canJump && Input.GetButton("Jump"))
            {
                Jump();
                
                _canJump = false;
            }

            if (_rigidbody.velocity.y < 0.05f)
            {
                _rigidbody.velocity += FallMultiplier * Time.fixedDeltaTime * Physics.gravity;
            }
        }
    }

    internal void Jump()
    {
        _animator.SetBool("isJumping", true);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }

    internal void CanJump(bool val)
    
    {
        _canJump = val;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("isJumping", false);
            CanJump(true);
        }

        if (_fistMode)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                var obstacle = other.gameObject.GetComponent<Obstacle>();
                obstacle.Explode(100f);
            }
        }
    }

    public bool FistMode()
    {
        return _fistMode;
    }
}