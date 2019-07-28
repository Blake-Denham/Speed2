using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public bool paused = false;
    public GameObject window;
    public GameObject quitButton;
    public GameObject restartButton;
    public GameObject greenWindow;
    public GameObject redWindow;
    public GameObject quitWindow;

    private Animator quitButtonAnimator;
    private Animator restartButtonAnimator;
    private Animator greenWindowAnimator;
    private Animator redWindowAnimator;
    private Animator quitWindowAnimator;

    // Start is called before the first frame update
    void Start()
    {
        quitButtonAnimator = quitButton.GetComponent<Animator>(); 
        restartButtonAnimator = restartButton.GetComponent<Animator>();
        greenWindowAnimator = greenWindow.GetComponent<Animator>();
        redWindowAnimator = redWindow.GetComponent<Animator>();
        quitWindowAnimator = quitWindow.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //restart
        if (Input.GetKey(KeyCode.R))
        {
            restartButtonAnimator.SetBool("Clicked", true);
            greenWindowAnimator.SetBool("Restarting", true); 
            Invoke("RestartGame", 1.5f);
        }

        //quit
        if (Input.GetKey(KeyCode.Q))
        {
            quitButtonAnimator.SetBool("Clicked", true);
            quitWindowAnimator.SetBool("Quitting", true);
            Invoke("RestartGame", 1.5f);
        }

        if (Input.GetKey(KeyCode.LeftShift))//place holder for game over
        {
            redWindowAnimator.SetBool("Game Over", true);
            Invoke("RestartGame", 1.5f);
        }
    }

    void RestartGame()
    {
        //delayed for animations to play 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
