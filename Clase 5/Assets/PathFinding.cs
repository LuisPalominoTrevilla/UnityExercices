using System.Collections;
using System.Collections.Generic;


public class PathFinding {

    public List<Nodo> BreadthwiseSearch(Nodo start, Nodo end)
    {
        List<Nodo> visitados = new List<Nodo>();
        Queue<Nodo> work = new Queue<Nodo>();

        start.historial = new List<Nodo>();

        visitados.Add(start);
        work.Enqueue(start);

        while (work.Count > 0)
        {
            Nodo actual = work.Dequeue();
            if (actual == end)
            {
                // encontramos el nodo
                actual.historial.Add(actual);
                return actual.historial;
            }
            else
            {
                // todavía no encontramos
                Nodo[] vecinos = actual.vecinos;
                for( int i = 0; i < vecinos.Length; i++)
                {
                    if (!visitados.Contains(vecinos[i]))
                    {
                        vecinos[i].historial = new List<Nodo>();
                        foreach (Nodo n in actual.historial)
                        {
                            vecinos[i].historial.Add(n);
                        }
                        vecinos[i].historial.Add(actual);
                        visitados.Add(vecinos[i]);
                        work.Enqueue(vecinos[i]);
                    }
                }
            }
        }

        // no existió ruta, el ciclo terminó
        return null;
    }

    public static List<Nodo> DepthwiseSearch(Nodo start, Nodo end)
    {
        return null;
    }

    public static List<Nodo> AStar(Nodo start, Nodo end)
    {
        return null;
    }
}
