using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding {

	public static List<Nodo> BreathwiseSearch(Nodo start, Nodo end)
    {
        Queue<Nodo> work = new Queue<Nodo>();
        List<Nodo> visitados = new List<Nodo>();
        Nodo current;
        start.historial = new List<Nodo>();
        work.Enqueue(start);
        visitados.Add(start);
        while(work.Count > 0)
        {
            current = work.Dequeue();
            if (current == end)
            {
                current.historial.Add(current);
                return current.historial;
            }
            else
            {
                Nodo[] neighbors = current.neighbors;
                for (int i = 0; i < neighbors.Length; i++)
                {
                    if (!visitados.Contains(neighbors[i]))
                    {
                        neighbors[i].historial = new List<Nodo>(current.historial);
                        neighbors[i].historial.Add(current);
                        work.Enqueue(neighbors[i]);
                        visitados.Add(neighbors[i]);
                    }
                }
            }
        }
        return null;
    }

    public static List<Nodo> DepthwiseSearch(Nodo start, Nodo end)
    {
        List<Nodo> visitados = new List<Nodo>();
        Stack<Nodo> work = new Stack<Nodo>();
        start.historial = new List<Nodo>();
        Nodo current;
        work.Push(start);
        visitados.Add(start);
        while(work.Count > 0)
        {
            current = work.Pop();
            if (current == end)
            {
                current.historial.Add(current);
                return current.historial;
            }
            else
            {
                Nodo[] vecinos = current.neighbors;
                for (int i = 0; i < vecinos.Length; i++)
                {
                    if (!visitados.Contains(vecinos[i]))
                    {
                        vecinos[i].historial = new List<Nodo>(current.historial);
                        vecinos[i].historial.Add(current);
                        visitados.Add(vecinos[i]);
                        work.Push(vecinos[i]);
                    }
                }
            }
        }
        return null;
    }

    public static List<Nodo> AStart(Nodo start, Nodo end)
    {
        List<Nodo> work = new List<Nodo>();
        List<Nodo> visitados = new List<Nodo>();

        start.historial = new List<Nodo>();
        start.g = 0;
        start.h = Vector3.Distance(start.transform.position, end.transform.position);

        visitados.Add(start);
        work.Add(start);

        while(work.Count > 0)
        {
            Nodo current = work[0];
            for (int i = 1; i < work.Count; i++)
            {
                if (work[i] == end)
                {
                    work[i].historial.Add(work[i]);
                    return work[i].historial;
                }
                if (work[i].F < current.F)
                {
                    current = work[i];
                }
            }

            work.Remove(current);

            for (int i = 0; i < current.neighbors.Length; i++)
            {
                Nodo vecinoActual = current.neighbors[i];

                visitados.Add(vecinoActual);

                vecinoActual.g = current.g + Vector3.Distance(vecinoActual.transform.position, current.transform.position);
                vecinoActual.h = Vector3.Distance(vecinoActual.transform.position, end.transform.position);

                work.Add(vecinoActual);

                vecinoActual.historial = new List<Nodo>(current.historial);
                vecinoActual.historial.Add(current);
            }
        }

        return null;
    }
}
