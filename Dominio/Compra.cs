using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Compra
    {
        //Atributos
        private int id;
        private static int ultimoid = 0;
        private Actividad actividad;
        private int cantidadEntradas;
        private Usuario usuario;
        private DateTime fechaYhora;
        private bool estado;
        private decimal precioFinal;

        //Propiedades
        public int Id
        {
            get { return id; }
        }
        public Actividad Actividad
        {
            get { return actividad; }
            set { actividad = value; }
        }
        public int CantidadEntradas
        {
            get { return cantidadEntradas; }
            set { cantidadEntradas = value; }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public DateTime FechaYhora
        {
            get { return fechaYhora; }
            set { fechaYhora = value; }
        }
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public decimal PrecioFinal
        {
            get { return precioFinal; }
        }

        //Constructor
        public Compra()
        {

        }
        public Compra(Actividad actividad, int cantidadEntradas, Usuario usuario, DateTime fechaYhora, bool estado = true)
        {
            this.id = ultimoid++;
            this.actividad = actividad;
            this.cantidadEntradas = cantidadEntradas;
            this.usuario = usuario;
            this.fechaYhora = fechaYhora;
            this.estado = estado;
            this.precioFinal = TotalApagar();
        }
        //Validar compra
        public static bool ValidarCompra(Actividad unaActividad , int cantidadEntradas , DateTime fechaYhora , Usuario unUsuario)
        {
            bool resultado = false; 

            if (unaActividad != null && unUsuario != null)
            {
                if (cantidadEntradas>0)
                {
                    if (fechaYhora != null)
                    {
                        resultado = true; 
                    }
                }
            }
            return resultado; 
        }
        //Metodo precio final por la Compra
        private decimal TotalApagar()
        {
            decimal precioFinal = cantidadEntradas * Actividad.PrecioActividad();
            //Aplicando un descuento de 5% al total, si el cliente lleva más de 5 entradas.
            if (cantidadEntradas > 5)
            {
              precioFinal = precioFinal - ((precioFinal * 5)/100);  // 0.95 
            }
            return precioFinal;
        }
        //Metodo de herencia - GetHashCode
        public override int GetHashCode()
        {
            return id;
        }
        //Metodo de herencia - Equal ()
        public override bool Equals(object obj)
        {
            Compra unC = obj as Compra; 
            return unC!= null && id==unC.Id ;
        }
        //Metodo herencia - ToString ()
        public override string ToString()
        {
            string mensaje = "";
            mensaje += $"Nombre de actividad: {this.actividad.Nombre}";
            mensaje += $"Cantidad de Entradas: {this.cantidadEntradas}";
            mensaje += $"Usuario: {this.usuario.Nombre}";
            mensaje += $"Fecha y hora: {this.fechaYhora}";
            mensaje += $"Estado: {this.estado}";
            mensaje += $"Precio final: {this.precioFinal}";
            return mensaje;
        }

        //Metodo obtener el usuario 
        public Usuario ObtenerCliente()
        {
            return this.usuario;
        }

        //Metodo para obtener nombre de actividad
        public string NombreActividad()
        {
            return actividad.DevolverNombre();
        }

        //Metodo para obtener Estado de la compra
        public string DevolverEstado ()
        {
            string txtEstado = "Cancelado";
            if (this.estado)
            {
                txtEstado = "Activo";
            }
            return txtEstado;
        }
        //Metodo para cambiar el estado
        public bool CambiarEstado(bool nuevoE)
        {
            bool exito = false;
            if (this.estado != nuevoE)
            {
                this.estado = nuevoE;
                exito = true;
            }
            return exito;
        }

    }
}
