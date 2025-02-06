
/*Matricula: 2023-1089
Nombre: Yoelvyn Perez Feliz
Dia de Clases: Sabados de 9:00 am a 12:00pm*/


using System;
using System.Collections.Generic;

namespace Practica1_Programacion2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int select;
            var docentes = new Docente();
            var administrativo = new Administrativo();
            var maestro = new Maestro();
            var admin = new Administrador();
            var empleado = new Empleado();
            var vistas = new Vistas();
            List<MiembrosDeLaComunidad> listaMiembros = new List<MiembrosDeLaComunidad>();

            vistas.MenuInicio();
            string continuar = Console.ReadLine();

            while (true)
            {
                MostrarMenuPrincipal(vistas);
                int tarea = ObtenerEntradaEntera("Seleccione el número que indica según la tarea que necesita realizar:");

                switch (tarea)
                {
                    case 1:
                        RegistrarMiembros(vistas, listaMiembros, admin, maestro, administrativo);
                        break;
                    case 2:
                        VerMiembros(vistas, listaMiembros, docente, maestro, admin, empleado, administrativo);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                Console.WriteLine("¿Desea continuar (s/n)?");
                continuar = Console.ReadLine();
                if (continuar.ToLower() != "s")
                {
                    break;
                }
                Console.Clear();
            }
        }

        static void MostrarMenuPrincipal(Vistas vistas)
        {
            Console.Clear();
            vistas.MostrarMenu();
        }

        static int ObtenerEntradaEntera(string mensaje)
        {
            int entrada;
            Console.WriteLine(mensaje);
            while (!int.TryParse(Console.ReadLine(), out entrada))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
            }
            return entrada;
        }

        static void RegistrarMiembros(Vistas vistas, List<MiembrosDeLaComunidad> listaMiembros, Administrador admin, Maestro maestro, Administrativo administrativo)
        {
            Console.Clear();
            vistas.MenuRegistro();
            int select = ObtenerEntradaEntera("Seleccione el tipo de miembro a registrar:");

            switch (select)
            {
                case 1:
                    RegistrarEmpleados(vistas, listaMiembros, admin, maestro);
                    break;
                case 2:
                    administrativo.Registrar(listaMiembros);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        static void RegistrarEmpleados(Vistas vistas, List<MiembrosDeLaComunidad> listaMiembros, Administrador admin, Maestro maestro)
        {
            Console.Clear();
            vistas.RegistroEmpleado();
            int select = ObtenerEntradaEntera("Seleccione el tipo de empleado:");

            switch (select)
            {
                case 1:
                    admin.Registrar(listaMiembros);
                    break;
                case 2:
                    maestro.Registrar(listaMiembros);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        static void VerMiembros(Vistas vistas, List<MiembrosDeLaComunidad> listaMiembros, Docente docente, Maestro maestro, Administrador admin, Empleado empleado, Administrativo administrativo)
        {
            Console.Clear();
            vistas.VerMiembros();
            int select = ObtenerEntradaEntera("Seleccione el tipo de miembro a ver:");

            switch (select)
            {
                case 1:
                    listaMiembros.ForEach(m => m.Ver(listaMiembros));
                    break;
                case 2:
                    VerEmpleados(vistas, listaMiembros, docente, maestro, admin, empleado, administrativo);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        static void VerEmpleados(Vistas vistas, List<MiembrosDeLaComunidad> listaMiembros, Docente docente, Maestro maestro, Administrador admin, Empleado empleado, Administrativo administrativo)
        {
            Console.Clear();
            vistas.VerEmpleados();
            int select = ObtenerEntradaEntera("Seleccione el tipo de empleado:");

            switch (select)
            {
                case 1:
                    empleado.Ver(listaMiembros);
                    break;
                case 2:
                    vistas.VerDocentes();
                    int selectDocente = ObtenerEntradaEntera("Seleccione el tipo de docente:");
                    if (selectDocente == 1)
                    {
                        docente.Ver(listaMiembros);
                    }
                    else if (selectDocente == 2)
                    {
                        maestro.Ver(listaMiembros);
                    }
                    else if (selectDocente == 3)
                    {
                        admin.Ver(listaMiembros);
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida");
                    }
                    break;
                case 3:
                    administrativo.Ver(listaMiembros);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }
}