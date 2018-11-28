using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour {

    public AttractorScript attractor;

    [SerializeField]
    private GameObject cameraRotatorX;

    private Vector3 moveDir;
    private Vector3 jumpDir;
    public float speed;

    public Rigidbody rb;

    [SerializeField]
    private float rotationSpeed = 5.0f;

    private bool isJumping = false;

    public GameObject orb;
    public GameObject orbSpawned;

    void Start ()
    {
        cameraRotatorX.transform.rotation = transform.rotation;
    }

    void FixedUpdate () {
        //Gestion des déplacements autour de la planète
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotationSpeed, 0));
        cameraRotatorX.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * rotationSpeed, 0, 0), Space.Self);

        //Gestion du saut en appliquant force plus èlevé que la gravité.
        if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            jumpDir = attractor.dirForce;
            rb.AddForce(jumpDir * 250);

        //Interdiction du saut
            isJumping = true;
        }
    }
    //Autorisation du saut
    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "planet")
        {
            isJumping = false;
        }
    }
}
