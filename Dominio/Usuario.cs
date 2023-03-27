using System;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public abstract class Usuario: IValidar
    {
        #region Atributos
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructores
        public Usuario()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Usuario(string unNombre, string unApellido, string unEmail, string unaPassword)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = unNombre;
            Apellido = unApellido;
            Email = unEmail;
            Password = unaPassword;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Validacion de un periodista y sus atributos
        /// </summary>
        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Apellido) || String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Password))
            {
                throw new Exception("Alguno de los datos del usuario es vacío, compruebe lo ingresado");
            }
            if (Email.IndexOf("@") == -1)
            {
                throw new Exception("El email debe contener el caracter @");
            }
            if (Email.IndexOf("@") == 0)
            {
                throw new Exception("El @ del email no debe estar en la primera posición");
            }
            if (Email.IndexOf("@") == Email.Length - 1)
            {
                throw new Exception("El @ del email no debe estar en la ultima posición");
            }
            if (Password.Length < 8)
            {
                throw new Exception("La password debe tener al menos 8 caracteres");
            }
        }

        /// <summary>
        /// Metodo abstract para saber el tipo de Usuario
        /// </summary>
        /// <returns></returns>
        public abstract string GetTipo();

        public override bool Equals(object obj)
        {
            return obj is Usuario usuario &&
                   Email == usuario.Email;
        }

        public override string ToString()
        {
            return "Nombre: " + Nombre + " - Apellido: " + Apellido + " - Email: " + Email;
        }

        #endregion
    }
}

