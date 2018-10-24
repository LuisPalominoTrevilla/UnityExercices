using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float velocity;
	// Use this for initialization
	void Start () {
        velocity = 5;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(-v*velocity*Time.deltaTime,0,h * velocity * Time.deltaTime, Space.World);
	}
}
