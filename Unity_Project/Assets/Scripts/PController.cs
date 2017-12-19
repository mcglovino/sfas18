using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour {

    private Rigidbody rb;

    float toGround;

    public int speed = 10;

    // Identifier for Input
    [SerializeField]
    public string PlayerInputString = "_P1";

    void Start () {
        rb = this.GetComponent<Rigidbody>();
        toGround = this.GetComponent<Collider>().bounds.extents.y;
	}
	

	void FixedUpdate () {
        float moveH = Input.GetAxis("Horizontal" + PlayerInputString);
        float moveV = Input.GetAxis("Vertical" + PlayerInputString);

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);

        rb.AddForce(movement * speed);

        if (Input.GetButtonDown("Jump" + PlayerInputString) && IsGrounded())
        {
            rb.AddForce(Vector3.up * 250);
        }
 
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, toGround + 1);
    }
}