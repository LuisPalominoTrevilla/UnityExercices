using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    private Transform target;
	// Use this for initialization
	void Start () {
        this.target = GameObject.Find("Player").transform;
        this.transform.LookAt(target);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, 5*Time.deltaTime);
	}
}
