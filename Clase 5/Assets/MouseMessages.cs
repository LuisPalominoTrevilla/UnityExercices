using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMessages : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        print("UP");
    }

    private void OnMouseDown()
    {
        print("DOWN");
    }

    private void OnMouseDrag()
    {
        //print("DRAG");
    }

    private void OnMouseExit()
    {
        print("EXIT");
    }

    private void OnMouseOver()
    {
        //print("OVER");   
    }

    private void OnMouseEnter()
    {
        print("ENTER");
    }

    private void OnMouseUpAsButton()
    {
        print("BUTTON");
    }
}
