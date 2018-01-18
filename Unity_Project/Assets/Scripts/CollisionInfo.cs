using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInfo : MonoBehaviour {

    private void OnCollisionEnter(Collision other)
    {
        transform.parent.gameObject.GetComponent<Tilt>().OnCollisionEnterChild(other);
    }

    private void OnCollisionExit(Collision other)
    {
        transform.parent.gameObject.GetComponent<Tilt>().OnCollisionExitChild(other);
    }
}