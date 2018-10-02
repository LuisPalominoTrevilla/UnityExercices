using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Mouse se mueve en un espacio 2D
        // Juego existe en un espacio 3D
        // Cómo hacemos para interactuar entre espacios????!
        
        // raycast - lanzar un rayo y ver con qué choca

        if (Input.GetMouseButtonUp(0))
        {
            Ray rayitito = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(rayitito, out hit))
            {
                print(hit.transform.name);
            }
        }
	}
}
