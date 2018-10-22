using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour {

    public Nodo[] vecinos;
    public List<Nodo> history;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(this.transform.position, .3f);

        Gizmos.color = Color.red;
        for (int i = 0; i < vecinos.Length; i++)
        {
            Gizmos.DrawLine(this.transform.position, vecinos[i].transform.position);
        }
    }
}
