using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float velocity;
    public Camera cam;
    public GameObject bullet;
    public Transform gun;
	// Use this for initialization
	void Start () {
        this.velocity = 3.5f;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        this.transform.Translate(h * this.velocity * Time.deltaTime, 0, v * this.velocity * Time.deltaTime);
        if (Input.GetMouseButtonUp(0))
        {
            Ray rayitito = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayitito, out hit))
            {
                this.gun.transform.LookAt(hit.point);
                Instantiate<GameObject>(bullet, this.gun.position, this.gun.rotation);
            }
        }
    }
}
