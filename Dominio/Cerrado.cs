using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Cerrado : Lugar
    {
        //Atributos
        private bool accesibilidad;
        private decimal valorMantenimiento;
        private static int aforoMaximo = 0;
        //Propiedades
        public bool Accesibilidad
        {
            get { return accesibilidad; }
            set { accesibilidad = value; }
        }
        public decimal ValorMantenimiento
        {
            get { return valorMantenimiento; }
            set { valorMantenimiento = value; }
        }
        public int AforoMaximo
        {
            get { return aforoMaximo; }
        }
        //Constructor 
        public Cerrado (string nombre , decimal mt2, bool accesibilidad , decimal valorMantenimiento): base(nombre , mt2)
        {   
            this.accesibilidad = accesibilidad;
            this.valorMantenimiento = valorMantenimiento;
        }
        //Metodo de clase para cambiar el aforo
        public static void CambiarAforo(int nuevoAforo)
        {
            aforoMaximo = nuevoAforo;
        }
        //Metodo de clase para validar el Aforo
        public static bool ValidarAforo(int nuevoAforo)
        {
            return (nuevoAforo >= 0) && (nuevoAforo <= 100); 
        }

        //Metodo de clase -  Validar Lugar Abierto 
        public static bool ValidarLugar(string nombre, decimal mt2, bool accesibilidad, decimal valorMantenimiento)
        {
            bool resultado = false;
           
            if((nombre!="") && (mt2>0) &&(valorMantenimiento>=0))
            {
                resultado = true; 
            }
            return resultado; 
        }
        //Metodo de herencia  - TipoLugar() 
        public override string TipoLugar()
        {
            return "Cerrado";
        }

        //Metodo para calcular el precio en lugar CERRADO 
        public override decimal PrecioLugar(decimal precioBase)
        {
            decimal precio = precioBase;
            decimal adicional = 0; 
            //si el aforo es inferior al 50 % el precio aumenta un 30% del costo base
            if (aforoMaximo<50)  
            {
                adicional = 30;
            }
            //si el aforo está entre el 50 y 70 % se le agrega un 15 % del costo base
            else if ( aforoMaximo <=70)
            {
                adicional = 15; 
            } 
            precio *= (1 + (adicional / 100)); 

            return precio;
        }
        //Metodo de herencia ToString() --
        public override string ToString()
        {
            string mensaje = "";
            mensaje += base.ToString();
            mensaje += "Accesibilidad : " + accesibilidad.ToString() + "\n";
            mensaje += "Valor Mantenimiento :  $ " + valorMantenimiento + "\n";
            mensaje += "Aforo maximo :  $ " + aforoMaximo + "\n";
            return mensaje;
        }
    }
}
