using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject optionMenu;
    public GameObject camera;
    public GameObject camera2;

    public void SinglePlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void TwoPlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        if(optionMenu.activeSelf == false)
            optionMenu.SetActive(true);
        else
            optionMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Quality(int qual)
    {
        QualitySettings.SetQualityLevel(qual, true);
        if (qual == 0 || qual == 1 || qual == 2)
        {
            camera2.SetActive(true);
            camera.SetActive(false);
        }
        else
        {
            camera.SetActive(true);
            camera2.SetActive(false);
        }
    }

}
