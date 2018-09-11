using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, 10*Time.deltaTime);
	}
}
