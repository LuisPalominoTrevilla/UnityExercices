using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding {

    public static List<Nodo> BreadthWiseSearch(Nodo start, Nodo end){
        Queue<Nodo> work = new Queue<Nodo>();
        List<Nodo> visitados = new List<Nodo>();
        start.history = new List<Nodo> ();
        work.Enqueue(start);
        visitados.Add(start);
        while(work.Count > 0){
            Nodo current = work.Dequeue();
            if (current == end) {
                current.history.Add(current);
                return current.history;
            }else{
                Nodo[] vecinos = current.vecinos;
                for (int i = 0; i < vecinos.Length; i++){
                    if (!visitados.Contains(vecinos[i])){
                        vecinos[i].history = new List<Nodo>(current.history);
                        vecinos[i].history.Add(current);

                        visitados.Add(vecinos[i]);
                        work.Enqueue(vecinos[i]);

                    }
                }
            }
        }
        return null;
    }
}
