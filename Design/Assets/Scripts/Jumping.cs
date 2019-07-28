using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script just to test start prototype
public class Jumping : MonoBehaviour
{
    public float jumpForce = 1f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
