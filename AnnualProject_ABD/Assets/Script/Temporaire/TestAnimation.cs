using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour {

    [SerializeField]
    [Tooltip("Player")]
    private Transform targetTransform;

    [SerializeField]
    [Tooltip("Vitesse du personnage")]
    private float moveSpeed;

    [SerializeField]
    [Tooltip("Animator du personnage")]
    private Animator anim;

    private bool IsWalking=false;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //reculer
        if (Input.GetKey(KeyCode.S))
        {
            targetTransform.position += Vector3.back * Time.deltaTime * moveSpeed;
        }
        //avancer
        if (Input.GetKey(KeyCode.Z))
        {
            targetTransform.position += Vector3.forward * Time.deltaTime * moveSpeed;
            anim.Play("Walking", -1, 0f);
        }
        //gauche
        if (Input.GetKey(KeyCode.Q))
        {
            targetTransform.position += Vector3.left * Time.deltaTime * moveSpeed;
            IsWalking = true;
        }
        //droite
        if (Input.GetKey(KeyCode.D))
        {
            targetTransform.position += Vector3.right * Time.deltaTime * moveSpeed;
            IsWalking = true;
        }
        //se baisser ++


        //sauter
    }
}
