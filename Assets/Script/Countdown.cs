using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Countdown : MonoBehaviour
{
    private float timeLeft = 60.0f;

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
            GameOver();
    }
    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
