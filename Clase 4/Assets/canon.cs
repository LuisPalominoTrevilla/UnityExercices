using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour {

    public GameObject original;
    public Transform posicion;
    float j = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(h * Time.deltaTime * 5, 0, 0, Space.World);

        float jActual = Input.GetAxisRaw("Jump");
        if (j == 0 && jActual == 1)
        {
            // El balazo va aquí
            // Para instanciar unity necesita clonar, un objeto base
            Instantiate<GameObject>(this.original, this.posicion.position, this.original.transform.rotation);
        }
        j = jActual;
    }
}
