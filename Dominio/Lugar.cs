using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Lugar
    {
		//Atributos
		private int id;
		private static int ultimoId = 0;
		private string nombre;
		private decimal mt2;

		//Propiedades
		public int Id
		{
			get { return id; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public decimal Mt2
		{
			get { return mt2; }
			set { mt2 = value; }
		}
		//Constructor
		public Lugar(string nombre, decimal mt2)
		{
			this.id = ultimoId;
			this.nombre = nombre;
			this.mt2 = mt2;
			ultimoId++;
		}
		//Metodo para el tipo de lugar 
		public abstract string TipoLugar();
		//Metodo polimorfico para calcular el precio del lugar
		public abstract decimal PrecioLugar(decimal precioBase);

        //Metodo de herencia
        //Metodo de herencia - Equal Objeto 
        public override bool Equals(object obj)
        {
			Lugar unL = obj as Lugar; 
            return unL !=null && id == unL.Id;
        }
		//Metodo de herencia - GetHashCode
		public override int GetHashCode()
		{
			return id;
		}

		//Metodo de herencia - ToString()
		public override string ToString()
		{
			string mensaje = "";
			mensaje += "Nombre : " + nombre + "\n";
			mensaje += "Metros cuadrados : " + mt2 + "\n";
			mensaje += "Tipo :" + TipoLugar()+ "\n";
			return mensaje;
		}
	}
}
