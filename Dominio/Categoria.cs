using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Categoria
    {
        //Atributos
        private int id;
        private static int ultimaId = 0; 
        private string nombre;
        private string descripcion;
        //Propiedades
        public int Id
        {
            get { return id; }
        }
        public string Nombre
        {
            get { return nombre; }
        }
        public string Descripcion
        {
            get { return descripcion; }
        }
        //Constructor
        public Categoria(string nombre, string descripcion)
        {
            this.id = ultimaId++;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        //Metodo de herencia - Equal Objeto 
        public override bool Equals(object obj)
        {
            Categoria unC = obj as Categoria;
            return unC != null && id == unC.Id;
        }
        //Metodo de herencia - GetHashCode
        public override int GetHashCode()
        {
            return id;
        }
        //Metodo de herencia ToString () -- 
        public override string ToString()
        {
            string mensaje = "";
            mensaje += $"Nombre de categoria: {this.nombre}\n";
            mensaje += $"Descripcion: {this.descripcion}\n";
            return mensaje;
        }
        //Metodo validar los datos de la categoria 
        public static bool ValidarCategoria(string nombre, string descripcion)
        {
            bool exito = false;
            if (!(nombre.Length == 0) && !(descripcion.Length == 0))
            {
                exito = true;
            }
            return exito;
        }
    }
}
