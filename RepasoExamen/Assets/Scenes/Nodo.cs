using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour {
    public Nodo[] neighbors;
    public List<Nodo> historial;

    public float g, h;

    public float F
    {
        get
        {
            return g + h;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, .5f);

        Gizmos.color = Color.white;
        for (int i = 0; i < neighbors.Length; i++)
        {
            Gizmos.DrawLine(transform.position, neighbors[i].transform.position);
        }
    }
}
