using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Actividad
    {
        //Atributos
        private int id;
        private static int idContador = 0;
        private string nombre;
        private Categoria categoria;
        private DateTime fechaYhora;
        private Lugar lugar;
        private string edadMinima;
        private static decimal precioBase = 1000;
        private int meGusta;

        //Propiedades
        public int Id
        {
            get { return id; }
        }
        public string Nombre
        {
            get { return nombre; }
        }
        public Categoria Categoria
        {
            get { return categoria; }
        }
        public DateTime FechaYhora
        {
            get { return fechaYhora; }
        }
        public Lugar Lugar
        {
            get { return lugar; }
        }
        public string EdadMinima
        {
            get { return edadMinima; }
        }
        public decimal PrecioBase
        {
            get { return precioBase; }
        }
        public int MeGusta
        {
            get { return meGusta; }
        }
        //Constructor
        public Actividad ()
        {

        }
        public Actividad(string nombre, Categoria categoria, DateTime fechaYhora, Lugar lugar, string edadMinima, int meGusta)
        {
            this.id = idContador++;
            this.nombre = nombre;
            this.categoria = categoria;
            this.fechaYhora = fechaYhora;
            this.lugar = lugar;
            this.edadMinima = edadMinima;
            this.meGusta = meGusta;
        }
        //Devolver el nombre de una instancia del objeto Categoria
        public string NombreCategoria()
        {
            return categoria != null ? categoria.Nombre : "----No tiene un categoria---"; 
        }
        //Metodo de herencia - GetHashCode()
        public override int GetHashCode()
        {
            return id;
        }
        //Metodo de herencia Equals 
        public override bool Equals(object obj)
        {
            Actividad unA = obj as Actividad;
            return unA != null && id == unA.Id;
        }
        //Metodo de herencia ToString()
        public override string ToString()
        {
            string mensaje = "";
            mensaje += $"Actividad - {this.id}\n";
            mensaje += $"---------------------\n";
            mensaje += $"Nombre de actividad: {this.nombre}\n";
            mensaje += $"Categoria: {NombreCategoria()}\n";
            mensaje += $"Fecha y hora: {this.fechaYhora}\n";
            mensaje += $"Lugar: {this.lugar.Nombre} - Tipo : {this.lugar.TipoLugar()} \n";
            mensaje += $"Edad minima: {this.edadMinima}\n";
            mensaje += $"Precio base: {this.PrecioBase}\n";
            mensaje += $"Cantidad de me gusta: {this.meGusta}\n";
            return mensaje;
        }
        //Metodo Validar limite de edad 
        public static bool ValidarLimiteEdad(string edadMinima)
        {
            return edadMinima == "P" || edadMinima == "C13" || edadMinima == "C16" || edadMinima == "C18";
        }
        //Metodo para CalcularPrecioFinalActividad 
        public decimal PrecioActividad()
        {
            decimal total = Lugar.PrecioLugar(precioBase); 
            return total; 
        }
        //Metodo para agregar Me gusta
        public void AgregarMeGusta()
        {
            this.meGusta++;
        }

        //Metodo devolucion datos
        public string DevolverNombre()
        {
            return this.nombre;
        }
        public DateTime DevolverFecha()
        {
            return this.fechaYhora;
        }
    }
}