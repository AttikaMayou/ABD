using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour {

    public AttractorScript attractor;
    private Vector3 moveDir;
    private Vector3 jumpDir;
    public float speed;
    public Rigidbody rb;
    private bool isJumping = false;
    public GameObject orb;
    public GameObject orbSpawned;

    void Start()
    {
        orbSpawned = Instantiate(orb, transform);
        orbSpawned.transform.position = transform.position + new Vector3(3, 0);
    }

    // Use this for initialization
    void Update () {
        orbSpawned.transform.RotateAround(transform.position, Vector3.up,40 * Time.deltaTime);
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            jumpDir = attractor.dirForce;
            rb.AddForce(jumpDir * 250);
            isJumping = true;
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "floor")
        {
            isJumping = false;
        }
    }
}
