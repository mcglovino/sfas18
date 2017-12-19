using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour {

    private Rigidbody rb;

    public int speed = 2;

    // Identifier for Input
    [SerializeField]
    public string PlayerInputString = "_P1";

    void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	

	void FixedUpdate () {
        float moveH = Input.GetAxis("Horizontal" + PlayerInputString);
        float moveV = Input.GetAxis("Vertical" + PlayerInputString);

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0,10,0);
        }
 
    }
}