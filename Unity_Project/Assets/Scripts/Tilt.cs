using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tilt : MonoBehaviour
{    
    public static List<GameObject> Colliders;
    public GameObject[] players;

    public float AngleLimit = 15.0f;
    public float AreaSize = 10.0f;

    public float smooth = 0.1f;


    void Start()
    {
        Colliders = new List<GameObject>();

        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in players)
        {
            Colliders.Add(obj.gameObject);
        }

        //Makes a mesh that is the same as all children
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.GetComponent<MeshCollider>().sharedMesh = new Mesh();
        transform.GetComponent<MeshCollider>().sharedMesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);
    }

    float Smooth(float num, float num2)
    {
        if (num2 < num)
        {
            num2 += smooth;
        }
        else if (num2 > num) {
            num2 -= smooth;
        }
        return num2;
    }

    float Xrot2, Zrot2;

    void FixedUpdate()
    {
        int count = 0;
        float Xsum = 0, Zsum = 0, Xave = 0, Zave = 0, Xrot = 0, Zrot = 0;

        if (Colliders.Count != 0)
        {
            foreach (GameObject col in Colliders)
            {
                count++;
                Xsum += col.transform.position.x * (col.GetComponent<Rigidbody>().mass / 1.5f);
                Zsum += col.transform.position.z * (col.GetComponent<Rigidbody>().mass / 1.5f);
            }

            //Finds the average of all the colliders
            Xave = Xsum / count;
            Zave = Zsum / count;

            //Changes range from size of area to the amount off angles i want to rotate
            Xrot = Xave * AngleLimit / AreaSize;
            Zrot = Zave * AngleLimit / AreaSize;

            Xrot2 = Smooth(Xrot, Xrot2);
            Zrot2 = Smooth(Zrot, Zrot2);

            //Rotates by the angles
            Vector3 NewEuler = new Vector3(Zrot2, 0, -Xrot2);
            transform.eulerAngles = NewEuler;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (Colliders.Count == 0)
        {
            Colliders.Add(other.gameObject);
        }
        else
        {
            //adds objects to list of collisions
            //only if it isnt already there
            bool same = false;
            foreach (GameObject col in Colliders)
            {
                if (other.gameObject != col)
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
    public void OnCollisionExit(Collision other)
    {
        //removes objects from the list of collisions
        foreach (GameObject col in Colliders)
        {
            if (other.gameObject == col)
            {
                //col.gameObject.GetComponent<Rigidbody>().mass = 0;
                Colliders.Remove(col.gameObject);
                break;
            }
        }
    }
}
