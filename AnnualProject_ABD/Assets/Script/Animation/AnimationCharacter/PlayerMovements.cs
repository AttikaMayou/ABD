using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Tooltip("Player")]
    private CharacterController Character;

    [SerializeField]
    [Tooltip("Vitesse de la marche")]
    private float moveSpeed=3f;

    [SerializeField]
    [Tooltip("Vitesse de la course")]
    private float runSpeed;

    [SerializeField]
    [Tooltip("Vitesse de la course")]
    private float WalkSpeed;

    private Animator anim;
    private bool IsWalking;
    private bool IsRunning;


    // Deux floats pour faire avancer : Horizontal = walk devant derriere / Vertical = walk gauche droite
    private float Forward;
    private float Strafe;


    // Use this for initialization
    void Start()
    {
        Character = GetComponent<CharacterController>();
        WalkSpeed = moveSpeed * 100;
        runSpeed = runSpeed * 100;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Récupération des floats vertical et horizontal de l'animator au script
        Forward = Input.GetAxis("Vertical");
        Strafe = Input.GetAxis("Horizontal");

        var movement = new Vector3(Strafe, 0, Forward);

        //Running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Forward!=0)
            {
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsWalking", false);
                moveSpeed = runSpeed;
            }
        }
        else
        {
            //Walking
            if(Forward!=0)
            {
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsWalking", true);
                moveSpeed = WalkSpeed;
            }
            //Iddle
            if(Forward==0)
            {
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsWalking", false);
                moveSpeed = 0;
            }
        }

        //* delta time pour que tous les joueurs est le même speed
        Character.SimpleMove(movement * Time.deltaTime * moveSpeed);
        anim.SetFloat("Forward", movement.magnitude);

           

    }



}

