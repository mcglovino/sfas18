using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeMode : MonoBehaviour {

    public GameObject[] notPractice;
    public GameObject camera;

    void Start()
    {
        if (SceneInfo.Practice == true)
        {
            for (int i = 0; i < notPractice.Length; i++)
            {
                notPractice[i].SetActive(false);
                camera.GetComponent<CameraTarget>().Practice();
            }
        }
    }
}
