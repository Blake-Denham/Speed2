using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float RotationSpeed;
    public float BounceSpeed;
    public float BounceHeight;
    private Vector3 _initial;

    private void Start()
    {
        _initial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back, RotationSpeed * Time.deltaTime);
        transform.position =
            _initial + new Vector3(0, BounceHeight * (Mathf.Sin(2 * Mathf.PI * BounceSpeed * Time.time) + 1) / 2f);
    }
}