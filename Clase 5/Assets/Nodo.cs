using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour {

    public Nodo[] vecinos;
    public List<Nodo> historial;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 2 métodos / eventos
    // gizmos - íconos y gráficos que sirven de comunicación con developer
    // NO salen en el juego, solo en editor

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1);

        if( vecinos != null && vecinos.Length > 0)
        {
            for (int i = 0; i < vecinos.Length; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, vecinos[i].transform.position);
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
