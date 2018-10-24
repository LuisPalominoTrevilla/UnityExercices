using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
    public Camera camera;
    public Transform Spawn;
    public GameObject original;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0)){
            Ray rayito = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayito, out hit)){
                if (hit.transform.gameObject.name == "base"){
                    Instantiate<GameObject>(original, Spawn.position, Spawn.rotation);
                }
            }
        }
	}
}
