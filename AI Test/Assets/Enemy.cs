using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform player;
    private Animator animator;
    public Transform[] path;
    private int curr_node;
    private Transform curr_target;
    private IEnumerator walk;
    private bool isOnPath;
    private Vector3 nodeDirection;

    // Use this for initialization
    void Start () {
        this.animator = GetComponent<Animator>();
        this.curr_node = 0;
        this.walk = this.turn_around();
        this.nodeDirection = this.path[curr_node].position - this.transform.position;
        StartCoroutine(this.walk);
        this.isOnPath = true;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerDirection = this.player.position - this.transform.position;
        // Calculate angle of field of view
        float angle = Vector3.Angle(playerDirection, this.transform.forward);
        if (playerDirection.magnitude < 15 && angle < 45)
        {
            if (this.isOnPath)
            {
                this.isOnPath = false;
                StopCoroutine(this.walk);
            }

            playerDirection.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(playerDirection), .1f);
            this.animator.SetBool("isWalking", false);
            if (playerDirection.magnitude > 3)
            {
                this.animator.SetBool("isAttacking", false);
                this.animator.SetBool("isChasing", true);
                if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    this.transform.Translate(0, 0, 6 * Time.deltaTime);
                }
            }
            else
            {
                // Start attacking animation
                this.animator.SetBool("isChasing", false);
                this.animator.SetBool("isAttacking", true);
            }
        }
        else
        {
            if (!this.isOnPath)
            {
                this.isOnPath = true;
                StartCoroutine(this.walk);
            }
            
            // Follow path
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(nodeDirection), .1f);
            this.transform.Translate(0, 0, 2*Time.deltaTime);
            this.animator.SetBool("isWalking", true);
            this.animator.SetBool("isChasing", false);
            this.animator.SetBool("isAttacking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
    }

    IEnumerator turn_around()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            this.nodeDirection = this.path[curr_node].position - this.transform.position;
            if (Vector3.Distance(this.transform.position, this.path[this.curr_node].position) < .3f)
            {
                // Enemy is too close, change to next element
                this.curr_node += 1;
                this.curr_node %= this.path.Length;
            }
        }
    }

}
