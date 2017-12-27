using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour {

    private Rigidbody rb;
    private float mass;

    float toGround;

    public float speed = 10;

    // The starting position of the player
    Vector3 spawningPosition = Vector3.zero;

    // Whether the player is alive or not
    bool isAlive = true;

    // The time it takes to respawn
    const float maxRespawnTime = 1.0f;
    float respawnTime = maxRespawnTime;

    // Identifier for Input
    [SerializeField]
    public string PlayerInputString = "_P1";

    void Start () {
        rb = this.GetComponent<Rigidbody>();
        toGround = this.GetComponent<Collider>().bounds.extents.y;

        spawningPosition = transform.position;
    }


    void Update()
    {
        //for smoothing the tilt
        if (!isAlive)
        {
            UpdateRespawnTime();
            rb.mass -= 0.05f;
            return;
        }
        if ((mass > rb.mass))
        {
            rb.mass += 0.05f;
        }

        //when spawns, shoots down.
        RaycastHit hit;
        Ray Ray = new Ray(transform.position, -Vector3.up);

        if (Physics.Raycast(Ray, out hit))
        {
            if(hit.distance > 2)
            {
                transform.position += new Vector3(0, -hit.distance / 5, 0);
            }
        }

    }

    void FixedUpdate () {

        if (IsGrounded()) {
            float moveH = Input.GetAxis("Horizontal" + PlayerInputString);
            float moveV = Input.GetAxis("Vertical" + PlayerInputString);

            Vector3 movement = new Vector3(moveH, 0.0f, moveV);

            rb.AddForce(movement * speed);
        }

        /*if (Input.GetButtonDown("Jump" + PlayerInputString) && IsGrounded())
        {
            rb.AddForce(Vector3.up * 500);
        }*/

        if (Input.GetButton("Fire1" + PlayerInputString))
        {
            if (transform.localScale.x < 1.5)
            {
                transform.localScale += new Vector3(0.075f, 0.075f, 0.075f);
                GetComponent<Rigidbody>().mass += 0.075f;
                speed += 0.3f;
            }
        }
        if (Input.GetButton("Fire2" + PlayerInputString))
        {
            if (transform.localScale.x > 0.5)
            {
                transform.localScale -= new Vector3(0.075f, 0.075f, 0.075f);
                GetComponent<Rigidbody>().mass -= 0.075f;
                speed -= 0.3f;
            }
        }


    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, toGround + 0.75f);
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
        transform.position = spawningPosition;
        //transform.position = Vector3.MoveTowards(transform.position, spawningPosition, 10000 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        //rb.mass = mass;
    }

    //whether to increase self or others score
    public int GetPlayerNum(bool self)
    {
        if (self)
        {
            if (PlayerInputString == "_P1")
            {
                return 1;
            }
            else if (PlayerInputString == "_P2")
            {
                return 2;
            }
        }
        else
        {
            if (PlayerInputString == "_P1")
            {
                return 2;
            }
            else if (PlayerInputString == "_P2")
            {
                return 1;
            }
        }

        return 0;
    }
}