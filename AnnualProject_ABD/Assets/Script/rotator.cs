using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {

    public Transform tf;
    [Range(0.1f, 5f)]
    public float angle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(tf.position, Vector3.up, angle);
        transform.RotateAround(tf.position, Vector3.right, angle);
    }
}
