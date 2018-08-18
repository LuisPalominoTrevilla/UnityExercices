using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    public float delta = 6f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    public int movement;
    public int direction;

    private Vector3 startPos;
    private Vector3 v;

    private static readonly System.Random random = new System.Random();
    private static readonly object syncLock = new object();

    // Use this for initialization
    void Start () {
        lock(syncLock)
        {
            this.speed = random.Next(2, 5);
            this.movement = random.Next(0, 3);
            this.direction = (random.Next(0, 2) == 0)? -1: 1;
        }
        
        print(this.direction);
        this.startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        v = this.startPos;
        if (this.movement == 1)
        {
            v.x += this.direction * delta * Mathf.Sin(Time.time * speed);
        }else if (this.movement == 2)
        {
            v.z += delta * Mathf.Sin(Time.time * speed);
            v.x += Mathf.Sin(Time.time * (delta/4)) * 10;
        }
        else
        {
            v.x += delta * Mathf.Sin(Time.time * speed);
            v.z += Mathf.Sin(Time.time * (delta/4)) * 10;

        }
        transform.position = v;
    }
}
