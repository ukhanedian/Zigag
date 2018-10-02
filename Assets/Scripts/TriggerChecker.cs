using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // This function gets automatically called by Unity whenever an object goes out or exits from the trigger
    void OnTriggerExit(Collider col) {

        // Check if this col Collider object is our ball
        if (col.gameObject.tag == "Ball") {

            // Platform fell down after sometime
            Invoke ("FallDown", 0.5f);
        }
    }

    // Forces the platform to fall down automatically
    void FallDown () {

        // Check the Use Gravity option
            // This script is attached to TriggerChecker (child) and the Rigidbody component is attached to Platform (parent)
            // So we can get the Rigidbody component in Platform by using GetComponentInParent () and check the Use Gravity
        GetComponentInParent<Rigidbody> ().useGravity = true;

        // Check the Is Kinematic property
        GetComponentInParent<Rigidbody> ().isKinematic = false;

        // Destroy the Platform (Parent GameObject)
        Destroy (transform.parent.gameObject, 2f);
    }
}
