using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Administradora
    {
        //Atributos
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Lugar> lugares = new List<Lugar>();
        private List<Actividad> actividades = new List<Actividad>();
        private List<Compra> compras = new List<Compra>();
        private List<Categoria> categorias = new List<Categoria>();
        private static Administradora instancia;
        //Propierties
        public static Administradora Instancia
        {
            get
            {
                if (instancia == null) instancia = new Administradora();
                return instancia;
            }
        }
        public List<Usuario> Usuarios
        {
            get { return usuarios; }
        }
        public List<Lugar> Lugares
        {
            get { return lugares; }
        }
        public List<Compra> Compras
        {
            get { return compras; }    
        }
        public List<Actividad> Actividades
        {
            get { return actividades; }
        }
        public List<Categoria> Categorias
        {
            get { return categorias; }
        }

        //Constructor
        private Administradora()
        {
            Precarga();
        }
        //Precargas
        public void Precarga()
        {
            //Se realiza la precarga lugares y categorias antes de las Actividades
            PrecargaLugares();
            PrecargaCategorias();
            PrecargaActividades();
            PrecargaAforoYprecioButaca();
            PrecargaUsuarios();
            PrecargaCompras();
        }
        public void PrecargaLugares()
        {
            //Lugares Abiertos - DATOS VALIDOS
            Abierto lugarA1 = new Abierto("Chacra", 1000);
            ValidarYCargarLugares(lugarA1); 
            Abierto lugarA2 = new Abierto("Cancha", 400);
            ValidarYCargarLugares(lugarA2);
            Abierto lugarA3 = new Abierto("Parque de diverciones", 1000);
            ValidarYCargarLugares(lugarA3);
            Abierto lugarA4 = new Abierto("Pista ciclismo", 1200);
            ValidarYCargarLugares(lugarA4);
            Abierto lugarA5 = new Abierto("Estadio", 10800);
            ValidarYCargarLugares(lugarA5);

            //Luagres Cerrados - DATOS VALIDOS
            Cerrado lugarC1 = new Cerrado("Museo", 500, true, 1000);
            ValidarYCargarLugares(lugarC1);
            Cerrado lugarC2 = new Cerrado("Salon de fiestas", 600, false, 2500);
            ValidarYCargarLugares(lugarC2);
            Cerrado lugarC3 = new Cerrado("Restaurante", 300, true, 1600);
            ValidarYCargarLugares(lugarC3);
            Cerrado lugarC4 = new Cerrado("Bazar", 250, false, 800);
            ValidarYCargarLugares(lugarC4);
            Cerrado lugarC5 = new Cerrado("Shopping",2000, true, 8000);
            ValidarYCargarLugares(lugarC5);
        }
        public void PrecargaActividades()
        {
            //Actividades - DATOS VALIDOS
            Actividad act1 = new Actividad("Circus du Solei", categorias[0], new DateTime(2021, 08, 22, 18, 00, 00), lugares[2], "C13", 56);
            ValidarYCargarActividad(act1);
            Actividad act2 = new Actividad("Festival futbol", categorias[2], new DateTime(2021, 12, 10, 12, 00, 00), lugares[1], "P", 102);
            ValidarYCargarActividad(act2);
            Actividad act3 = new Actividad("Carnaval y expo", categorias[1], new DateTime(2021, 10, 02, 15, 00, 00), lugares[0], "P", 65);
            ValidarYCargarActividad(act3);
            Actividad act4 = new Actividad("Vuelta ciclista", categorias[2], new DateTime(2021, 11, 01, 10, 00, 00), lugares[3], "C16", 34);
            ValidarYCargarActividad(act4);
            Actividad act5 = new Actividad("Campeonato departamental", categorias[2], new DateTime(2021, 08, 12, 09, 00, 00), lugares[4], "C18", 88);
            ValidarYCargarActividad(act5);
            Actividad act6 = new Actividad("Museo de Historia", categorias[1], new DateTime(2021, 12, 14, 10, 00, 00), lugares[5], "P", 40);
            ValidarYCargarActividad(act6);
            Actividad act7 = new Actividad("Aniversario Departamento de Cultura", categorias[3], new DateTime(2021, 09, 05, 08, 00, 00), lugares[6], "C16", 34);
            ValidarYCargarActividad(act7);
            Actividad act8 = new Actividad("Cena show", categorias[3], new DateTime(2021, 10, 10, 12, 00, 00), lugares[7], "P", 123);
            ValidarYCargarActividad(act8);
            Actividad act9 = new Actividad("Feria regional", categorias[1], new DateTime(2021, 11, 23, 09, 00, 00), lugares[0], "P", 27);
            ValidarYCargarActividad(act9);
            Actividad act10 = new Actividad("Apertura Shopping", categorias[3], new DateTime(2021, 12, 02, 11, 00, 00), lugares[9], "P", 130);
            ValidarYCargarActividad(act10);
            Actividad act11 = new Actividad("Expo Ecologica", categorias[3], new DateTime(2021, 12, 02, 11, 00, 00), lugares[0], "P", 130);
            ValidarYCargarActividad(act11);
            Actividad act12 = new Actividad("Expo Prado", categorias[1], new DateTime(2022, 03, 01, 8, 00, 00), lugares[0], "P", 1500);
            ValidarYCargarActividad(act12);
            Actividad act13 = new Actividad("Cisne Negro", categorias[0], new DateTime(2022, 02, 10, 22, 00, 00), lugares[5], "C18", 10);
            ValidarYCargarActividad(act13);
            Actividad act14 = new Actividad("Centro Comercial", categorias[3], new DateTime(2022, 03, 11, 20, 00, 00), lugares[8], "P", 140);
            ValidarYCargarActividad(act14);
        }
        public void PrecargaCategorias()
        {
            //Categorias - DATOS VALIDOS
            Categoria cat1 = new Categoria("Teatro", "Arte teatral o show");
            ValidarYCargarCategoria(cat1);
            Categoria cat2 = new Categoria("Feria", "Feria general");
            ValidarYCargarCategoria(cat2);
            Categoria cat3 = new Categoria("Deporte", "Esparcimiento social");
            ValidarYCargarCategoria(cat3);
            Categoria cat4 = new Categoria("Reunion social", "Espacio cultural");
            ValidarYCargarCategoria(cat4);
        }
        //PrecargaUsuarios 
        public void PrecargaUsuarios()
        {
            //Usuarios - DATOS VALIDOS
            //CLientes
            Usuario usuario1 = new Usuario("Diego", "Frutos", "diegof@mimail.com", new DateTime(1988, 10, 07), "Diegote587", "XQW112hy", "cliente");
            ValidarYCargarUsuarios(usuario1);
            Usuario usuario2 = new Usuario("Diego", "Gallardo", "diegog@mimail.com", new DateTime(1989, 03, 15), "Diego15ti", "!hola12HO", "cliente");
            ValidarYCargarUsuarios(usuario2);
            Usuario usuario3 = new Usuario("Andres", "Frutos", "andresf@mimail.com", new DateTime(1990, 05, 03), "FrutoXAN", "jhq1XA1", "cliente");
            ValidarYCargarUsuarios(usuario3);
            Usuario usuario4 = new Usuario("Andres", "Gallardo", "andresg@mimail.com", new DateTime(1989, 01, 15), "AndresGall", "02558Pass", "cliente");
            //Operadores
            ValidarYCargarUsuarios(usuario4);
            Usuario usuario5 = new Usuario("Juan", "Barrera", "juanb@mimail.com", new DateTime(1990, 01, 01), "Admin0125", "ADMINpass01", "operador");
            ValidarYCargarUsuarios(usuario5);
            Usuario usuario6 = new Usuario("Ignacio", "Barrera", "ignaciob@mimail.com", new DateTime(1991, 10, 01), "Admin0126", "ADMIN2021hoy", "operador");
            ValidarYCargarUsuarios(usuario6);
            Usuario usuario7 = new Usuario("Guillermo", "Tomas", "guillermot@mimail.com", new DateTime(1990, 07, 01), "AdminGtomas", "Gtomas958", "operador");
            ValidarYCargarUsuarios(usuario7);
            Usuario usuario8 = new Usuario("Martin", "Tomas", "matint@mimail.com", new DateTime(1991, 12, 01), "JuanAdmin", "2021ADMINpbd", "operador");
            ValidarYCargarUsuarios(usuario8);
        }
        //Precarga compras 
        public void PrecargaCompras()
        {
            //Usuarios - DATOS VALIDOS
            Compra compra1 = new Compra(actividades[2], 5, usuarios[0], new DateTime(2021, 11, 02), true);
            ValidarYCargarCompra(compra1);
            Compra compra2 = new Compra(actividades[1], 1, usuarios[1], new DateTime(2021, 11, 01), true);
            ValidarYCargarCompra(compra2);
            Compra compra3 = new Compra(actividades[0], 2, usuarios[3], new DateTime(2021, 11, 02), false);
            ValidarYCargarCompra(compra3);
            Compra compra4 = new Compra(actividades[5], 3, usuarios[0], new DateTime(2021, 11, 10), true);
            ValidarYCargarCompra(compra4);
            Compra compra5 = new Compra(actividades[3], 7, usuarios[1], new DateTime(2021, 10, 04), false);
            ValidarYCargarCompra(compra5);
            Compra compra6 = new Compra(actividades[2], 3, usuarios[2], new DateTime(2021, 08, 05), true);
            ValidarYCargarCompra(compra6);
            Compra compra7 = new Compra(actividades[0], 8, usuarios[0], new DateTime(2021, 11, 06), true);
            ValidarYCargarCompra(compra7);
            Compra compra8 = new Compra(actividades[2], 4, usuarios[6], new DateTime(2021, 10, 09), true);
            ValidarYCargarCompra(compra8);
            Compra compra9 = new Compra(actividades[1], 6, usuarios[2], new DateTime(2021, 11, 09), true);
            ValidarYCargarCompra(compra9);
            Compra compra10 = new Compra(actividades[5], 2, usuarios[4], new DateTime(2021, 10, 22), false);
            ValidarYCargarCompra(compra10);
        }
        //Metodos para validar y cargar Lugares ABIERTO
        public bool ValidarYCargarLugares(Abierto lugarAbierto)
        {
            bool exito = false; 
            if ((Abierto.ValidarLugar(lugarAbierto.Nombre , lugarAbierto.Mt2)) && (!BuscarLugarEnListaLugares(lugarAbierto)))
            {
                Lugares.Add(lugarAbierto);
                exito = true; 
            }
            return exito; 
        }
        //Metodos para validar y cargar Lugares CERRADO
        public bool ValidarYCargarLugares(Cerrado lugarCerrado)
        {
            bool exito = false;
            if (Cerrado.ValidarLugar(lugarCerrado.Nombre, lugarCerrado.Mt2 , lugarCerrado.Accesibilidad , lugarCerrado.ValorMantenimiento ) && !BuscarLugarEnListaLugares(lugarCerrado))
            {
                Lugares.Add(lugarCerrado);
                exito = true;
            }
            return exito;
        }
        //Metodo para ver si existe el lugar CERRADO
        public bool BuscarLugarEnListaLugares(Cerrado lugar)
        {
            int i = 0;
            bool encontrado = false;
            while (i < lugares.Count && !encontrado)
            {
                if (lugares[i].Equals(lugar))
                {
                    encontrado = true;
                }
                i++;
            }
            return encontrado;
        }
        //Metodo para ver si existe el lugar ABIERTO
        public bool BuscarLugarEnListaLugares(Abierto lugar)
        {
            int i = 0;
            bool encontrado = false;
            while (i < lugares.Count && !encontrado)
            {
                if (lugares[i].Equals(lugar))
                {
                    encontrado = true;
                }
                i++;
            }
            return encontrado;
        }

        //Recibe un objeto actividad como parametro y valida que el nombre no este vacío,
        //que la cantidad de me gusta sea mayor a cero, que la edad minima sea una de las cuatro posibles (via funcion),
        //y que los objetos DateTime, Lugar y Categoria no esten vacios
        //Tambien valida via otra funcion que la actividad no este repetida
        //Si todo esta correcto, añade la actividad a la lista
        public bool ValidarYCargarActividad(Actividad act)
        {
            bool exito = false;
            if (act.Nombre.Length > 0 && Actividad.ValidarLimiteEdad(act.EdadMinima) && act.MeGusta >= 0 && act.FechaYhora != null && act.Lugar != null && act.Categoria != null)
            {
                if (VailidarAcividadExistente(act) == null)
                {
                    actividades.Add(act);
                    exito = true;
                }
            }
            return exito;
        }
        //Busca si un objeto funcion recibido por parametro ya se encuetra en la lista de actividades del sistema y lo devuelve
        public Actividad VailidarAcividadExistente(Actividad paramAct)
        {
            Actividad encontrada = null;
            int i = 0;
            while (encontrada == null && i < actividades.Count)
            {
                if (actividades[i].Equals(paramAct))
                {
                    encontrada = actividades[i];
                }
                i++;
            }
            return encontrada;
        }
        //Metodo para validar y cargar categoria
        public bool ValidarYCargarCategoria(Categoria categoria)
        {
            bool exito = false;
            string nombre = categoria.Nombre;
            string descripcion = categoria.Descripcion;

            if (Categoria.ValidarCategoria(nombre, descripcion) && !BuscarCategoria(nombre))
            {
                categorias.Add(categoria);
                exito = true;
            }
            return exito;
        }
        public bool BuscarCategoria(string nombre)
        {
            int i = 0;
            bool exito = false;
            nombre = nombre.ToLower();
            while (!exito && i < categorias.Count)
            {
                if (categorias[i].Nombre.ToLower() == nombre)
                {
                    exito = true;
                }
                i++;
            }
            return exito;
        }

        //Alta usuarios 
        public bool ValidarYCargarUsuarios(Usuario nuevoUsuario)
        {
            bool resultado = false; 

            if ((Usuario.ValidarUsuario(nuevoUsuario.Nombre, nuevoUsuario.Apellido, nuevoUsuario.Email , nuevoUsuario.FechaNac , nuevoUsuario.NombreUsuario , nuevoUsuario.Password)) && (!ValidarUsuario(nuevoUsuario.NombreUsuario)) && (!BuscarEmail(nuevoUsuario.Email)))
            {
                usuarios.Add(nuevoUsuario);
                resultado = true; 
            }

            return resultado;
        }
        //Metodo para devolver Actividad a partir de la ID 
        public Actividad BuscarActividadId (int id)
        {
            Actividad aux = null; 
            foreach(Actividad unA in Actividades)
            {
                if (unA.Id == id )
                {
                    aux = unA; 
                }
            }
            return aux; 
        }

        //Metodo para devolver Usuario sistema - AUXILIAR
        public Usuario BuscarUsuarioId(int id)
        {
            Usuario aux = null;
            foreach (Usuario uS in usuarios)
            {
                if (uS.Id == id)
                {
                    aux = uS;
                    break;
                }
            }
            return aux;
        }

        //Metodo para devolver un usuario a partir del nombre Usuario
        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            nombreUsuario = nombreUsuario.ToLower();
            return usuarios.Find(usuario=>usuario.NombreUsuario.ToLower() == nombreUsuario);
        }

        //Metodo para validar el Usuario sistema - si existe
        public bool ValidarUsuario(string nombreUsuario)
        {
            bool aux = false;
            foreach (Usuario uS in usuarios)
            {
                if (uS.NombreUsuario == nombreUsuario)
                {
                   aux = true;
                   break;
                }
            }
            return aux;
        }
        //Metodo para validar el password del Usuario 
        public bool ValidarPasswordUsuario(string nombreUsuario , string password)
        {
            bool aux = false;
            foreach (Usuario uS in usuarios)
            {
                if (uS.NombreUsuario == nombreUsuario)
                {
                    if(uS.Password == password)
                    {
                        aux = true;
                        break;
                    }
                }
            }
            return aux; 
        }

        //Metodo para buscar nombre de usuario y email ingresados
        public bool BuscarEmail ( string email)
        {
            bool encontrado = false;
            int i = 0;
            while (i<usuarios.Count && !encontrado)
            {
                if(usuarios[i].Email == email)
                {
                    encontrado = true; 
                }
                i++;
            }

            return encontrado;
        }
        //Metodo para validar y cargar un compra
        public bool ValidarYCargarCompra(Compra unaCompra)

        {
            bool resultado = false;
            
            if (actividades.Contains(unaCompra.Actividad) && usuarios.Contains(unaCompra.Usuario) )
            {
                if (Compra.ValidarCompra(unaCompra.Actividad, unaCompra.CantidadEntradas, unaCompra.FechaYhora, unaCompra.Usuario))
                {
                    compras.Add(unaCompra);
                    resultado = true;
                }
            }
            
            return resultado; 
        }
        //Clonar la lista de actividades  - Para proteger la lista original
        public List<Actividad> ClonarListaActividades()
        {
            List<Actividad> aux = new List<Actividad>();

            foreach (Actividad unaActividad in actividades)
            {
                aux.Add(unaActividad);
            }

            return aux;
        }
        //Lista en consola todas las actividades registradas en el sistema (Nombre,categoria,lugar,etc)
        public string ListarActividades(List<Actividad> listaActividades )
        {
            string textoListaActividades = "";
            if (listaActividades.Count == 0)
            {
                textoListaActividades = "\n No hay actividades para mostrar \n";
            } 
            else
            {
                foreach (Actividad act in listaActividades)
                {
                    textoListaActividades += act.ToString();
                    textoListaActividades += "\n";
                }
            }
            return textoListaActividades;
        }
        
        //Metodo - Dada una categoría, listar las actividades de esa categoría que se realicen en un rango de fechas dado
        public List<Actividad> ListarActividadesPorFechaYCategoria(int idCategoria , DateTime fechaInicio, DateTime fechaFinal)
        {
            List<Actividad> listaActividades = new List<Actividad>() ;

            fechaInicio = fechaInicio.Date;
            fechaFinal = fechaFinal.Date;

            foreach (Actividad unaActividad in actividades)
            {
                if ((unaActividad.Categoria.Id == idCategoria) && (CompararFechas(unaActividad.FechaYhora , fechaInicio , fechaFinal)))
                {
                    listaActividades.Add(unaActividad);
                }

            }
            return listaActividades;
        }
        //Metodo para Agregar un Me Gusta en las actividades presentes
        public bool BuscarActividadYAgregarMegusta (int idActividad)
        {
            bool resultado = false;
            Actividad actividadSelecionada = BuscarActividadId(idActividad);

            if (actividades.Contains(actividadSelecionada))
            {
                actividadSelecionada.AgregarMeGusta();
                resultado = true;
            }

            return resultado; 
        }
        //Metodo para comprar si una fecha esta dentro de un rango
        public bool CompararFechas(DateTime fechaActividad , DateTime fechaInicial , DateTime fechaFinal) 
        {
            bool resultado = false;
            if ((fechaActividad.Date>=fechaInicial.Date) && (fechaActividad.Date<=fechaFinal.Date))
            {
                resultado = true;
            }
            return resultado; 
        }
        
        //Cambia el aforo maximo de los lugares cerrados a un aforo recibido por parametro
        public bool CambiarAforoMaximo(int nuevoAforoMaximo)
        {
            bool exito = false;
            if (Cerrado.ValidarAforo(nuevoAforoMaximo))
            {
                Cerrado.CambiarAforo(nuevoAforoMaximo);
                exito = true;
            }
            return exito;
        }
        //Cambia el precio de las butacas de los lugares abiertos a un precio recibido por parametro
        public bool CambiarPrecioButaca(decimal nuevoPrecio)
        {
            bool exito = false;
            if (Abierto.ValidarPrecioButaca(nuevoPrecio))
            {
                Abierto.CambiarPrecioButaca(nuevoPrecio);
                exito = true;
            }
            return exito;
        }
        public void PrecargaAforoYprecioButaca()
        {
            CambiarAforoMaximo(100);
            CambiarPrecioButaca(200);
        }
        //Devuelve una lista de las actividades cuya de edad minima sea apto para todo publico (P)
        public List<Actividad> ActividadesParaTodoPublico()
        {
            List<Actividad> actividadesTodoPublico = new List<Actividad>();
            foreach (Actividad act in actividades)
            {
                if (act.EdadMinima == "P")
                {
                    actividadesTodoPublico.Add(act);
                }
            }
            return actividadesTodoPublico;
        }

        //Validar formato de fecha
        public bool ValidarFormatoFecha(int anio, int mes ,int dia)
        {
            bool resultado = false; 
            if (dia > 0 && dia <32)
            {
                if (mes > 0 && mes <13)
                {
                    if (anio > 1000 && anio <10000)
                    {
                        resultado = true; 
                    }
                }
            }
            return resultado; 
        }
        //Metodo para listar las categorias existentes 
        public string ListarCategorias()
        {
            string listaCategorias = "";
            for (int i = 0; i< categorias.Count; i++)
            {
                listaCategorias += $"{i+1} - {categorias[i].Nombre}\n";
            }
            return listaCategorias;
        }

        //Metodo para listar con mayor valor de compra
        public List<Compra> ComprasMayorValor()
        {
            List<Compra> aux = new List<Compra>();
            decimal max = decimal.MinValue;
            foreach (Compra unC in compras)
            {
                if (unC.Estado)
                {
                    decimal valorCompra = unC.PrecioFinal;
                    if (valorCompra > max)
                    {
                        aux.Clear();
                        aux.Add(unC);
                        max = valorCompra;
                    }
                    else if (valorCompra == max)
                    {
                        aux.Add(unC);
                    }
                }
            }
            return aux;
        }

        //Metodo para listar usuarios por nombre
        public List<Usuario> UsuariosOrdenadosPorNombre()
        {
            List<Usuario> aux = new List<Usuario>();
            foreach (Usuario item in usuarios)
            {
                aux.Add(item);
            }
            aux.Sort();
            return aux;
        }

        //Metodo para obtener compra
        public Compra ObtenerCompra(int idCompra)
        {
            Compra encontrada = null;
            foreach (Compra unC in compras)
            {
                if (unC.Id == idCompra)
                {
                    encontrada = unC;
                }
            }
            return encontrada;
        }

        //Metodo lista de compras por usuario
        public List<Compra> ComprasActivasPorUsuario(int idUsuario)
        {
            List<Compra> aux = new List<Compra>();
            foreach (Compra unC in compras)
            {
                if (unC.ObtenerCliente().ObtenerId() == idUsuario && unC.Estado == true && (unC.Actividad.DevolverFecha() - DateTime.Now).TotalHours > 24)
                {
                    aux.Add(unC);
                }
            }
            return aux;
        }

        //Metodo para Actividades por Lugar
        public List<Actividad> ActividadesPorLugar(int idLugar)
        {
            List<Actividad> aux = new List<Actividad>();
            foreach (Actividad unA in actividades)
            {
                if (unA.Lugar.Id == idLugar)
                {
                    aux.Add(unA);
                }
            }
            return aux;
        }


        //Listar Compras totales realizadas por un usuario dado
        public List<Compra> ListarComprasPorUsuario (Usuario usuarioSeleccionado)
        {
            List<Compra> aux = new List<Compra>();

            foreach (Compra unC in compras)
            {
                if(usuarioSeleccionado.Equals(unC.Usuario))
                {
                    aux.Add(unC);
                }
            }

            return aux;
        }

        //Metodo para filtrar las compras realizadas en un rango de fechas
        public List<Compra> FiltroComprasPorFechas(DateTime desde, DateTime hasta)
        {
            List<Compra> aux = new List<Compra>();

            foreach (Compra unC in compras)
            {
                if (CompararFechas(unC.FechaYhora.Date , desde.Date , hasta.Date) && unC.Estado)
                {
                    aux.Add(unC);
                }
            }
            return aux;
        }
        //Metodo para Devolver el total de las compras realizadas a partir de una lista de compras
        public decimal TotalComprasRealizadas(List<Compra> listaCompras )
        {
            decimal total = 0;

            foreach (Compra unC in listaCompras)
            {
                if (unC.Estado)
                {
                    total += unC.PrecioFinal; 
                }
            }
            return total; 
        }
    }
}
