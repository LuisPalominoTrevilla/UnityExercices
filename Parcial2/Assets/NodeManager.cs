using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour {

    public Nodo[] nodos;
    public Nodo selected;
    public Material normalM, selectM;
    public Camera cam;

	// Use this for initialization
	void Start () {
        this.paintSelected(selectM);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(1)){
            Ray rayito = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayito, out hit)){
                for (int i = 0; i < nodos.Length; i++){
                    if (nodos[i].gameObject == hit.transform.gameObject){
                        this.paintSelected(normalM);
                        this.Selected = nodos[i];
                        this.paintSelected(selectM);
                    }
                }
            }
        }
	}

    public void paintSelected(Material mat){
        selected.GetComponent<Renderer>().material = mat;
    }

    public Nodo Selected{
        get{
            return this.selected;
        }

        set{
            this.selected = value;
        }
    }
}
