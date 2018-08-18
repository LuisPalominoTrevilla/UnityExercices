using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    private static bool isFirst;
	// Use this for initialization
	void Start () {
        isFirst = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (isFirst)
        {
            isFirst = false;
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
