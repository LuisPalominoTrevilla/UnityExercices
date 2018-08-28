using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        // Operacion costosa, hacerlo lo menos posible
        this.rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 15, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
