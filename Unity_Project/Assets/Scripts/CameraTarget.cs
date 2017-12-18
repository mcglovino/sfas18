using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

    public List<Transform> targets;

    public Vector3 offset;


    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Vector3 center = GetCenter();
        transform.position = center + offset;
    }

    Vector3 GetCenter()
    {
        //if only one then that is the center
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        //when multiple, find the center
        else
        {
            var bounds = new Bounds(targets[0].position, Vector3.zero);
            for (int i = 0; i < targets.Count; i++)
            {
                bounds.Encapsulate(targets[i].position);
            }
            return bounds.center;
        }
    }
}
