using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FaseEliminatoria : Partido
    {
        #region Atributos
        public bool Alargue { get; set; }
        public bool Penales { get; set; }
        public Etapa Etapa { get; set; }
        #endregion

        #region Constructores
        public FaseEliminatoria()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public FaseEliminatoria(bool alargue, bool penales, Etapa etapa, Seleccion seleccion1, Seleccion seleccion2, DateTime fechaYhoraDelPartido, bool finalizado, string resultadoDelPartido): base(seleccion1, seleccion2, fechaYhoraDelPartido, finalizado, resultadoDelPartido)
        {
            Id = UltimoId;
            UltimoId++;
            Alargue = alargue;
            Penales = penales;
            Etapa = etapa;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo abstract para calcular el resultado del partido
        /// </summary>
        /// <returns></returns>
        public override string CalcularResultado()
        {
            int golesSeleccion1 = 0;
            int golesSeleccion2 = 0;
            foreach (Incidencia i in Incidencias)
            {
                if (i.TipoIncidencia == "Gol")
                {
                    foreach (Jugador j1 in Seleccion1.GetJugadores())
                    {
                        if (j1 == i.UnJugador)
                        {
                            golesSeleccion1++;
                        }
                    }
                    foreach (Jugador j2 in Seleccion2.GetJugadores())
                    {
                        if (j2 == i.UnJugador)
                        {
                            golesSeleccion2++;
                        }
                    }
                }
            }
            if (golesSeleccion1 > golesSeleccion2 && !Penales && !Alargue)
            {
                return "Ganador en tiempo de juego: " + Seleccion1.UnPais.Nombre;
            }
            else if (golesSeleccion1 < golesSeleccion2 && !Penales && !Alargue)
            {
                return "Ganador en tiempo de juego: " + Seleccion2.UnPais.Nombre;
            }
            else if (golesSeleccion1 > golesSeleccion2 && !Penales && Alargue)
            {
                return "Empate en tiempo de juego. Ganador: " + Seleccion1.UnPais.Nombre + " en alargue";
            }
            else if (golesSeleccion1 < golesSeleccion2 && !Penales && Alargue)
            {
                return "Empate en tiempo de juego. Ganador: " + Seleccion2.UnPais.Nombre + " en alargue";
            }
            else if (golesSeleccion1 > golesSeleccion2 && Penales)
            {
                return "Empate en tiempo de juego. Ganador: " + Seleccion1.UnPais.Nombre + " en tanda de penales";
            }
            else 
            {
                return "Empate en tiempo de juego. Ganador: " + Seleccion2.UnPais.Nombre + " en tanda de penales";
            }
        }

        public override string ToString()
        {
            return "Etapa: " + Etapa + "\n" + base.ToString();
        }
 
        /// <summary>
        /// Metodo sobreescrito para Agregar una incidencia con su coprrespondiente validación
        /// </summary>
        /// <param name="unaIncidencia"></param>
        public override void AddIncidencia(Incidencia unaIncidencia)
        {
            bool existe = false;

            if (Finalizado)
            {
                throw new Exception("El partido ya finalizó, no puede agregar incidencias");
            }
            else
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
                try
                {
                    if (existe)
                    {
                        if (Penales == true)
                        {
                            Incidencias.Add(unaIncidencia);
                        }
                        else
                        {
                            if (unaIncidencia.Minuto >= 0)
                            {
                                Incidencias.Add(unaIncidencia);
                            }
                            else
                            {
                                throw new Exception("Minuto incorrecto");
                            }
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

        public override bool Equals(object obj)
        {
            return obj is FaseEliminatoria eliminatoria &&
                   base.Equals(obj) &&
                   EqualityComparer<Seleccion>.Default.Equals(Seleccion1, eliminatoria.Seleccion1) &&
                   EqualityComparer<Seleccion>.Default.Equals(Seleccion2, eliminatoria.Seleccion2) &&
                   FechaYhoraDelPartido == eliminatoria.FechaYhoraDelPartido;
        }

        /// <summary>
        /// Metodo abstract que devuelve el tipo de partido
        /// </summary>
        /// <returns></returns>
        public override string GetTipo()
        {
            return "Eliminatoria";
        }
        #endregion
    }
}
