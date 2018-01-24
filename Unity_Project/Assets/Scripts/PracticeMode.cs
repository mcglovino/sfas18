using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeMode : MonoBehaviour {

    public GameObject[] notPractice;
    public GameObject camera;
    public GameObject camera2;

    void Start()
    {
        if (SceneInfo.Practice == true)
        {
            camera.GetComponent<CameraTarget>().Practice();
            camera2.GetComponent<CameraTarget>().Practice();
            for (int i = 0; i < notPractice.Length; i++)
            {
                notPractice[i].SetActive(false);
            }
        }
    }
}
