using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zelda : MonoBehaviour {

    NavMeshAgent agent;
    public Camera camera;
    AudioSource source;
    public AudioClip[] clipsitos;

	// Use this for initialization
	void Start () {
        this.agent = GetComponent<NavMeshAgent>();
        this.source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            Ray rayito = this.camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayito, out hit))
            {
                this.agent.destination = hit.point;
            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            this.source.clip = clipsitos[0];
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            this.source.clip = clipsitos[1];
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            this.source.Play();
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            this.source.Pause();
        }
    }
}
