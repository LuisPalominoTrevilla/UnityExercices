using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Estado {

    private string nombre;
    private Dictionary<Simbolo, Estado> transicion;
    private Type tipo;

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

    public Estado(string nombre, Type tipo)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.transicion = new Dictionary<Simbolo, Estado>();
    }

    public void definirTransicion(Simbolo s, Estado e)
    {
        if (!this.transicion.ContainsKey(s))
        {
            this.transicion.Add(s, e);
        }
        else
        {
            this.transicion[s] = e;
        }
    }

    public Estado aplicarSimbolo(Simbolo s)
    {
        if (this.transicion.ContainsKey(s))
        {
            return transicion[s];
        }
        return this;
    }
}
