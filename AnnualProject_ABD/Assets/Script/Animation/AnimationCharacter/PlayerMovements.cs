using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Tooltip("Player")]
    private CharacterController Character;

    private float moveSpeed=3f;

    [SerializeField]
    [Tooltip("Vitesse de la course")]
    private float runSpeed;

    [SerializeField]
    [Tooltip("Vitesse de la marche")]
    private float WalkSpeed;

    [SerializeField]
    [Tooltip("Gravité")]
    public float gravity = 20.0F;

    [SerializeField]
    [Tooltip("Vitesse du saut")]
    public float JumpSpeed;

    private Animator anim;
    private bool IsWalking;
    private bool IsRunning;
    private bool IsJumping;
    int jumpHash = Animator.StringToHash("Jump");
    private Vector3 movement = Vector3.zero;

    //CAMERA
    [SerializeField]
    private GameObject cameraRotatorX;

    // Deux floats pour faire avancer : Horizontal = walk devant derriere / Vertical = walk gauche droite
    private float Forward;
    private float Strafe;

    //CAMERA
    private float rotationSpeed=3;


    // Use this for initialization
    void Start()
    {
        Character = GetComponent<CharacterController>();
        WalkSpeed = moveSpeed * 1;
        runSpeed = runSpeed * 1;
        anim = GetComponentInChildren<Animator>();
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //CAMERA
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotationSpeed, 0));
        cameraRotatorX.transform.Rotate(new Vector3(-(Input.GetAxis("Mouse Y") * rotationSpeed), 0, 0), Space.Self);

        // Récupération des floats vertical et horizontal de l'animator au script
        Forward = Input.GetAxis("Vertical");
        Strafe = Input.GetAxis("Horizontal");

        if (Character.isGrounded)
        {
            movement = new Vector3(Strafe, 0.0f, Forward);
            movement = transform.TransformDirection(movement);
            movement = movement * moveSpeed;
            anim.SetFloat("Forward", Forward);

            //Running
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Forward != 0)
                {
                    anim.SetBool("IsRunning", true);
                    anim.SetBool("IsWalking", false);
                    moveSpeed = runSpeed;

                    //jump from Running
                    if (Input.GetKey(KeyCode.Space))
                    {
                        movement.y = JumpSpeed;
                        anim.SetBool("IsJumping", true);

                        Debug.Log("SAUT");
                    }
                    else
                    {
                        anim.SetBool("IsJumping", false);
                    }
                }
            }
            else
            {
                //Walking
                if (Forward != 0)
                {
                    anim.SetBool("IsRunning", false);
                    anim.SetBool("IsWalking", true);
                    moveSpeed = WalkSpeed;

                    //jump from Walking
                    if (Input.GetKey(KeyCode.Space))
                    {
                        movement.y = JumpSpeed;
                        anim.SetBool("IsJumping", true);
                    }
                    else
                    {
                        anim.SetBool("IsJumping", false);
                    }
                }
                //Iddle
                if (Forward == 0)
                {
                    anim.SetBool("IsRunning", false);
                    anim.SetBool("IsWalking", false);
                    moveSpeed = 0;
                    //Crouch from Iddle
                    if(Input.GetKey(KeyCode.LeftControl))
                    {
                        

                    }
                        //jump from Iddle
                        if (Input.GetKey(KeyCode.Space))
                    {
                        movement.y = JumpSpeed;
                        anim.SetBool("IsJumping", true);
                        Debug.Log("SAUT");
                    }
                    else
                    {
                        anim.SetBool("IsJumping", false);
                    }
                }
            }

            
        }
  
        movement.y = movement.y - (gravity * Time.deltaTime);
        Character.Move(movement * Time.deltaTime);
    }

}

