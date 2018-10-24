using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private Nodo start;
    private Nodo end;
    public List<Nodo> path;
    private GameObject player;
    private int curr_node;
    IEnumerator distance;
    IEnumerator states;
    IEnumerator attack;
    public int state;

    public GameObject bullet;
    public Transform gun;

	// Use this for initialization
	void Start () {
        this.start = GameObject.Find("Spawn").GetComponent<Nodo>();
        this.end = GameObject.Find("NodeManager").GetComponent<NodeManager>().Selected;
        this.player = GameObject.Find("player");
        this.path = PathFinding.BreadthWiseSearch(start, end);
        this.curr_node = 0;
        this.state = 1;

        this.distance = this.checkDistance();
        this.states = this.checkState();
        this.attack = this.startAttacking();

        StartCoroutine(distance);
        StartCoroutine(states);
	}
	
	// Update is called once per frame
	void Update () {
        if (state == 1 && curr_node < path.Count){
            transform.LookAt(path[curr_node].transform);
            transform.Translate(0, 0, 3 * Time.deltaTime);
        }else if (state == 2){
            transform.LookAt(player.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
	}

    IEnumerator checkDistance(){
        while(true){
            yield return new WaitForSeconds(.3f);
            if (Vector3.Distance(transform.position, path[curr_node].transform.position) < .3f){
                if (curr_node + 1 == path.Count)
                {
                    StopCoroutine(this.distance);
                }
                curr_node += 1;
            }
        }
    }

    IEnumerator checkState(){
        while(true){
            yield return new WaitForSeconds(.3f);
            if (state == 1 && Vector3.Distance(transform.position, player.transform.position) <= 4) {
                state = 2;
                StopCoroutine(this.distance);
                StartCoroutine(this.attack);
            }else if (state == 2 && Vector3.Distance(transform.position, player.transform.position) > 4){
                state = 1;
                StopCoroutine(this.attack);
                if (curr_node < path.Count){
                    StartCoroutine(this.distance);
                }
            }
        }
    }

    IEnumerator startAttacking(){
        while(true){
            transform.LookAt(player.transform);
            Instantiate<GameObject>(bullet, gun.transform.position, gun.rotation);
            yield return new WaitForSeconds(1);
        }
    }


}
