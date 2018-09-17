using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour {

    public GameObject[] vecinos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, .3f);

        for(int i = 0; i < this.vecinos.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, this.vecinos[i].transform.position);
        }
    }
}
