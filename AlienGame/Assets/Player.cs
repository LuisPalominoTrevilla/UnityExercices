using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Animator animator;
    private SpriteRenderer sr;
    private bool canEnter;
	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
        this.sr = GetComponent<SpriteRenderer>();
        canEnter = true;
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float speed = h * 5;
        animator.SetFloat("speed", Mathf.Abs(speed));
        print(canEnter);
        if (speed < 0 && canEnter)
        {
            canEnter = false;
            this.sr.flipX = true;
        }else if (speed > 0 && !canEnter)
        {
            canEnter = true;
            this.sr.flipX = false;
        }

        transform.Translate(speed*Time.deltaTime, 0, 0);
	}
}
