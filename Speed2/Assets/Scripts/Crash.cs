using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Hand.CanJump(true);
        }
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            var obstacle = other.gameObject.GetComponent<Obstacle>();
            if (Hand.IsFistMode)
            {
                obstacle.Explode(1000f);
            }
            else
            {
                Debug.Log("GameOver");
            }
        }
    }
}
