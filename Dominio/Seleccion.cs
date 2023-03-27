using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Seleccion: IValidar, IComparable<Seleccion>
    {
        #region Atributos
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Pais UnPais { get; set; }
        private List<Jugador> ListaDeJugadores { get;}
        #endregion

        #region Constructores
        public Seleccion()
        {
            Id = UltimoId;
            UltimoId++;
            ListaDeJugadores = new List<Jugador>();
        }

        public Seleccion(Pais unPais)
        {
            Id = UltimoId;
            UltimoId++;
            UnPais = unPais;
            ListaDeJugadores = new List<Jugador>(); 
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para validar una seleccion
        /// </summary>
        public void Validar() 
        {
            if (UnPais == null)
            {
                throw new Exception("El pais no debe ser vacío");
            }
            if (ListaDeJugadores.Count < 11)
            {
                throw new Exception("La lista de jugadores no puede ser menor a 11");
            }
        }

        /// <summary>
        /// Metodo para mostrar un seleccion y sus jugadores
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Pais: " + UnPais.Nombre + " Lista de jugadores: \n" + AddJugadores();
        }

        /// <summary>
        /// Metodo para hacer una lista de jugadores que luego se muestra en el ToString de selecciones
        /// </summary>
        /// <returns></returns>
        public string AddJugadores()
        {
            string listaJugadores = "";
            foreach (Jugador unJugador in ListaDeJugadores)
            {
                listaJugadores += unJugador.NombreCompleto + "\n";
            }
            return listaJugadores;
        }

        /// <summary>
        /// Agrega jugadores a la lista de la seleccion
        /// </summary>
        /// <param name="unJugador"></param>
        public void AgregarJugador(Jugador unJugador) 
        {
            try
            {
                if (!ListaDeJugadores.Contains(unJugador))
                {
                    ListaDeJugadores.Add(unJugador);
                }
                else 
                {
                    throw new Exception("El jugador ya esta en la lista");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Devuelve la lista de jugadores de la seleccion
        /// </summary>
        /// <returns></returns>
        public List<Jugador> GetJugadores()
        {
            return ListaDeJugadores;
        }

        public override bool Equals(object obj)
        {
            return obj is Seleccion seleccion &&
                   EqualityComparer<Pais>.Default.Equals(UnPais, seleccion.UnPais);
        }


        public int CompareTo(Seleccion other)
        {
            if (UnPais.Nombre.CompareTo(other.UnPais.Nombre) > 0)
            {
                return 1;
            }
            else if (UnPais.Nombre.CompareTo(other.UnPais.Nombre) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        #endregion
    }
}
