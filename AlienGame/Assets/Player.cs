using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Animator animator;
    private SpriteRenderer sr;
    private bool canEnter;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
        this.sr = GetComponent<SpriteRenderer>();
        this.rb = GetComponent<Rigidbody2D>();
        canEnter = true;
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float speed = h * 5;
        animator.SetFloat("speed", Mathf.Abs(speed));
        
        if (speed < 0 && canEnter)
        {
            canEnter = false;
            this.sr.flipX = true;
        }else if (speed > 0 && !canEnter)
        {
            canEnter = true;
            this.sr.flipX = false;
        }
        print(this.animator.GetBool("gun1"));
        if (Input.GetKeyDown(KeyCode.B) && !this.animator.GetBool("gun1"))
        {
            this.animator.SetBool("gun1", true);
        }
        else
        {
            this.animator.SetBool("gun1", false);
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.rb.AddForce(transform.up*10, ForceMode2D.Impulse);
        }
        transform.Translate(speed*Time.deltaTime, 0, 0);
	}
}
