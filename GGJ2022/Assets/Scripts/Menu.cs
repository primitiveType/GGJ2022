using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuParticle;
    public static bool pausedGame = false;
    public GameObject MenuUI, ButtonUI;

    private void Awake()
    {
        menuParticle.SetActive(false);
        MenuUI.SetActive(false);
        ButtonUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausedGame){
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        menuParticle.SetActive(true);
        ButtonUI.SetActive(false);
        MenuUI.SetActive(true);
    }

    void Resume()
    {
        menuParticle.SetActive(false);
        ButtonUI.SetActive(true);
        MenuUI.SetActive(false);
    }
}
