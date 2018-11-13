using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_control : MonoBehaviour
{   
        public Animator anim;
        public float speed = 0;
        float rotationSpeed = 80;

// Use this for initialization
void Start()
{
    anim = this.gameObject.GetComponent<Animator>();
}

// Update is called once per frame
void Update()
{
    // Character avance 
    float translation = Input.GetAxis("Vertical")*speed;
    float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }



}
}
