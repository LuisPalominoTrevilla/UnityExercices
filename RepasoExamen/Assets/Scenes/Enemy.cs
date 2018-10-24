using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Nodo start, end;
    public List<Nodo> path;
    public int curr_node;
    private Estado actual, previo;
    private Estado patroling, attacking, dead;
    private Symbol verPlayer, noLife, idle;
    private Component currentScript;
    public float vida;

	// Use this for initialization
	void Start () {

        this.vida = 100;
        this.patroling = new Estado("patroling", typeof(Patroling));
        this.attacking = new Estado("attacking", typeof(Attacking));
        this.dead = new Estado("dead", typeof(Dead));

        this.verPlayer = new Symbol("ver player");
        this.noLife = new Symbol("Out of life");
        this.idle = new Symbol("Idle");

        this.patroling.setTransition(this.noLife, this.dead);

        this.actual = this.patroling;
        this.previo = this.actual;

        this.currentScript = gameObject.AddComponent(this.actual.Tipo);

        this.start = GameObject.FindGameObjectsWithTag("StartNode")[0].GetComponent<Nodo>();
        this.end = GameObject.FindGameObjectsWithTag("EndNode")[0].GetComponent<Nodo>();
        this.path = PathFinding.AStart(start, end);
        this.curr_node = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.vida < 50)
        {
            this.transitando(this.noLife);
        }
	}

    public void transitando(Symbol sym)
    {
        this.actual = this.actual.aplicarTransicion(sym);
        if (this.actual == this.previo)
        {
            return;
        }
        this.previo = this.actual;
        Destroy(this.currentScript);
        this.currentScript = gameObject.AddComponent(this.actual.Tipo);
    }
}
