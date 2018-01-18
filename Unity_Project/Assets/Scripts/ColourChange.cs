using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColourChange : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Renderer>().material = this.gameObject.GetComponent<Renderer>().material;
        if (collision.gameObject.GetComponent<PController>().PlayerInputString == "_P1")
        {
            SceneInfo.Material_P1 = this.gameObject.GetComponent<Renderer>().material;
        }
        else if (collision.gameObject.GetComponent<PController>().PlayerInputString == "_P2")
        {
            SceneInfo.Material_P2 = this.gameObject.GetComponent<Renderer>().material;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(2);
        }
    }
}
