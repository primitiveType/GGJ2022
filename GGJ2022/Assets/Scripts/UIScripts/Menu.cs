using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Timer time;
    public GameObject menuParticle;
    public static bool pausedGame = false;
    public GameObject MenuUI, ButtonUI, OptionUI;
    public AudioSource audioSource;
    private void Awake()
    {
        
        menuParticle.SetActive(false);
        MenuUI.SetActive(false);
        ButtonUI.SetActive(true);
        OptionUI.SetActive(false);
    
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
                time.StopTimer();
                Pause();
            }
        }
    }

    //Pause Menu controls
    public void Pause()
    {
        audioSource.Stop();
        time.StopTimer();
        menuParticle.SetActive(true);
        ButtonUI.SetActive(false);
        MenuUI.SetActive(true);
        OptionUI.SetActive(false);

    }
    public void Resume()
    {
        audioSource.Play();
        time.StartTimer();
        menuParticle.SetActive(false);
        ButtonUI.SetActive(true);
        MenuUI.SetActive(false);
        OptionUI.SetActive(false);

    }
    public void OptionsMenu()
    {
        MenuUI.SetActive(false);
        OptionUI.SetActive(true);
    }
    public void BackButton()
    {

        MenuUI.SetActive(true);
        OptionUI.SetActive(false);
    }

    //SceneController
    public void Quit()
    {
        Application.Quit();
    }
    public void Progression()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
}
