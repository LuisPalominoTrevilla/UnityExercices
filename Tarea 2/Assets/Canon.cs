using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

    public GameObject bullet;
    public Transform position_p1;
    public GameObject canon_p1;
    public Transform position_p2;
    public GameObject canon_p2;
    private float rotation_p1;
    private float rotation_p2;
    private float rotationIncrement;
    private AudioSource shot_sound;

    // Use this for initialization
    void Start () {
        this.rotation_p1 = 45f;
        this.rotation_p2 = 45f;
        this.rotationIncrement = 2f;
        this.canon_p1.transform.Rotate(transform.right, this.rotation_p1);
        this.canon_p2.transform.Rotate(transform.right, this.rotation_p2);
        this.shot_sound = this.canon_p1.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        // Tank 1 SHOOT
        if (Input.GetKeyDown("space"))
        {
            // Mover cañón hacia atrás
            this.canon_p1.transform.Translate(0, -.3f, 0);
        }else if (Input.GetKeyUp("space"))
        {
            // Regresar cañon a posición inicial
            this.canon_p1.transform.Translate(0, .3f, 0);
            // Disparar
            Instantiate<GameObject>(bullet, this.position_p1.position, this.canon_p1.transform.rotation);
            this.shot_sound.Play();
        }

        // Tank 2 SHOOT
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Mover cañón hacia atrás
            this.canon_p2.transform.Translate(0, -.3f, 0);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // Regresar cañon a posición inicial
            this.canon_p2.transform.Translate(0, .3f, 0);
            // Disparar
            Instantiate<GameObject>(bullet, this.position_p2.position, this.canon_p2.transform.rotation);
            this.shot_sound.Play();
        }



        // Rotate cannon 1 with M N keys
        if (Input.GetKey("m"))
        {
            if (this.rotation_p1 + this.rotationIncrement < 90)
            {
                this.rotation_p1 += this.rotationIncrement;
                this.canon_p1.transform.Rotate(transform.right, this.rotationIncrement);
            }
        }
        if (Input.GetKey("n"))
        {
            if (this.rotation_p1 - this.rotationIncrement >= 0)
            {
                this.rotation_p1 -= this.rotationIncrement;
                this.canon_p1.transform.Rotate(transform.right, -this.rotationIncrement);
            }
        }

        // Rotate cannon 2 with Q E keys
        if (Input.GetKey("q"))
        {
            if (this.rotation_p2 + this.rotationIncrement < 90)
            {
                this.rotation_p2 += this.rotationIncrement;
                this.canon_p2.transform.Rotate(transform.right, this.rotationIncrement);
            }
        }
        if (Input.GetKey("e"))
        {
            if (this.rotation_p2 - this.rotationIncrement >= 0)
            {
                this.rotation_p2 -= this.rotationIncrement;
                this.canon_p2.transform.Rotate(transform.right, -this.rotationIncrement);
            }
        }
    }
}
