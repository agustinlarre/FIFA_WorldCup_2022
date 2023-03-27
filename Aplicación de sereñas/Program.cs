using System;
using System.Collections.Generic;
using Dominio;

namespace Aplicación_de_sereñas
{
    class Program
    {
        static void Main(string[] args)
        {

            Sistema sistema = Sistema.Instancia;
            int opciones = 1;

            while (opciones !=0)
            {
                try
                {
                    Console.Clear();
                    // MENU
                    Console.WriteLine("////////////////////MENU///////////////////");
                    Console.WriteLine("1 - Alta de periodista");
                    Console.WriteLine("2 - Asignar nuevo valor de categoria financiera");
                    Console.WriteLine("3 - Ver los partidos de un jugador por su ID");
                    Console.WriteLine("4 - Ver el listado de jugadores que fueron expulsados");
                    Console.WriteLine("5 - Ver el partido con mas goles de una seleccion");
                    Console.WriteLine("6 - Listado de jugadores con al menos un gol en un partido por su ID");
                    Console.WriteLine("0 - Salir del programa");
                    opciones = Int32.Parse(Console.ReadLine());

                    switch (opciones)
                    {
                        case 1:
                            //ALTA DE UN PERIODISTA
                            bool periodistaCreado = false;
                            while (!periodistaCreado)
                            {
                                Console.Clear();
                                Console.WriteLine("////////////////////NUEVO PERIODISTA////////////////");
                                Console.WriteLine("Ingrese su nombre");
                                string nombrep1 = Console.ReadLine();
                                Console.WriteLine("Ingrese su apellido");
                                string apellidop1 = Console.ReadLine();
                                Console.WriteLine("Ingrese su email");
                                string emailp1 = Console.ReadLine();
                                Console.WriteLine("Ingrese su password con al menos 8 caracteres");
                                string passwordp1 = Console.ReadLine();
                                Periodista p2 = new Periodista(nombrep1, apellidop1, emailp1, passwordp1);
                                try
                                {
                                    sistema.AltaPeriodista(p2);
                                    periodistaCreado = true;
                                    Console.WriteLine("Periodista creado correctamente");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            //ASIGNAR VALOR A CATEGORIA FINANCIERA
                            bool montoCorrecto = false;

                            while (!montoCorrecto)
                            {
                                Console.Clear();
                                Console.WriteLine("/////////////////CAMBIAR MONTO ESTANDAR//////////////");
                                Console.WriteLine("Ingrese un monto estandar para definir jugador VIP o Estandar");
                                try
                                {
                                    string monto = Console.ReadLine();
                                    sistema.cambiarMontoEstandar(monto);
                                    montoCorrecto = true;
                                    Console.WriteLine("Monto ingresado correctamente");
                                    Console.WriteLine("");
                                    Jugador Suarez = sistema.GetJugador("Luis Suárez");
                                    Console.WriteLine("Ejemplo: Nombre: " + Suarez.NombreCompleto + " / " + "Categoría financiera: " + Suarez.TipoCategoriaFinanciera);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            // VER LOS PARTIDOS DE UN JUGADOR POR SU ID
                            bool idCorrecto = false;
                            while (!idCorrecto)
                            {
                                Console.Clear();
                                Console.WriteLine("///////////PARTIDOS DE UN JUGADOR////////////");
                                Console.WriteLine("Ingrese Id del jugador y conozca sus partidos");
                                try
                                {
                                    int idJugador = Int32.Parse(Console.ReadLine());
                                    try
                                    {

                                        List<Partido> listaPartidos = sistema.ListaDePartidosJugador(idJugador);
                                        int contador = 0;
                                        bool primeraVuelta = true;
                                        foreach (Partido p in listaPartidos)
                                        {
                                            foreach (Incidencia i in p.GetIncidencias())
                                            {
                                                contador++;
                                            }
                                            if (primeraVuelta)
                                            {
                                                Console.WriteLine("Jugador: " + sistema.ObtenerJugadorPorId(idJugador));
                                                primeraVuelta = false;
                                            }
                                            Console.WriteLine("\nFecha: " + p.FechaYhoraDelPartido + "\n" + "Selecciones participantes: " + p.Seleccion1.UnPais.Nombre + " vs " + p.Seleccion2.UnPais.Nombre + "\n" + "Cantidad de incidencias: " + contador);
                                            contador = 0;
                                        }
                                        if (listaPartidos.Count == 0)
                                        {
                                            Console.WriteLine("Jugador: " + sistema.ObtenerJugadorPorId(idJugador));
                                            Console.WriteLine("\nEl jugador no participo en ningun partido");
                                        }

                                        idCorrecto = true;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("Id incorrecto, Debe ingresar numeros");
                                }
                                
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            // JUGADORES EXPULSADOS AL MENOS UNA VEZ
                            Console.Clear();
                            Console.WriteLine("/////////////LISTADO DE JUGADORES EXPULADOS/////////////");
                            List<Jugador> jugadoresExpulsados = sistema.GetJugadoresExpulsados();
                            try
                            {
                                if (jugadoresExpulsados.Count == 0)
                                {
                                    Console.WriteLine("No hay jugadores expulsados");
                                }
                                else
                                {
                                    foreach (Jugador j in jugadoresExpulsados)
                                    {
                                        Console.WriteLine(j);
                                    }
                                }
                            }
                            catch (Exception e)
                            {

                                throw new Exception(e.Message);
                            }
                            Console.ReadKey();
                            break;
                        case 5:
                            // PARTIDO CON MAS GOLES DE UNA SELECCION
                            bool seleccionExistente = false;
                            while (!seleccionExistente)
                            {
                                Console.Clear();
                                Console.WriteLine("//////////////PARTIDOS CON MÁS GOLES//////////////");
                                Console.WriteLine("Escriba la seleccion que desee ver su partido con mas goles");
                                string seleccion = Console.ReadLine();
                                int contador2 = 0;
                                Seleccion sele = sistema.GetSeleccion(seleccion);

                                if (sele != null)
                                {
                                    foreach (Partido unPartido in sistema.PartidoConMasGoles(sele))
                                    {
                                        Console.WriteLine(unPartido);
                                        contador2++;
                                    }
                                    seleccionExistente = true;
                                    if (contador2 == 0)
                                    {
                                        Console.WriteLine("La presente seleccion no ha disputado ningun partido");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Seleccion no existente");
                                }
                                Console.ReadKey();
                            }

                            break;
                        case 6:
                            // EJEMPLO DE JUGADORES CON UN GOL
                            bool Valido = false;
                            while (!Valido)
                            {
                                Console.Clear();
                                Console.WriteLine("/////////////JUGADORES CON AL MENOS UN GOL///////////////");
                                Console.WriteLine("Ingrese el id de un partido para saber los jugadores con un gol");
                                try
                                {
                                    int id = Int32.Parse(Console.ReadLine());
                                    Partido unPartido2 = sistema.getPartidoPorSuId(id);
                                    if (unPartido2 != null)
                                    {
                                        List<Jugador> jug = new List<Jugador>(sistema.JugadorConUnGol(id));
                                        Console.WriteLine("El partido es: ");
                                        Console.WriteLine(unPartido2);
                                        Valido = true;
                                        Console.WriteLine("Goles de: ");
                                        if (jug.Count == 0)
                                        {
                                            Console.WriteLine("Nadie ha converido un gol en este partido");
                                        }
                                        else
                                        {
                                            foreach (Jugador j in jug)
                                            {
                                                Console.WriteLine(j.NombreCompleto + " - " + j.ValorMercado + " - " + j.TipoCategoriaFinanciera);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("El partido no existe");
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Debe escribir numeros enteros");
                                }
                                Console.ReadKey();
                            }
                            break;
                        case 0:
                            Console.WriteLine("Salir del programa");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Opcion inexistente");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Solamente se pueden escribir numeros, ingrese nuevamente");
                    Console.ReadKey();
                }   
            }
        }
    }
}
