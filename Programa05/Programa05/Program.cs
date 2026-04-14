namespace Programa05;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- BLOQUE 4: VALORES LÓGICOS (SÍ / NO) ---");

            // Booleano (bool) - Solo true o false
            bool cursoCompletado = true;

            Console.WriteLine("6. TIPO LÓGICO (bool):");
            Console.WriteLine("   Solo puede ser 'true' o 'false'.");
            Console.WriteLine("   ¿El curso está completado?: " + cursoCompletado);

            Console.WriteLine("Presiona ENTER para cerrar.");
            Console.ReadLine();

            //preguntar al usuario si le gusta la programación
            Console.Write("¿Te gusta la programación? (true/false): ");
            bool gustaProgramacion = bool.Parse(Console.ReadLine());
            Console.WriteLine("¿Te gusta la programación?: " + gustaProgramacion);

            //preguntar al usuario si esta trabajando actualmente
            Console.Write("¿Estás trabajando actualmente? (true/false): "); 
            bool trabajando = bool.Parse(Console.ReadLine());
            Console.WriteLine("¿Estás trabajando actualmente?: " + trabajando);

            //preguntar al usuario si le gusta el café
            Console.Write("¿Te gusta el café? (true/false): ");
            bool gustaCafe = bool.Parse(Console.ReadLine());
            Console.WriteLine("¿Te gusta el café?: " + gustaCafe);

            //preguntar al usuario si le gusta el chocolate
            Console.Write("¿Te gusta el chocolate? (true/false): ");
            bool gustaChocolate = bool.Parse(Console.ReadLine());
            Console.WriteLine("¿Te gusta el chocolate?: " + gustaChocolate);

            //preguntar al usuario si le gusta viajar
            Console.Write("¿Te gusta viajar? (true/false): ");
            bool gustaViajar = bool.Parse(Console.ReadLine());
            Console.WriteLine("¿Te gusta viajar?: " + gustaViajar);
            

    }
}
