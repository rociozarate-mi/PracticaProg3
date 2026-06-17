namespace Programa02;

class Program
{
    static void Main(string[] args)
    {
            Console.WriteLine("--- BLOQUE 1: NÚMEROS ENTEROS ---");

            // Declaración de un entero
            int edad = 28;

            Console.WriteLine("1. TIPO ENTERO (int):");
            Console.WriteLine("   Para números sin decimales, como edad o cantidad.");
            Console.WriteLine("   Valor guardado: " + edad);

            Console.WriteLine("\nPresiona ENTER para cerrar.");
            Console.ReadLine();
            //suma de enteros
            Console.WriteLine("Sumar dos números enteros:");
            Console.Write("Ingresa el primer número: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Ingresa el segundo número: ");
            int num2 = int.Parse(Console.ReadLine());
            int suma = num1 + num2;
            Console.WriteLine("La suma es: " + suma);   

            //reta de enteros   
            Console.WriteLine("Restar dos números enteros:");
            Console.Write("Ingresa el primer número: ");
            int num3 = int.Parse(Console.ReadLine());
            Console.Write("Ingresa el segundo número: ");
            int num4 = int.Parse(Console.ReadLine());
            int resta = num3 - num4;
            Console.WriteLine("La resta es: " + resta);

            //multiplicacion de enteros
            Console.WriteLine("Multiplicar dos números enteros:");
            Console.Write("Ingresa el primer número: ");
            int num5 = int.Parse(Console.ReadLine());
            Console.Write("Ingresa el segundo número: ");
            int num6 = int.Parse(Console.ReadLine());
            int multiplicacion = num5 * num6;
            Console.WriteLine("La multiplicación es: " + multiplicacion);

            //sumar las edades de dos personas
            Console.WriteLine("Sumar las edades de dos personas:");
            Console.Write("Ingresa la edad de la primera persona: ");
            int edad1 = int.Parse(Console.ReadLine());
            Console.Write("Ingresa la edad de la segunda persona: ");
            int edad2 = int.Parse(Console.ReadLine());
            int sumaEdades = edad1 + edad2;
            Console.WriteLine("La suma de las edades es: " + sumaEdades);

            //restar las edades de dos personas
            Console.WriteLine("Restar las edades de dos personas:");
            Console.Write("Ingresa la edad de la primera persona: ");
            int edad3 = int.Parse(Console.ReadLine());
            Console.Write("Ingresa la edad de la segunda persona: ");
            int edad4 = int.Parse(Console.ReadLine());
            int restaEdades = edad3 - edad4;
            Console.WriteLine("La resta es: " + restaEdades);





            

    }
}