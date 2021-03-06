﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    [SerializeField]
    private string playerTag = "Player";
    private Vector3 cameraOffsetOriginal;
    private RaycastHit Raycast;


    [SerializeField]
    private GameObject cameraRotatorX;

    // Use this for initialization
    void Start ()
    {
        //Récupération de la position du joueur au démarrage
        Transform player = GameObject.FindGameObjectWithTag(playerTag).transform;
        //cameraOffset = Distance entre la caméra et le joueur
        cameraOffsetOriginal = player.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        //Récupération de la position du joueur à chaque frame
        Transform player = GameObject.FindGameObjectWithTag(playerTag).transform;
            transform.position = player.position;
            transform.rotation = player.rotation * cameraRotatorX.transform.rotation;
            transform.position -= transform.rotation * cameraOffsetOriginal;
        
            
        
        //Permet de tourner autour du perso

        
        
    }
}
