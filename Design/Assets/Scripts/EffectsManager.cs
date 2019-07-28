using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public GameObject powPrefab;
    public GameObject fistModePow;
    public GameObject orangePowParticles;
    public GameObject redPowParticles;
    public GameObject yellowPowParticles;
    public Transform player;
    public GameObject trailContainer;
    public GameObject blueFistModeParticles;
    public GameObject lightBlueFistModeParticles;
    public GameObject purpleFistModeParticles;

    // Update is called once per frame
    void Update()
    {
        //hitting obsitcles
        if (Input.GetKeyDown(KeyCode.B))//stand if statement for colliding with obsticles
        {
            Instantiate(powPrefab, player.position, Quaternion.identity);
            Instantiate(orangePowParticles, player.position, Quaternion.identity);
            Instantiate(redPowParticles, player.position, Quaternion.identity);
            Instantiate(yellowPowParticles, player.position, Quaternion.identity);
            //maybe some screenshake too
        }

        //hitting obsitcles in fist mode 
        if (Input.GetKeyDown(KeyCode.X))//stand if statement for colliding with obsticles
        {
            Instantiate(fistModePow, player.position, Quaternion.identity);
            Instantiate(blueFistModeParticles, player.position, Quaternion.identity);
            Instantiate(lightBlueFistModeParticles, player.position, Quaternion.identity);
            Instantiate(purpleFistModeParticles, player.position, Quaternion.identity);
        }

         //fist mode
        if (Input.GetKey(KeyCode.Z))//stand if if statement for fistmode activation
        {
            trailContainer.SetActive(true);
        }
        else
        {
            trailContainer.SetActive(false);
        }
    }
}
