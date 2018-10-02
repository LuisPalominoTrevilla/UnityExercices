using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        List<Nodo> resultado = new List<Nodo>();
        List<Nodo> visitados = new List<Nodo>();
        Stack<Nodo> work = new Stack<Nodo>();

        start.historial = new List<Nodo>();
        visitados.Add(start);

        work.Push(start);
        while (work.Count > 0)
        {
            Nodo current = work.Pop();
            if (current == end)
            {
                resultado = current.historial;
                resultado.Add(current);
                return resultado;
            }else
            {
                Nodo[] vecinos = current.vecinos;
                for (int i = 0; i < vecinos.Length; i++)
                {
                    if (!visitados.Contains(vecinos[i]))
                    {
                        visitados.Add(current);

                        vecinos[i].historial = new List<Nodo>(current.historial);
                        vecinos[i].historial.Add(current);
                        work.Push(vecinos[i]);
                    }
                }
            }
        }
        return null;
    }

    public static List<Nodo> AStar(Nodo start, Nodo end)
    {
        List<Nodo> work = new List<Nodo>();
        List<Nodo> visitados = new List<Nodo>();
        start.historial = new List<Nodo>();
        // Calcular f(start) = g(start) + h(start)
        start.g = 0;
        start.h = Vector3.Distance(start.transform.position, end.transform.position);

        visitados.Add(start);
        work.Add(start);

        while(work.Count > 0)
        {
            // Seleccionar quién sigue basado en criterio
            Nodo current = work[0];
            for (int i = 1; i < work.Count; i++) {
                if (work[i] == end)
                {
                    List<Nodo> resultado = work[i].historial;
                    resultado.Add(work[i]);
                    return resultado;
                }
                if (work[i].F < current.F) {
                    current = work[i];
                }
            }

            work.Remove(current);

            // si llegamos aquí, el nodo final no está en la lista de trabajo
            // Recorremos los vecinos
            for (int i = 0; i < current.vecinos.Length; i++)
            {
                Nodo vecinoActual = current.vecinos[i];

                visitados.Add(vecinoActual);

                vecinoActual.g = current.g + Vector3.Distance(current.transform.position, vecinoActual.transform.position);
                vecinoActual.h = Vector3.Distance(vecinoActual.transform.position, end.transform.position);

                work.Add(vecinoActual);
                vecinoActual.historial = new List<Nodo>(current.historial);
                vecinoActual.historial.Add(current);
            }
        }

        return null;
    }
}
