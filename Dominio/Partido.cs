using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Partido:IValidar
    {
        #region Atributos
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Seleccion Seleccion1 { get; set; }
        public Seleccion Seleccion2 { get; set; }
        public DateTime FechaYhoraDelPartido { get; set; }
        public bool Finalizado { get; set; } = false;
        public string ResultadoDelPartido { get; set; } = "Pendiente";
        protected List<Incidencia> Incidencias { get;}
        #endregion

        #region Constructores
        public Partido()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Partido(Seleccion seleccion1, Seleccion seleccion2, DateTime fechaYhoraDelPartido, bool finalizado, string resultadoDelPartido)
        {
            Seleccion1 = seleccion1;
            Seleccion2 = seleccion2;
            FechaYhoraDelPartido = fechaYhoraDelPartido;
            Finalizado = finalizado;
            ResultadoDelPartido = resultadoDelPartido;
            Incidencias = new List<Incidencia>();
        }


        #endregion

        #region Metodos
        // Metodo abstract que aun no se usa para calcular el resultado del partido
        public abstract string CalcularResultado();

        /// <summary>
        /// Agregar incidencia de un partido de fase de grupos
        /// </summary>
        /// <param name="unaIncidencia"></param>
        public virtual void AddIncidencia(Incidencia unaIncidencia)
        {
            bool existe = false;
            if (Finalizado)
            {
                throw new Exception("El partido ya finalizó, no puede agregar incidencias");
            }
            else
            {
                try
                {
                    unaIncidencia.Validar();
                    foreach (Jugador j1 in Seleccion1.GetJugadores())
                    {
                        if (j1.NombreCompleto == unaIncidencia.UnJugador.NombreCompleto)
                        {
                            existe = true;
                        }
                    }
                    if (!existe)
                    {
                        foreach (Jugador j2 in Seleccion2.GetJugadores())
                        {
                            if (j2.NombreCompleto == unaIncidencia.UnJugador.NombreCompleto)
                            {
                                existe = true;
                            }
                        }
                    }
                }
                catch (Exception except)
                {

                    throw new Exception (except.Message);
                }
                try
                {
                    if (existe)
                    {
                        if (unaIncidencia.Minuto >= 0)
                        {
                            Incidencias.Add(unaIncidencia);
                        }
                        else
                        {
                            throw new Exception("Minuto incorrecto en la incidencia");
                        }
                    }
                    else
                    {
                        throw new Exception("El jugador agregado no pertenece a los seleccionados del partido");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        /// <summary>
        /// Devuelve lista de incidencias de un partido
        /// </summary>
        /// <returns></returns>
        public List<Incidencia> GetIncidencias() 
        {
            return Incidencias;
        }

        /// <summary>
        /// Devuelve el string con las incidencias de un partido
        /// </summary>
        /// <returns></returns>
        public string MostrarIncidencias() 
        {
            string incidencias = "";
            foreach (Incidencia i in Incidencias)
            {
                incidencias += i.TipoIncidencia + " / " + i.Minuto + " / " + i.UnJugador.NombreCompleto + "\n";
            }
            return incidencias;
        }

        /// <summary>
        /// Devuelve cantidad de goles de un partido
        /// </summary>
        /// <returns></returns>
        public int GetGoles()
        {
            int cantidadGoles = 0;
            foreach (Incidencia unaIncidencia in GetIncidencias())
            {
                if (unaIncidencia.TipoIncidencia == "Gol" && unaIncidencia.Minuto != -1)
                {
                    cantidadGoles++;
                }
            }
            return cantidadGoles;
        }

        public override string ToString()
        {
            return "Partido: " + Seleccion1.UnPais.Nombre + " vs " + Seleccion2.UnPais.Nombre + "\n" + "Incidencias: \n" + MostrarIncidencias();
        }

        /// <summary>
        /// Valida un partido y sus atributos
        /// </summary>
        public void Validar()
        {
            if (Seleccion1 == null || Seleccion2 == null)
            {
                throw new Exception("Debe ingresar dos selecciones");
            }
            if (FechaYhoraDelPartido < new DateTime(2022, 11, 20) || FechaYhoraDelPartido > new DateTime(2022, 12, 18))
            {
                throw new Exception("La fecha del partido debe estar comprendida entre el 20/11/2022 y el 18/12/2022");
            }
        }
        public override bool Equals(object obj)
        {
            return obj is Partido partido &&
                   EqualityComparer<Seleccion>.Default.Equals(Seleccion1, partido.Seleccion1) &&
                   EqualityComparer<Seleccion>.Default.Equals(Seleccion2, partido.Seleccion2) &&
                   FechaYhoraDelPartido == partido.FechaYhoraDelPartido;
        }

        /// <summary>
        /// Metodo abstract que devuelve el tipo de partido
        /// </summary>
        /// <returns></returns>
        public abstract string GetTipo();

        /// <summary>
        /// Metodo que devuelve la cantidad de goles de una seleccion en un partido
        /// </summary>
        /// <param name="sel"></param>
        /// <returns></returns>
        public string StringGetGoles(Seleccion sel)
        {
            string Goles = "";
            int contador = 0;
            foreach (Incidencia i in Incidencias)
            {
                foreach (Jugador jug in sel.GetJugadores())
                {
                    if (i.UnJugador == jug)
                    {
                        if (i.TipoIncidencia == "Gol")
                        {
                            contador++;
                            if (contador != 1)
                            {
                                Goles += " / ";
                            }
                            Goles += "(" + contador + ") Jugador: " + i.UnJugador.NombreCompleto + " - Minuto: ";
                            
                              if (i.Minuto != -1) 
                            {
                                Goles += i.Minuto;
                            } else 
                            {
                                Goles += " gol de penal";
                            }
                        }
                    }
                }

            }
            if (contador == 0)
            {
                return "Ninguno";
            }
            return Goles;
        }

        /// <summary>
        /// Metodo que devuelve la cantidad de amarillas de una seleccion en un partido
        /// </summary>
        /// <param name="sel"></param>
        /// <returns></returns>
        public string GetAmarillas(Seleccion sel)
        {
            string Amarillas = "";
            int contador = 0;
            foreach (Incidencia i in Incidencias)
            {
                foreach (Jugador jug in sel.GetJugadores())
                {
                    if (i.UnJugador == jug)
                    {
                        if (i.TipoIncidencia == "Amarilla")
                        {
                            contador++;
                            if (contador != 1)
                            {
                                Amarillas += " / ";
                            }
                            Amarillas += "(" + contador + ") Jugador: " + i.UnJugador.NombreCompleto + " - Minuto: " + i.Minuto;
                        }
                    }
                }
            }
            if (contador == 0)
            {
                return "Ninguna";
            }
            return Amarillas;
        }

        /// <summary>
        /// Metodo que devuelve la cantidad de rojas de una seleccion en un partido
        /// </summary>
        /// <param name="sel"></param>
        /// <returns></returns>
        public string GetRojas(Seleccion sel)
        {
            string Rojas = "";
            int contador = 0;
            foreach (Incidencia i in Incidencias)
            {
                foreach (Jugador jug in sel.GetJugadores())
                {
                    if (i.UnJugador == jug)
                    {
                        if (i.TipoIncidencia == "Roja")
                        {
                            contador++;
                            if (contador != 1)
                            {
                                Rojas += " / ";
                            }
                            Rojas += "(" + contador + ") Jugador: " + i.UnJugador.NombreCompleto + " - Minuto: " + i.Minuto;
                        }
                    }
                }

            }
            if (contador == 0)
            {
                return "Ninguna";
            }
            return Rojas;
        }
        #endregion
    }
}
