using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pais: IValidar
    {
        #region Atributos
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string CodigoAlpha3 { get; set; }
        #endregion

        #region Constructores
        public Pais()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Pais(string nombre, string codigoAlpha3)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            CodigoAlpha3 = codigoAlpha3;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida al Pais y sus atributos
        /// </summary>
        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre del pais no debe ser vacío");
            }
            if (CodigoAlpha3.Length != 3)
            {
                throw new Exception("El Codigo Alpha debe ser de 3 digitos");
            }
        }
        public override string ToString()
        {
            return "Nombre: " + Nombre + " / Codigo Alpha: " + CodigoAlpha3;
        }

        public override bool Equals(object obj)
        {
            return obj is Pais pais &&
                   Nombre == pais.Nombre &&
                   CodigoAlpha3 == pais.CodigoAlpha3;
        }


        #endregion
    }
}
