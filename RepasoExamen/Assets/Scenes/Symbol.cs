using System.Collections;
using System.Collections.Generic;

public class Symbol {

    private string nombre;

    public Symbol(string nom)
    {
        this.Nombre = nom;
    }

    public string Nombre
    {
        get
        {
            return this.nombre;
        }
        set
        {
            this.nombre = value;
        }
    }
}
