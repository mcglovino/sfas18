using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

    //list of targets instead of jus the two
    //more futureproof if more are to be added
    public List<Transform> targets;
    public Transform P2;
    public Transform grounds;

    //for move
    public Vector3 offset;
    //used by smoothdamp
    private Vector3 velocity;
    public float smoothTime = 0.6f;

    //for zoom
    public float minZ = 50f;
    public float maxZ = 30f;



    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        CameraMove();
        CameraZoom();
    }

    void CameraMove()
    {
        Vector3 center = GetCenter();
        // transform.position = center + offset;
        //smooths transition rather than just setting it to equal
        transform.position = Vector3.SmoothDamp(transform.position, (center + offset), ref velocity, smoothTime);
    }

    void CameraZoom()
    {
        float zoom = Mathf.Lerp(maxZ, minZ, GetGreatestDistance() / 5f);
        this.GetComponent<Camera>().fieldOfView = Mathf.Lerp(this.GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
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

    public void Practice()
    {
        targets.Remove(P2);
        targets.Remove(grounds);
        offset.y += 10;
        offset.z -= 10f;
    }
}
