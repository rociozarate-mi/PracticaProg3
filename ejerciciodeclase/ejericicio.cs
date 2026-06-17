using System;

namespace PracticaProg3
{
    public class Ejercicio
    {
        public static void Main(string[] args)
        {
            string nombre;
            int edad;

            for (int i = 0; i < 20; i++)
            {
                Console.Write("Ingrese el nombre de la persona " + (i + 1) + ": ");
                nombre = Console.ReadLine();

                Console.Write("Ingrese la edad de " + nombre + ": ");
                edad = int.Parse(Console.ReadLine());

                if (edad > 30)
                {
                    Console.WriteLine(nombre + " puede pasar");
                }
                else
                {
                    Console.WriteLine(nombre + " a la casa");
                }
            }
        }
    }

}
