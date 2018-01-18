using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoad : MonoBehaviour {

    public GameObject P1;
    public GameObject P2;
    public GameObject Camera;
    public GameObject You;

	void Start () {

        if (SceneInfo.Win == 1)
        {
            P1.SetActive(true);
            Camera.GetComponent<CameraTarget>().targets.Remove(P2.transform);
            foreach(Renderer R in You.GetComponentsInChildren<Renderer>())
            {
                R.material = P1.GetComponent<Renderer>().material;
            }
        }
        else
        {
            P2.SetActive(true);
            Camera.GetComponent<CameraTarget>().targets.Remove(P1.transform);
            foreach (Renderer R in You.GetComponentsInChildren<Renderer>())
            {
                R.material = P2.GetComponent<Renderer>().material;
            }
        }
	}
}
