using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Node[] path;
    private int curr_node;
    Animator animator;
    private bool isAlive;

	// Use this for initialization
	void Start () {
        this.curr_node = 0;
        StartCoroutine(this.followPath());
        this.animator = GetComponent<Animator>();
        this.isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.isAlive)
        {
            this.transform.LookAt(this.path[this.curr_node].transform);
            this.transform.Translate(0, 0, 2f * Time.deltaTime);
        }
        else
        {
            this.StartCoroutine(this.dissapear());
            
        }
	}

    IEnumerator followPath()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (Vector3.Distance(this.transform.position, this.path[this.curr_node].transform.position) <= .1f)
            {
                this.curr_node += 1;
                this.curr_node %= this.path.Length;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            //Destroy(this.gameObject);
            this.animator.SetTrigger("hasDied");
            this.isAlive = false;
        }
    }

    IEnumerator dissapear()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
