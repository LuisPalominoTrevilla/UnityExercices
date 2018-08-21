using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {

    private Animator animator;
    private float j;
    public Text text;

	// Use this for initialization
	void Start () {
        // obtener referencia a otro componente
        // invocar este método lo menos posible, porque toma tiempo
        animator = this.GetComponent<Animator>();

        this.j = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float jActual = Input.GetAxisRaw("Jump");

        animator.SetFloat("velocidad", h);
        transform.Translate(h * Time.deltaTime * 5, 0, 0);

        print(h);
        print(transform.position.x);

        // Como usar getKeyUp pero usando el eje checando el estado de j anterior con el actual
        // es decir, si en este frame ocurrió un space del teclado
        if (this.j == 0 && jActual == 1)
        {
            animator.SetTrigger("hadouken");
        }

        this.j = jActual;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Enter");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("Stay");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("Exit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("EnterTrigger");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("StayTrigger");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("ExitTrigger");
    }

    public void Clickazo()
    {
        this.text.text = "CLICKEADO";
    }

    public void Modificado(float f)
    {
        text.text = f + "";
    }
}
