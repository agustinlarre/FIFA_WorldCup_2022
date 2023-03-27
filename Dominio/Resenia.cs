using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Resenia: IValidar, IComparable<Resenia>
    {
        #region Atributos
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Periodista UnPeriodista { get; set; }
        public DateTime Fecha { get; set; }
        public Partido UnPartido { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        #endregion

        #region Constructores
        public Resenia()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Resenia(Periodista periodista, DateTime fecha, Partido unPartido, string titulo, string contenido)
        {
            Id = UltimoId;
            UltimoId++;
            UnPeriodista = periodista;
            Fecha = fecha;
            UnPartido = unPartido;
            Titulo = titulo;
            Contenido = contenido;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Validacion de los atributos de la reseña
        /// </summary>
        public void Validar()
        {
            if (String.IsNullOrEmpty(Contenido) || String.IsNullOrEmpty(Titulo))
            {
                throw new Exception("El titulo o el contenido no debe ser vacío");
            }
            if (UnPeriodista == null)
            {
                throw new Exception("Debe ingresar un periodista");
            }
            if (UnPartido == null) 
            {
                throw new Exception("Debe ingresar un partido");
            }
        }

        /// <summary>
        /// Metodo que te devuelve el nombre del grupo de un partido de fase de grupos de una reseña
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public string ObtenerGrupoDelPartido(Resenia res) 
        {
            if (res.UnPartido.GetTipo() == "Grupos")
            {
                FaseDeGrupos aux = res.UnPartido as FaseDeGrupos;
                string nombre = aux.NombreDelGrupo;
                return nombre;
            }
            return null;
        }
       
        public override string ToString()
        {
            return "Periodista: " + UnPeriodista.Nombre + UnPeriodista.Apellido + "\nFecha: " + Fecha + "\nPartido: " + UnPartido.Seleccion1.UnPais.Nombre + " vs " + UnPartido.Seleccion2.UnPais.Nombre + "\nTItulo de Reseña: " + Titulo + "\nContenido: " + Contenido;
        }

        public int CompareTo([AllowNull] Resenia other)
        {
            if (Fecha.CompareTo(other.Fecha) > 0)
            {
                return -1;
            }
            else if (Fecha.CompareTo(other.Fecha) < 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        #endregion
    }
}
