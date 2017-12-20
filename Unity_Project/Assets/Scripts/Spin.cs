using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public int speed = 3;

    bool isActive = true;

    public float MAX_RESPAWN_TIME = 2.0f;
    float RespawnTime;

    public float hoverHeight = 1f;

    Vector3 SpawningPosition;

    public delegate void PlayerCollect(int playerNum);
    public static event PlayerCollect OnCollect;

    void Start()
    {
        SpawningPosition = transform.position;
        RespawnTime = MAX_RESPAWN_TIME;
    }

    void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * (10 * speed), Space.World);

        if (!isActive)
        {
            UpdateRespawnTime();
        }

        //keeps cubes at same height
        RaycastHit hit;
        Ray Ray = new Ray(transform.position, -Vector3.up);

        if (Physics.Raycast(Ray, out hit))
        {
            float hoverError = hoverHeight - hit.distance;
            transform.position += new Vector3(0, hoverError, 0);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController)
            {
                // Increase the score for player
                if (OnCollect != null)
                {
                    OnCollect(playerController.GetPlayerNum(true));
                }
            }
        }

        isActive = false;
        this.gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
        RespawnTime = MAX_RESPAWN_TIME;
    }

    void UpdateRespawnTime() {
        RespawnTime -= Time.deltaTime;
        if (RespawnTime < 0.0f && !isActive)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        isActive = true;
        this.gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.GetComponent<Collider>().enabled = true;
        transform.position = SpawningPosition;
        transform.rotation = new Quaternion(45, 45, 45, 0);
    }
}
