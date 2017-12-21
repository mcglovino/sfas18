using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tilt : MonoBehaviour
{    
    public static List<Collision> Colliders;

    public float AngleLimit = 15.0f;
    public float AreaSize = 10.0f;

    void Start()
    {
        Colliders = new List<Collision>();
    }

    void FixedUpdate()
    {
        int count = 0;
        float Xsum = 0, Zsum = 0, Xave = 0, Zave = 0, Xrot = 0, Zrot = 0;

        if (Colliders.Count != 0)
        {
            foreach (Collision col in Colliders)
            {
                count++;
                Xsum += col.transform.position.x;
                Zsum += col.transform.position.z;
            }
            
            //Finds the average of all the colliders
            Xave = Xsum/count;
            Zave = Zsum / count;
        
            //Changes range from size of area to the amount off angles i want to rotate
            Xrot = Xave * AngleLimit / AreaSize;
            Zrot = Zave * AngleLimit / AreaSize;
        
            //Rotates by the angles
            transform.eulerAngles = new Vector3(Zrot, 0, -Xrot);
        }
    }

    //gets collision info from children
    public void OnCollisionEnterChild(Collision other)
    {
        //adds objects to list of collisions
        //only if it isnt already there
        bool same = false;
        foreach (Collision col in Colliders)
        {
            if (other.gameObject == col.gameObject)
            {
                same = true;
            }
        }
        if (same == false)
        {
            Colliders.Add(other);
        }
    }
}
