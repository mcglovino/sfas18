using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quailty : MonoBehaviour {

    public GameObject camera;
    public GameObject camera2;

    void Start () {
        QualitySettings.SetQualityLevel(SceneInfo.Quality, true);
        if (SceneInfo.Quality == 0 || SceneInfo.Quality == 1 || SceneInfo.Quality == 2)
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
