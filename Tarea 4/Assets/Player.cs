using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Camera cam;
    public Nodo[] path;
    private int curr_node;
    IEnumerator distance;
    IEnumerator secondDistance;
    private int state;
    private List<Nodo> secondPath;

    // Use this for initialization
    void Start () {
        this.curr_node = 0;
        this.distance = this.checkDistance();
        this.secondDistance = this.checkSecondDistance();
        this.StartCoroutine(this.distance);
        this.state = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.state == 1)
        {
            this.transform.LookAt(this.path[curr_node].transform);
        }
        else
        {
            if (curr_node < this.secondPath.Count)
            {
                this.transform.LookAt(this.secondPath[curr_node].transform);
            }
        }

        this.transform.Translate(0, 0, 3f * Time.deltaTime);

        if (this.state == 1 && Input.GetMouseButtonUp(0))
        {
            Ray rayito = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayito, out hit))
            {
                float min = Mathf.Infinity;
                Nodo closest = this.path[curr_node];
                for (int i = 0; i < this.path.Length; i++)
                {
                    float dist = Vector3.Distance(hit.point, this.path[i].transform.position);
                    if (dist < min)
                    {
                        min = dist;
                        closest = this.path[i];
                    }
                }
                StopCoroutine(this.distance);
                this.state = 2;
                int prev = (curr_node != 0)? curr_node - 1 :this.path.Length-1;
                Nodo start = (Vector3.Distance(this.transform.position, this.path[curr_node].transform.position) < Vector3.Distance(this.transform.position, this.path[prev].transform.position)) ? this.path[curr_node]: this.path[prev];
                this.secondPath = SearchAlgorithms.BreadthWiseSearch(start, closest);
                this.curr_node = 0;
                StartCoroutine(this.secondDistance);
            }
        }
    }

    IEnumerator checkDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (Vector3.Distance(this.transform.position, this.path[curr_node].transform.position) < .3f)
            {
                this.curr_node += 1;
                this.curr_node %= this.path.Length;
            }
        }
    }

    IEnumerator checkSecondDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (this.curr_node == this.secondPath.Count)
            {
                this.StopCoroutine(this.secondDistance);
                this.state = 1;
                for (int i = 0; i < this.path.Length; i++)
                {
                    if (this.path[i] == this.secondPath[curr_node-1])
                    {
                        this.curr_node = i+1;
                        this.curr_node %= this.path.Length;
                        break;
                    }
                }
                StartCoroutine(this.distance);
            }else if (Vector3.Distance(this.transform.position, this.secondPath[curr_node].transform.position) < .3f)
            {
                this.curr_node += 1;
            }
        }
    }
}
