using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        this.rb = GetComponent<Rigidbody>();
        this.rb.AddForce(transform.up * 50, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "tank" && collision.gameObject.name != "tank2" && collision.gameObject.name != "GeneralFloor")
        {
            Destroy(collision.gameObject);
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.gameObject);
    }
}
