using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {

    // atributos en Unity
    // sirven para parámetros del editor
    public float velocidad;
    public Text textito;

    // Ciclo de vida
    // ~ eventos que se acoplan a puntos específicos en la vida de un script


	// Use this for initialization
	void Start () {
        // ejecuta al inicio de la vida de un objeto
	}
	
	// Update is called once per frame
    // cuántas veces corre update por segundo?
    // R: todos los que se puedan
	void Update () {
        // ejecuta cada cuadro del juego

        // axes 
        // Rangos: [-1, 1]
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Obtener posicion del gameobject
        //print(gameObject.transform.position);

        // nuevo problema de física
        // tiempo transcurrido entre el frame anterior y este
        // Time.deltaTime
        transform.Translate(h * this.velocidad * Time.deltaTime, 
            v * this.velocidad * Time.deltaTime, 
            0,
            Space.World);
        
	}

    // elementos necesarios para colisionar
    // - los dos objetos en cuestión tienen collider
    // - el objeto que se mueve tiene rigidbody
    // Poner rigidbody en los dos solo cuando queramos que haya una reacción física

    void OnCollisionEnter(Collision collision)
    {
        // momento justo en que las geometrías de los colliders se tocan
        print("contacto: " + collision.contacts[0].point);
        print("colisiono con: " + collision.transform.name);
        //Destroy(collision.gameObject);
        
    }

    void OnCollisionStay(Collision collision)
    {
        // todo el tiempo que las geometrías de los colliders se siguen tocando
        // después de OnCollissionEnter
        
    }

    void OnCollisionExit(Collision collision)
    {
        // el instante en el que las geometrías se separan de los colliders
        print("exit");
    }

    void OnTriggerEnter(Collider other)
    {
        print("t: Enter");
        this.textito.text = "Hubo colisión!";
        //print(other.transform.name);
    }

    void OnTriggerStay(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        print("t: exit");
    }


}
