using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour {

    public GameObject[] grounds;

	void Start () {
		for (int i =0; i < grounds.Length; i++)
        {
            if (i == SceneInfo.Level)
                grounds[i].SetActive(true);
            else
                grounds[i].SetActive(false);
        }
	}
}
