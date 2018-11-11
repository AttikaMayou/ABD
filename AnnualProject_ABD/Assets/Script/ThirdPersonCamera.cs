using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public Transform playerTransform;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public float distanceToPlayer = 5.0f;

    public float RotationSpeed = 5.0f;

    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
        transform.position = cameraOffset;
        
    }

    void LateUpdate()
    {
        
   
        Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, playerTransform.up);

         cameraOffset = camTurnAngleX * cameraOffset;

        Vector3 newPos = playerTransform.position + cameraOffset;
        newPos.y = playerTransform.position.y + 2; 

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

         transform.LookAt(playerTransform);

    }

}
