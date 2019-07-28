using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockStart : MonoBehaviour
{
    public int jumpCount;
    public int pressCount;
    public GameObject carLock;
    public GameObject window;

    private Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator = window.GetComponent<Animator>();

        //Starting game
        if (jumpCount >= 3)
        {
            animator.SetBool("SlidingDown", true);

            //Start game here
        }
    }

   void OnCollisionEnter(Collision other)
   {
        if (other.gameObject.tag == "Player")
        {
            jumpCount++;
            pressCount++;
            //making lock go down
            if (pressCount >= 2)
            {
                carLock.transform.Translate(Vector3.back * 0.5f);
            }
        }
   }
}
