using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplito : MonoBehaviour {
    public float vida = 100;
    private Estado actual, anterior;
    private Estado ocioso, comiendo, programando, llorando, reprobando;
    private Simbolo parciales, hambre, noCompila;
    private Component scriptActual;
    public Transform elOtro;

	// Use this for initialization
	void Start () {

        this.ocioso = new Estado("ocioso", typeof(Ocioso));
        this.comiendo = new Estado("comiendo", typeof(Comiendo));
        this.programando = new Estado("programando", typeof(Programando));
        this.llorando = new Estado("llorando", typeof(Llorando));
        this.reprobando = new Estado("reprobando", typeof(Reprobando));

        this.parciales = new Simbolo("parciales");
        this.hambre = new Simbolo("hambre");
        this.noCompila = new Simbolo("no Compila");

        this.ocioso.definirTransicion(parciales, this.llorando);
        this.ocioso.definirTransicion(hambre, this.comiendo);
        this.ocioso.definirTransicion(this.noCompila, this.llorando);

        this.comiendo.definirTransicion(parciales, this.programando);
        this.comiendo.definirTransicion(hambre, this.comiendo);
        this.comiendo.definirTransicion(this.noCompila, this.ocioso);

        this.programando.definirTransicion(parciales, this.reprobando);
        this.programando.definirTransicion(hambre, this.llorando);
        this.programando.definirTransicion(this.noCompila, this.ocioso);

        this.llorando.definirTransicion(parciales, this.llorando);
        this.llorando.definirTransicion(hambre, this.comiendo);
        this.llorando.definirTransicion(this.noCompila, this.llorando);

        this.reprobando.definirTransicion(parciales, this.llorando);
        this.reprobando.definirTransicion(hambre, this.comiendo);
        this.programando.definirTransicion(this.noCompila, this.programando);

        this.actual = this.ocioso;
        this.anterior = this.actual;
        this.scriptActual = this.gameObject.AddComponent(actual.Tipo);
        // 
        //System.Type type = typeof(Ocioso);
        //this.gameObject.AddComponent<Ocioso>();
        //this.gameObject.AddComponent(type);
        StartCoroutine(this.checarVida());
        StartCoroutine(this.checarDistancia());
    }

    void transitar(Simbolo simbolo)
    {
        this.actual = this.actual.aplicarSimbolo(simbolo);
        if (this.anterior == this.actual)
        {
            return;
        }
        this.anterior = this.actual;
        Destroy(scriptActual);
        scriptActual = gameObject.AddComponent(actual.Tipo);
        print(this.actual.Nombre);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator checarVida()
    {
        while (true)
        {
            if (vida < 30)
            {
                this.transitar(this.hambre);
            }
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator checarDistancia()
    {
        while (true)
        {
            float d = Vector3.Distance(this.elOtro.position, this.transform.position);
            if (d < 2)
            {
                this.transitar(this.parciales);
            }
            yield return new WaitForSeconds(1.1f);
        }
    }
}
