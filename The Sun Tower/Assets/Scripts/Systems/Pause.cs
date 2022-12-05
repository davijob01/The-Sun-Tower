using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) pause();
            
            else unpause();
        }
    }

    void pause()
    {
        isPaused = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void unpause()
    {
        isPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
