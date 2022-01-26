using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuParticle;
    public bool isFullScreen = false;
    public static bool pausedGame = false;
    public GameObject MenuUI, ButtonUI;
    public AudioMixer audio; 

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
    public void SetVolume (float volume)
    {
        audio.SetFloat("volume", volume);
    }
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void Pause()
    {
        menuParticle.SetActive(true);
        ButtonUI.SetActive(false);
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        menuParticle.SetActive(false);
        ButtonUI.SetActive(true);
        MenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene("NewRoomScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
