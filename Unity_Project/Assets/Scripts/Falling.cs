using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {
    private Rigidbody rb;
    private float mass;

    // Whether the player is alive or not
    bool isAlive = true;

    // The time it takes to respawn
    const float maxRespawnTime = 1.0f;
    float respawnTime = maxRespawnTime;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        float x = Random.Range(-8.5f, 8.5f);
        float z = Random.Range(-8.5f, 8.5f);
        float y = Random.Range(17f, 30f);
        transform.position = new Vector3(x, y, z);

        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(size, size, size);
        rb.mass *= size;
    }


    void Update()
    {
        //for smoothing the tilt
        if (!isAlive)
        {
            UpdateRespawnTime();
            rb.mass -= 0.1f;
        }
        else if ((mass > rb.mass))
        {
            rb.mass += 0.1f;
        }

        //when spawns, shoots down.
        RaycastHit hit;
        Ray Ray = new Ray(transform.position, -Vector3.up);

        if (Physics.Raycast(Ray, out hit))
        {
            if (hit.distance > 2)
            {
                transform.position += new Vector3(0, -hit.distance / 5, 0);
            }
        }

    }

    public void Die()
    {
        isAlive = false;
        respawnTime = maxRespawnTime;
        mass = rb.mass;
    }

    void UpdateRespawnTime()
    {
        respawnTime -= Time.deltaTime;
        if (respawnTime < 0.0f)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        isAlive = true;
        float x = Random.Range(-8.5f, 8.5f);
        float z = Random.Range(-8.5f, 8.5f);
        transform.position = new Vector3(x, 20, z);
        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(size, size, size);
        rb.mass *= size;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
