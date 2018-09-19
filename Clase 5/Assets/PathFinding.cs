using System.Collections;
using System.Collections.Generic;


public class PathFinding {

    public static List<Nodo> BreadthwiseSearch(Nodo start, Nodo end)
    {
        List<Nodo> resultado = new List<Nodo>();
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
                resultado = actual.historial;
                resultado.Add(actual);
                return resultado;
            }
            else
            {
                // todavía no encontramos
                Nodo[] vecinos = actual.vecinos;
                for( int i = 0; i < vecinos.Length; i++)
                {
                    Nodo vecinoActual = vecinos[i];
                    if (!visitados.Contains(vecinoActual))
                    {
                        vecinoActual.historial = new List<Nodo>(actual.historial);
                        vecinoActual.historial.Add(actual);

                        visitados.Add(vecinoActual);
                        work.Enqueue(vecinoActual);
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
