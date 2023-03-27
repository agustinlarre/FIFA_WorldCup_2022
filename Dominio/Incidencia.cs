using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Incidencia:IValidar
    {
        #region Atributos
        public int Minuto { get; set; }
        public string TipoIncidencia { get; set; }
        public Jugador UnJugador { get; set; }
        #endregion

        #region Constructores
        public Incidencia()
        {

        }

        public Incidencia(int minuto, string tipoIncidencia, Jugador unJugador)
        {
            Minuto = minuto;
            TipoIncidencia = tipoIncidencia;
            UnJugador = unJugador;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida una incidencia y sus atributos
        /// </summary>
        public void Validar()
        {
            if (UnJugador == null)
            {
                throw new Exception("Debe ingresar al menos algun jugador");
            }
            if (TipoIncidencia != "Amarilla" && TipoIncidencia != "Roja" && TipoIncidencia != "Gol")
            {
                throw new Exception("Incidencia inexistente");
            }
            if (Minuto < -1)
            {
                throw new Exception("Minuto incorrecto");
            }
        }

        public override string ToString()
        {
            return "Incidencia: " + " Minuto - " + Minuto + " / Tipo de incidencia - " + TipoIncidencia + " / Jugador - " + UnJugador.NombreCompleto + " / ";
        }
        #endregion
    }
}
