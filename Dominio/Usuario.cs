using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Usuario: IComparable<Usuario>
    {
        //Atributos
        private int id;
        private static int idContador = 0;
        private string nombre;
        private string apellido;
        private string email;
        private DateTime fechaNac;
        private string nombreUsuario;
        private string password;
        private string rol = "cliente";

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
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }
        //Constructor
        public Usuario ()
        {
            this.id = idContador++;
        }
        public Usuario(string nombre, string apellido, string email, DateTime fechaNac , string nombreUsuario , string password , string rol = "cliente")
        {
            this.id = idContador++;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.fechaNac = fechaNac;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.rol = rol; 

        }
        //TODO : Metodo para validar los datos del Usuario 
       internal static bool ValidarUsuario(string nombre, string apellido, string email, DateTime fechaNacimiento , string nombreUsuario , string password)
        {

            //Se debe validar que el nombre y apellido tengan un largo mínimo de 2 caracteres y la
            //contraseña tendrá un largo mínimo de 6 caracteres y contendrá al menos una
            // mayúscula, una minúscula y un dígito.El nombre de usuario y el email deben ser
            //únicos.
            bool resultado = false;
            if ((nombre != null && nombre.Length > 2 ) && (apellido != null && apellido.Length > 2)) {

                if (email != null)
                {
                    if (nombreUsuario != null)
                    {
                        if (ValidarPassword(password))
                        {
                            resultado = true; 
                        }

                    }
                }
            }
            return resultado; 
        }
        //Metodo validar Password 
        public static bool ValidarPassword(string password)
        {
            bool resultado = false;
            int mayusculas = 0;
            int minusculas = 0;
            int digito = 0; 
           
            if (password.Length >= 6)
            {
              foreach (char letra in password)
                {
                   if (Char.IsLower(letra))
                    {
                        minusculas++;
                    }
                    if (Char.IsUpper(letra))
                    {
                        mayusculas++;
                    }
                    if (Char.IsDigit(letra))
                    {
                        digito++;
                    }
                }
               if (mayusculas >=1 && minusculas >=1 && digito >= 1)
                {
                    resultado = true;
                }
            }
            return resultado; 
        }

        //Metodo de herencia - GetHashCode()
        public override int GetHashCode()
        {
            return id;
        }
        //Metodo de herencia - Equals()
        public override bool Equals(object obj)
        {
            Usuario unU = obj as Usuario;
            return unU != null && id == unU.Id;
        }
        //Metodo de herencia ToString() 
        public override string ToString()
        {
            string mensaje = "";
            mensaje += $"Nombre: {this.nombre}";
            mensaje += $"Apellido: {this.apellido}";
            mensaje += $"Email: {this.email}";
            mensaje += $"Fecha nacimiento: {this.fechaNac}";
            return mensaje;
        }

        //Metodo para ordenar los usuarios
        public int CompareTo(Usuario other)
        {
            int orden = apellido.CompareTo(other.Apellido);
            if (orden == 0)
            {
                orden = nombre.CompareTo(other.nombre);
            }
            return orden;
        }
        //Metodo para obtener ID
        public int ObtenerId()
        {
            return this.id;
        }
    }
}
