using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool _exploded;

    public float extraSpeed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_exploded)
        {
        }
        else
            transform.position += Time.fixedDeltaTime * (Hand.CurrentSpeed + extraSpeed) * Vector3.right;
    }

    public void Explode(float force)
    {
        _exploded = true;
        
        var rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.velocity = Vector3.zero;
        rb.AddForce(force * (new Vector3(-2f, 1f, Random.Range(-1f, 1f)).normalized), ForceMode.Impulse);
    }
}