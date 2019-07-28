using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * -1f * Time.deltaTime);

        if (transform.position.x >= 9f)
        {
            transform.position = new Vector3(-10f, 0f, 0f);
            transform.Translate(Vector3.left * -12f * Time.deltaTime);
        }
    }
}
