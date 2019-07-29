using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float vertOffset = -2f;
    public float vertOffset1 = -2f;
    public float distMultiplier = 2f;
    public static float CurrentSpeed = 10;
    public float jumpForce;
    public float fistSpeed = 25;
    public float normalSpeed = 10;
    public GameObject closeBegin, closeEnd;
    public GameObject farBegin, farEnd;
    private static Hand instance;
    public static bool IsFistMode { get; private set; }
    [Range(1f, 3f)] public float fallMultiplier = 2f;

    private Rigidbody _rigidbody;
    private bool _canJump = true;
    private bool _fistMode = false;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        CurrentSpeed = normalSpeed;
        instance = this;
    }

    private void Update()
    {
        var position3 = farBegin.transform.position;
        var temp = position3;
        var position1 = closeBegin.transform.position;
        position3 = new Vector3(temp.x, position1.y*distMultiplier + vertOffset, temp.z);
        farBegin.transform.position = position3;
        var position2 = farEnd.transform.position;
        temp = position2;
        var position = closeEnd.transform.position;
        position2 = new Vector3(temp.x, position.y * distMultiplier + vertOffset1, temp.z);
        farEnd.transform.position = position2;


        var diff1 = (position - position1);
        var diff2 = (position2 - position3);

        for (int i = 0; i < 25; i++)
        {
            RaycastHit hit;
            var s = closeBegin.transform.position + diff1 * i / 24;
            var e = farBegin.transform.position + diff2 * i / 24;
            var diff = e - s;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(s, diff
                , out hit,
                diff.magnitude))
            {

                if (hit.collider.gameObject.CompareTag("ground"))
                {
                    _rigidbody.velocity = Vector3.zero;
                    CanJump(true);
                }
                Debug.DrawRay(s, (e - s).normalized * hit.distance,
                    Color.yellow);
            }
            else
            {
                Debug.DrawRay(s, e - s, Color.white);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _fistMode = !_fistMode;
            IsFistMode = _fistMode;
            CurrentSpeed = _fistMode ? fistSpeed : normalSpeed;
            _rigidbody.mass = _fistMode ? 1000f : 1f;
            _animator.SetBool("isBoosting", _fistMode);
        }
    }

    void FixedUpdate()
    {
        if (_fistMode)
        {
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
                _rigidbody.velocity += fallMultiplier * Time.fixedDeltaTime * Physics.gravity;
            }
        }

        /*var max = far.transform.position;
        if (middle.transform.position.y > max.y)
        {
            max = middle.transform.position;
        }

        var position = transform.position;
        position = new Vector3(position.x, Mathf.Lerp(position.y, (max.y-vertOffset)/2f, 0.15f), position.z);
        transform.position = position;*/
    }

    internal void Jump()
    {
        _rigidbody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        _animator.SetBool("isJumping", true);
    }

    internal static void CanJump(bool val)
    {
        instance._canJump = val;
        instance._animator.SetBool("isJumping", !val);
    }

    public bool FistMode()
    {
        return _fistMode;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            CanJump(true);
        }
    }
}