using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to destroy particles
public class Destroyer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Invoke("DestroyEffects", 0.75f);
    }
    void DestroyEffects()
    {
        Destroy(gameObject);
    }
}
