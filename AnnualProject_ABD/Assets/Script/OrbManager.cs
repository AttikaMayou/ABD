using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour {

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private Transform playerTransform;

    private Vector3 Direction;

    // Use this for initialization
    void Start () {
        Direction = playerTransform.forward;
	}
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(rb.position + transform.TransformDirection(Direction) * speed * Time.deltaTime);
    }
}
