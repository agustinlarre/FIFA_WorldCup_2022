using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Jugador : IValidar, IComparable<Jugador>
    {
        #region Atributos
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroCamiseta { get; set; } 
        public DateTime FechaDeNacimiento { get; set; }
        public double Altura { get; set; }
        public double ValorMercado { get; set; }
        public string TipoMoneda { get; set; } //Hace referencia al "EUR" de la precarga de jugadores
        public Pais UnPais { get; set; }
        public string PieHabil { get; set; }
        public string Puesto { get; set; }
        public static double MontoEstandar { get; set; } = 1000000;
        public string TipoCategoriaFinanciera { get; set; }
        public bool FueExpulsado { get; set; } = false;
        #endregion

        #region Constructores
        public Jugador()
        {
            TipoCategoriaFinanciera = VerCategoriaFinanciera();
        }

        public Jugador(int unId, string numeroCamiseta, string nombreCompleto, DateTime fechaDeNacimiento, double altura, string pieHabil, double valorMercado, string unTipoMoneda,Pais unPais, string puesto)
        {
            Id = unId;
            NumeroCamiseta = numeroCamiseta;
            NombreCompleto = nombreCompleto;
            FechaDeNacimiento = fechaDeNacimiento;
            Altura = altura;
            ValorMercado = valorMercado;
            TipoMoneda = unTipoMoneda;
            UnPais = unPais;
            PieHabil = pieHabil;
            Puesto = puesto;
            TipoCategoriaFinanciera = VerCategoriaFinanciera();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida un jugador y sus atributos
        /// </summary>
       public void Validar()
        {
            if (String.IsNullOrEmpty(NombreCompleto) || String.IsNullOrEmpty(NumeroCamiseta) || UnPais == null || String.IsNullOrEmpty(PieHabil) || String.IsNullOrEmpty(Puesto) || String.IsNullOrEmpty(TipoCategoriaFinanciera) || String.IsNullOrEmpty(TipoMoneda))
            {
                throw new Exception("Falta completar algun dato del jugador");
            }
            if (ValorMercado < 0) 
            {
                throw new Exception("El valor de mercado no puede ser menor que cero"); // Si bien la letra dice mayor que 0, hay un jugador precargado quie tiene valor 0, entonces cambiamos el metodo. 
            }
        }
        /// <summary>
        /// Permite Ver la categoria financiera en funcion de su valor de mercado
        /// </summary>
        /// <returns></returns>
        public string VerCategoriaFinanciera()
        {
            if (ValorMercado > MontoEstandar)
            {
                return "Vip";
            }
            return "Estandar";
        }

        public override string ToString()
        {
            return "Nombre completo: " + NombreCompleto + " / Numero de camiseta: " + NumeroCamiseta + " / Valor: " + ValorMercado;
        }

        // Ordenamos jugadores por su valor de mercado, y si es el mismo por orden alfabetico segun nombre. No quedo claro segun letra como debe ser el orden.
        public int CompareTo([AllowNull] Jugador other)
        {
            if (ValorMercado.CompareTo(other.ValorMercado) > 0)
            {
                return -1;
            }
            else if (ValorMercado.CompareTo(other.ValorMercado) < 0)
            {
                return 1;
            }
            else
            {
                if (NombreCompleto.CompareTo(other.NombreCompleto) > 0)
                {
                    return 1;
                }
                else if (NombreCompleto.CompareTo(other.NombreCompleto) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Jugador jugador &&
                   NombreCompleto == jugador.NombreCompleto &&
                   NumeroCamiseta == jugador.NumeroCamiseta &&
                   FechaDeNacimiento == jugador.FechaDeNacimiento &&
                   Altura == jugador.Altura &&
                   ValorMercado == jugador.ValorMercado &&
                   TipoMoneda == jugador.TipoMoneda &&
                   EqualityComparer<Pais>.Default.Equals(UnPais, jugador.UnPais) &&
                   PieHabil == jugador.PieHabil &&
                   Puesto == jugador.Puesto;
        }
        #endregion

    }
}

