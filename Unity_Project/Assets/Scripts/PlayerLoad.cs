using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoad : MonoBehaviour {

    public GameObject P1;
    public GameObject P2;
    public GameObject Camera;

	void Start () {
        if (SceneInfo.Win == 1)
        {
            P1.SetActive(true);
            Camera.GetComponent<CameraTarget>().targets.Remove(P2.transform);
        }
        else
        {
            P2.SetActive(true);
            Camera.GetComponent<CameraTarget>().targets.Remove(P1.transform);
        }
	}
	
	void Update () {
		
	}
}
