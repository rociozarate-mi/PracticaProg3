namespace Programa04;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- BLOQUE 3: TEXTO Y CARACTERES ---");

            // Cadena de texto (string) - Comillas dobles ""
            string nombre = "Ana López";
            Console.WriteLine("4. TIPO TEXTO (string):");
            Console.WriteLine("   Valor guardado: " + nombre);

            // Carácter único (char) - Comillas simples ''
            char inicialNombre = 'A';
            Console.WriteLine("5. TIPO CARÁCTER (char):");
            Console.WriteLine("   Valor guardado: '" + inicialNombre + "'");

            Console.WriteLine("Presiona ENTER para cerrar.");
            Console.ReadLine();

            //pedir el nombre completo al usuario
            Console.Write("Ingresa tu nombre completo: ");
            string nombreCompleto = Console.ReadLine();
            Console.WriteLine("Tu nombre completo es: " + nombreCompleto);

            //pedir la inicial del apellido al usuario
            Console.Write("Ingresa la inicial de tu apellido: ");
            char inicialApellido = char.Parse(Console.ReadLine());
            Console.WriteLine("La inicial de tu apellido es: " + inicialApellido);

            //pedir el nombre y la inicial del apellido al usuario
            Console.Write("Ingresa tu nombre: ");
            string nombreUsuario = Console.ReadLine();
            Console.Write("Ingresa la inicial de tu apellido: ");
            char inicialApellidoUsuario = char.Parse(Console.ReadLine());
            Console.WriteLine("Tu nombre es: " + nombreUsuario + " y la inicial de tu apellido es: " + inicialApellidoUsuario);

            //pedir la inicial del personaje de una película
            Console.Write("Ingresa la inicial del personaje de tu película : ");
            char inicialPersonaje = char.Parse(Console.ReadLine());
            Console.WriteLine("La inicial del personaje de tu película es: " + inicialPersonaje);


    }
}
