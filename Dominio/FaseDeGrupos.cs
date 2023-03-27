using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FaseDeGrupos : Partido
    {
        #region Atributos
        public string NombreDelGrupo { get; set; }
        #endregion

        #region Constructores
        public FaseDeGrupos()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public FaseDeGrupos(string nombreDelGrupo, Seleccion seleccion1, Seleccion seleccion2, DateTime fechaYHoraDelPartido, bool finalizado, string resultadoDelPartido): base(seleccion1, seleccion2, fechaYHoraDelPartido, finalizado, resultadoDelPartido)
        {
            Id = UltimoId;
            UltimoId++;
            NombreDelGrupo = nombreDelGrupo;
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
            if (golesSeleccion1 == golesSeleccion2)
            {
                return "Empate";
            }
            else if (golesSeleccion1 > golesSeleccion2)
            {
                return "Ganador: " + Seleccion1.UnPais.Nombre;
            }
            else 
            {
                return "Ganador: " + Seleccion2.UnPais.Nombre;
            }
        }

        public override string ToString()
        {
            return "Grupo " + NombreDelGrupo + "\n" + base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is FaseDeGrupos grupos &&
                   base.Equals(obj) &&
                   EqualityComparer<Seleccion>.Default.Equals(Seleccion1, grupos.Seleccion1) &&
                   EqualityComparer<Seleccion>.Default.Equals(Seleccion2, grupos.Seleccion2) &&
                   FechaYhoraDelPartido == grupos.FechaYhoraDelPartido;
        }

        /// <summary>
        /// Metodo abstract que devuelve el tipo de partido
        /// </summary>
        /// <returns></returns>
        public override string GetTipo()
        {
            return "Grupos";
        }

        #endregion
    }
}
