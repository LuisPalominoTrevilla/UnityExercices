using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    
    private Nodo[] path;
    public float treshhold;
    public Nodo start, end;

    private Transform target;
    private int current;
    private Coroutine c;
    private IEnumerator ie;

	// Use this for initialization
	void Start () {
        this.ie = this.verificarDistancia();
        
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

        if (Input.GetKeyUp(KeyCode.Y))
        {
            List<Nodo> ruta = PathFinding.BreadthwiseSearch(this.start, this.end);
            for (int i = 0; i < ruta.Count; i++)
            {
                print(ruta[i]);
            }
            this.path = ruta.ToArray();
            this.current = 0;
            this.target = path[0].transform;
            this.c = StartCoroutine(this.ie);
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
            float d = Vector3.Distance(transform.position, this.path[this.current].transform.position);
            if (d < this.treshhold)
            {
                print("MENOR");
                current++;
                current %= path.Length;
                target = path[current].transform;
            }
        }
    }
}
