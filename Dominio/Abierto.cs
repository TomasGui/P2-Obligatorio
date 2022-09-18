using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Abierto : Lugar 
    {
        //Atributos
        private static decimal precio = 0; 

        //Propiedades 
        public decimal Precio
        {
           get { return precio;  }
        }
        //Contructor
        public Abierto(string nombre, decimal mt2) : base(nombre, mt2) { }
        //Metodo de clase para cambiar precio butaca 
        public static void CambiarPrecioButaca(decimal nuevoPrecio)
        {   
            precio = nuevoPrecio;
        }
        //Metodo de Validar Lugar Abierto
        public static bool ValidarLugar(string nombre, decimal mt2) 
        {
            bool resultado = false;

            if ((nombre != "") && (mt2 > 0))
            {
                resultado = true;
            }
            return resultado;
        }
        //Metodo de herencia 
        public override string ToString()
        {
            string mensaje = "";
            mensaje += base.ToString();
            mensaje += "Precio Butaca: " + precio + "\n";
            return mensaje;
        }
        //Mertodo de herencia  - TipoLugar() 
        public override string TipoLugar()
        {
            return "Abierto";
        }

        //Metodo para calcular el precio en lugar ABIERTO

        public override decimal PrecioLugar(decimal precioBase)
        {
            //precio - atributo de Lugar Abierto , precio x butaca 
            decimal total = precioBase;
            decimal adicional = 0; 
            //Sabiendo que 1 km2 son 1000000 mt2 - se le agrega un 10% si las dimensiones del lugar donde se realiza es superior a 1 km2
            if (Mt2>1000000)
            {
                adicional = 10; 
            }
            total *= (1 + (adicional / 100));

            //Se le agrega el precio por butaca para este lugar
            total += precio; 

            return total; 
        }

        //Metodo para validar Precio 
        public static bool ValidarPrecioButaca(decimal precioButaca)
        {
            return precioButaca > 0; 
        }
        
        
    }
}
