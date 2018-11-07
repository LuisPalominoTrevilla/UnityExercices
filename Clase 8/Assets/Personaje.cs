using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour {

    private CharacterController cc;

	// Use this for initialization
	void Start () {
        this.cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Opción 1
        //this.cc.Move(new Vector3(-v, 0, h) * 5 * Time.deltaTime);

        // Opción 2
        this.cc.SimpleMove(new Vector3(-v, 0, h) * 5);

        if (Input.GetKey(KeyCode.Escape))
        {
            // Closes the application
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //print(hit.transform.name);
    }
}
