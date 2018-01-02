﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tilt : MonoBehaviour
{    
    public static List<GameObject> Colliders;
    public GameObject[] fallings;

    public float AngleLimit = 15.0f;
    public float AreaSize = 10.0f;


    void Start()
    {
        Colliders = new List<GameObject>();

        fallings = GameObject.FindGameObjectsWithTag("Falling");
        foreach (GameObject obj in fallings)
        {
            Colliders.Add(obj.gameObject);
        }
    }

    void FixedUpdate()
    {
        int count = 0;
        float Xsum = 0, Zsum = 0, Xave = 0, Zave = 0, Xrot = 0, Zrot = 0;

        if (Colliders.Count != 0)
        {
            foreach (GameObject col in Colliders)
            {
                count++;
                Xsum += col.transform.position.x * (col.GetComponent<Rigidbody>().mass / 2);
                Zsum += col.transform.position.z * (col.GetComponent<Rigidbody>().mass / 2);
            }

            //Finds the average of all the colliders
            Xave = Xsum / count;
            Zave = Zsum / count;

            //Changes range from size of area to the amount off angles i want to rotate
            Xrot = Xave * AngleLimit / AreaSize;
            Zrot = Zave * AngleLimit / AreaSize;


            //Rotates by the angles
            Vector3 NewEuler = new Vector3(Zrot, 0, -Xrot);
            transform.eulerAngles = NewEuler;
        }
    }

    //gets collision info from children
    public void OnCollisionEnterChild(Collision other)
    {
        //adds objects to list of collisions
        //only if it isnt already there
        bool same = false;
        foreach (GameObject col in Colliders)
        {
            if (other.gameObject == col)
            {
                same = true;
            }
        }
        if (same == false)
        {
            Colliders.Add(other.gameObject);
        }
    }
}
