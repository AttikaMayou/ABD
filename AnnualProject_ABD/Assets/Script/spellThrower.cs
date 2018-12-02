using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellThrower : MonoBehaviour {

    private GameObject testOrb;
    private bool canThrowSpell;

	// Use this for initialization
	void Start () {
        testOrb = Resources.Load<GameObject>("testOrb");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) && canThrowSpell)
        {
            canThrowSpell = false;
            Instantiate(testOrb, transform.position + new Vector3(transform.forward.x, transform.forward.y, transform.forward.z + 3), transform.rotation);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            canThrowSpell = true;
        }
    }
}
