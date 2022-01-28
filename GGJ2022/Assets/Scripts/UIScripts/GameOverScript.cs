using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void Progression()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
