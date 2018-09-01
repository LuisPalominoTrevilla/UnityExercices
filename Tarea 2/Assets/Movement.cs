using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public GameObject tank_p1;
    public GameObject tank_p2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float h_1 = Input.GetAxis("Horizontal_p1");
        float v_1 = Input.GetAxis("Vertical_p1");

        this.tank_p1.transform.Translate(-1 * v_1 * Time.deltaTime * 5, 0, h_1 * Time.deltaTime * 5, Space.World);

        float h_2 = Input.GetAxis("Horizontal_p2");
        float v_2 = Input.GetAxis("Vertical_p2");
        

        this.tank_p2.transform.Translate(-1 * v_2 * Time.deltaTime * 5, 0, h_2 * Time.deltaTime * 5, Space.World);
    }
}
