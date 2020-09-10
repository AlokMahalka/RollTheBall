using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Gameagain()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}


