using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator startFadeAnimator;
    public GameObject startFade;

    public GameObject mainMenu;
    public GameObject controlsMenu;

    public void StartButton()
    {
        startFade.SetActive(true);
        startFadeAnimator.SetTrigger("fade");
    }

    public void controlsButton()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void returnButton()
    {
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void exitButton()
    {
        Application.Quit();
    }
}
