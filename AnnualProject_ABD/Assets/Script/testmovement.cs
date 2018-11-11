using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmovement : MonoBehaviour {

    public Rigidbody rb;
    public float speed;

	
	// Update is called once per frame
	void Update () {

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * speed * Time.deltaTime);

    }
}
