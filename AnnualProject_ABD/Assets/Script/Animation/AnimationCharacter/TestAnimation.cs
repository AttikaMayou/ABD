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
    
    // Deux floats pour faire avancer : Horizontal = walk devant derriere / Vertical = walk gauche droite
    private float animVertical;
    private float animHorizontal;


    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Récupération des floats vertical et horizontal de l'animator au script
        animHorizontal = Input.GetAxis("Horizontal");
        animVertical = Input.GetAxis("Vertical");
        anim.SetFloat("animVertical", animVertical);
        anim.SetFloat("animHorizontal", animHorizontal);



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
        }
        //droite
        if (Input.GetKey(KeyCode.D))
        {
            targetTransform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
        //se baisser ++


        //sauter

    }
}
