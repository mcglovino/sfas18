using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

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
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
