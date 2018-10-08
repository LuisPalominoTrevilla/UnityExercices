using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Node[] neighbors;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.blue;
        Gizmos.DrawSphere(transform.position, .2f);

        for (int i = 0; i < this.neighbors.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, this.neighbors[i].transform.position);
        }
    }
}
