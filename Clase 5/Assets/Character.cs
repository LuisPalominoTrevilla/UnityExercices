using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public Nodo start, end;
    private Transform[] path;
    public float treshhold;

    private Transform target;
    private int current;
    private Coroutine c;
    private IEnumerator ie;
    private PathFinding pathf;

	// Use this for initialization
	void Start () {
        this.pathf = new PathFinding();
        List<Nodo> camino = pathf.BreadthwiseSearch(this.start, this.end);
        this.path = new Transform[camino.Count];
        print(this.path.Length);
        int i = 0;
        foreach(Nodo n in camino) {
            print(n);
            this.path[i++] = n.transform;
        }
        this.target = path[0];
        this.current = 0;
        this.ie = verificarDistancia();
        this.c = StartCoroutine(ie);
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);

        if(Input.GetKeyUp(KeyCode.Return))
        {
            // Matar corutinas: 2 maneras
            // detener todos
            // detener alguna en específico
            // StopAllCoroutines();
            StopCoroutine(ie);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            StartCoroutine(ie);
        }
	}

    // corutinas
    // lo mas cercano a concurrencia
    // código que corre "simultáneamente"
    // tipo de retorno siempre es IEnumerator
    IEnumerator verificarDistancia()
    {
        // yield -> ceder
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            // ventaja vs update
            // corre menor cantidad de veces que update
            print("CORUTINA!");
            float d = Vector3.Distance(transform.position, this.path[this.current].position);
            if (d < this.treshhold)
            {
                print("MENOR");
                current++;
                current %= path.Length;
                target = path[current];
            }
        }
    }
}
