using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Estado {

    private string nombre;
    private Type tipo;
    private Dictionary<Symbol, Estado> transicion;

    public Estado(string nombre, Type tipo)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.transicion = new Dictionary<Symbol, Estado>();
    }

    public string Nombre
    {
        get
        {
            return this.nombre;
        }
    }

    public Type Tipo
    {
        get
        {
            return this.tipo;
        }
    }

    public void setTransition(Symbol sym, Estado est)
    {
        this.transicion.Add(sym, est);
    }

    public Estado aplicarTransicion(Symbol sym)
    {
        if (this.transicion.ContainsKey(sym))
        {
            return this.transicion[sym];
        }
        else
        {
            return this;
        }
    }

}
