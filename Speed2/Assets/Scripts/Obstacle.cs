using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float extraSpeed;
    private bool _exploded;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_exploded)
        {
        }
        else
            transform.position += Time.fixedDeltaTime * (Hand.CurrentSpeed+extraSpeed) * Vector3.right;
    }
    
    public void Explode(float force)
    {
        _exploded = true;
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(force * (new Vector3(-2f, 1f, Random.Range(-1f, 1f)).normalized), ForceMode.Impulse);
    }
}