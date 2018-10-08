using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        this.rb = GetComponent<Rigidbody>();
        this.rb.AddForce(this.transform.forward*80, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
