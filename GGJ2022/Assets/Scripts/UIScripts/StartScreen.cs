using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject MenuUI, OptionUI;

    public void Awake()
    {
        MenuUI.SetActive(true);
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

    public void Quit()
    {
        Application.Quit();
    }
    public void Progression()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
