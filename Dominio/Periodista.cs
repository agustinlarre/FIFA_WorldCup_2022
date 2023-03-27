using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Periodista: Usuario, IComparable<Periodista>
    {
        #region Constructores
        public Periodista()
        {
        }

        public Periodista(string unNombre, string unApellido, string unEmail, string unaPassword): base(unNombre, unApellido, unEmail, unaPassword)
        {
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Metodo que devuelve el tipo de partido
        /// </summary>
        /// <returns></returns>
        public override string GetTipo()
        {
            return "Periodista";
        }

        public int CompareTo([AllowNull] Periodista other)
        {
            if (Apellido.CompareTo(other.Apellido) > 0)
            {
                return 1;
            }
            else if (Apellido.CompareTo(other.Apellido) < 0)
            {
                return -1;
            }
            else
            {
                if (Nombre.CompareTo(other.Nombre) > 0)
                {
                    return 1;
                }
                else if (Nombre.CompareTo(other.Nombre) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }


        #endregion

    }
}
