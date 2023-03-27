using System;
namespace Dominio
{
    public class Operador: Usuario
    {
        #region Atributos
        public DateTime FechaTra { get; set; }
        #endregion

        #region Constructores
        public Operador()
        {
        }

        public Operador(string unNombre, string unApellido, string unEmail, string unaPassword, DateTime unaFechaTra) : base(unNombre, unApellido, unEmail, unaPassword)
        {
            FechaTra = unaFechaTra;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que le devuelve el tipo de Usuario
        /// </summary>
        /// <returns></returns>
        public override string GetTipo()
        {
            return "Operador";
        }

        public override string ToString()
        {
            return base.ToString() + " - Fecha que comenzó a trabajar: " + FechaTra;
        }
        #endregion
    }
}

