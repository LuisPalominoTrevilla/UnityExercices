using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladrillo : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        this.rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.E))
        {
            rb.AddExplosionForce(1000, Vector3.zero, 100);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {   
        if(collision.gameObject.layer == 10)
        {
            // Explosion
            rb.AddExplosionForce(5000, collision.contacts[0].point, 10);
            print("EXPLOSION");
        }
    }
}
