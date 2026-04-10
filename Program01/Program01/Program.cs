namespace Program01;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("--- SISTEMA DE REGISTRO DE USUARIO ---");

            // 1. Entrada de Texto (Simple)
            Console.Write("Por favor, ingresa tu nombre: ");
            string nombre = Console.ReadLine();

            // 2. Entrada de Números (Requiere Conversión)
            Console.Write("Ingresa tu edad: ");
            string edadTexto = Console.ReadLine();
            int edad = int.Parse(edadTexto); // Convertimos el texto a número entero

            // 3. Entrada de Decimales (Precios o Medidas)
            Console.Write("Ingresa tu estatura (ejemplo: 1,75): ");
            double estatura = double.Parse(Console.ReadLine()); // Conversión directa en una línea

            // 4. Mostrar los resultados procesados
            Console.WriteLine("\n--- PERFIL CREADO ---");
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Edad el próximo año: " + (edad + 1)); // Operación matemática
            Console.WriteLine("Estatura: " + estatura + " metros");

            Console.WriteLine("\nPresiona ENTER para salir.");
            Console.ReadLine();

            //1/2. Ingresar nombre y edad en una sola línea
            Console.Write("Ingresa tu nombre y apellido");
            string nombreCompleto = Console.ReadLine();
            Console.Write("Ingresa tu edad");
            string edadTexto = Console.ReadLine();
            int edad = int.Parse(edadTexto);
            Console.WriteLine("\n--- PERFIL COMPLETO ---");
            Console.WriteLine("Nombre Completo: " + nombreCompleto);
            Console.WriteLine("Edad: " + edad);

            //3/4. Ingresar precio y cantidad para calcular el total
            Console.Write("Ingresa el precio del producto: ");
            double precio = double.Parse(Console.ReadLine());
            Console.Write("Ingresa la cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());
            double total = precio * cantidad;
            Console.WriteLine("---RESUMEN DE COMPRA ---");
            Console.WriteLine("Precio Unitario: " + precio);
            Console.WriteLine("Cantidad: " + cantidad);
            Console.WriteLine("Total a Pagar: " + total);






    }
}
