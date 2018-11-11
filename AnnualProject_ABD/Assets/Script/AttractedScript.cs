using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractedScript : MonoBehaviour {

    public AttractorScript attractor;
    private Transform myTranform;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTranform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        attractor.Attractor(myTranform);
	}
}
