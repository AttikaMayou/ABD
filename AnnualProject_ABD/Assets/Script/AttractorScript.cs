using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractorScript : MonoBehaviour {

    public float Gravity = -10;
    public float speedRotation = 10;
    public Vector3 dirForce;

	public void Attractor(Transform body)
    {
        //Donne la direction de la gravité
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * Gravity);

        //Permet de replacer l'axe vertical du perso sur l'axe de la gravité
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, speedRotation * Time.deltaTime);

        dirForce = gravityUp;
    }
}
