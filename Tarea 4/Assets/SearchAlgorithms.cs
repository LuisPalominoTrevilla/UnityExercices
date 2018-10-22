using System.Collections;
using System.Collections.Generic;

public class SearchAlgorithms {
    
    public static List<Nodo> BreadthWiseSearch(Nodo start, Nodo end)
    {
        List<Nodo> visitados = new List<Nodo>();
        Queue<Nodo> work = new Queue<Nodo>();
        Nodo current;
        start.history = new List<Nodo>();
        visitados.Add(start);
        work.Enqueue(start);
        while (work.Count > 0)
        {
            current = work.Dequeue();
            if (current == end)
            {
                current.history.Add(current);
                return current.history;
            }
            else
            {
                Nodo[] vecinos = current.vecinos;
                for (int i = 0; i < vecinos.Length; i++)
                {
                    if (!visitados.Contains(vecinos[i]))
                    {
                        vecinos[i].history = new List<Nodo>(current.history);
                        vecinos[i].history.Add(current);
                        work.Enqueue(vecinos[i]);
                        visitados.Add(vecinos[i]);
                    }

                }
            }
        }
        return null;
    }
}
