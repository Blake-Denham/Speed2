using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            var hand = other.gameObject.GetComponentInParent<Hand>();
            if (!hand.FistMode())
            {
                Debug.Log("Jumping");
                hand.Jump();
            }
        }
    }
}