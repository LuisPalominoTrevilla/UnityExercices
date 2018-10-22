using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simbolo {
    private string nombre;

    // propiedades
    // Java tenian getters y setters

    // propiedades
    public string Nombre
    {
        set
        {
            this.nombre = value;
        }

        get
        {
            return this.nombre;
        }
    }

    public Simbolo(string nombre)
    {
        Nombre = nombre;
    }
}
