using System;
using starter.Datos;

namespace Practico.Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PRÁCTICO INTEGRADOR ADO.NET ===");

            Motor motor;

            // RF1: elegir motor por argumento o menú
            if (args.Length > 0)
            {
                motor = ParseMotor(args[0]);
            }
            else
            {
                motor = MenuMotor();
            }

            Console.WriteLine($"\nMotor seleccionado: {motor}\n");

            // Factory (Strategy + Factory)
            IAccesoDatos acceso = FabricaDeMotor.Crear(motor);

            try
            {
                Console.WriteLine("RF2 - Creando estructura...");
                acceso.CrearEstructura();

                Console.WriteLine("RF3 - Insertando datos de prueba...");
                acceso.InsertarDatosPrueba();

                Console.WriteLine("RF4 - Ejecutando operaciones...");
                acceso.EjecutarOperaciones();

                Console.WriteLine("RF5 - Demostrando rollback...");
                acceso.DemostrarRollback();

                Console.WriteLine("\n===== PROCESO FINALIZADO OK =====");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nERROR GENERAL:");
                Console.WriteLine(ex.ToString());
            }
        }

        static Motor MenuMotor()
        {
            Console.WriteLine("\nElegí motor:");
            Console.WriteLine("1 - PostgreSQL");
            Console.WriteLine("2 - SQL Server");
            Console.WriteLine("3 - MySQL");
            Console.Write("Opción: ");

            string? input = Console.ReadLine();

            return input switch
            {
                "1" => Motor.Postgres,
                "2" => Motor.SqlServer,
                "3" => Motor.MySql,
                _ => throw new Exception("Opción inválida")
            };
        }

        static Motor ParseMotor(string arg)
        {
            return arg.ToLower() switch
            {
                "postgres" => Motor.Postgres,
                "postgresql" => Motor.Postgres,
                "sqlserver" => Motor.SqlServer,
                "mysql" => Motor.MySql,
                _ => throw new Exception("Motor inválido en argumentos")
            };
        }
    }
}
