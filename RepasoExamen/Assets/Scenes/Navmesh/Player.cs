using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    private NavMeshAgent agent;
    public Camera cam;

	// Use this for initialization
	void Start () {
        this.agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0))
        {
            Ray rayito = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayito, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
	}
}
