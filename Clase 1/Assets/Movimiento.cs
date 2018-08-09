using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// packages en java ~ namespaces
// C#
// .NET ~ 

// todo el código que queramos agregar directamente a un gameobject
// debe heredar de monobehaviour
public class Movimiento : MonoBehaviour {

	// ciclo de vida
	// ~ serie de eventos que se ejecutan en momentos específicos
	// de la vida de un script

	// Corre al inicio 1 sóla vez 
	// en todos los casos
	void Awake() {
		print("AWAKE");
	}

	// Corre 1 vez después de TODOS los awakes
	// Corre sólo si e objeto está habilitado
	void Start () {
		print("START");
	}
	
	// El juego funciona como un loop gigante
	// lógica ~ gráficos (repetir n veces)
	// FPS - frames per second
	//  ~ cuántas veces hizo el proceso lógica -> gráficos en 1 segundo
	// realtime? fps? ~ 30
	// DESEABLE ~ 60+
	void Update () {

		// lo que esté aquí corre FPS veces
		// queremos que este método sea lo mas magro posible

		// 2 cosas para este método
		// ~ input : responsivo ~ responde lo mas cercano posible a la interacción
		if(Input.GetKeyDown(KeyCode.A)) {
			print("frame anterior estaba suelta, este frame está presionada");
		}

        float delta = .1f;

		if(Input.GetKey(KeyCode.A)) {
			//print("frame anterior estaba presionada, este frame sigo");
			transform.Translate(-delta, 0, 0);
		}
        if(Input.GetKey(KeyCode.D)) {
			//print("frame anterior estaba presionada, este frame sigo");
			transform.Translate(delta, 0, 0);
		}
        if(Input.GetKey(KeyCode.W)) {
			//print("frame anterior estaba presionada, este frame sigo");
			transform.Translate(0, delta, 0);
		}
        if(Input.GetKey(KeyCode.S)) {
			//print("frame anterior estaba presionada, este frame sigo");
			transform.Translate(0, -delta, 0);
		}

		if(Input.GetKeyUp(KeyCode.A)) {
			//print("frame anterior estaba presionada, este frame está suelta");
			//transform.Translate(0.01f, 0, 0);
		}

		if(Input.GetMouseButtonDown(0)){
			print(Input.mousePosition);
		}
		
		
		
		// ~ movimiento : lo más fluido posible
		//UnityEngine.Debug.Log("UPDATE");	// operación no bloquea

		// componentes ~ piezas que conforman gameobjects
		
	}
	
	// Se ejecuta 1 vez por loop
	// Después de TODOS los updates
	void LateUpdate() {
		//print("LATE UPDATE");
	}

	// se ejecuta una configurada cantidad de veces
	// (edit -> project settings -> time)
	void FixedUpdate() {
		//print("FIXED UPDATE");
	}
}
