namespace Programa03;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- BLOQUE 2: NÚMEROS CON DECIMALES ---");

            // Estatura (double)
            double estatura = 1.75;
            Console.WriteLine("2. TIPO DECIMAL COMÚN (double):");
            Console.WriteLine("   Valor guardado: " + estatura + " metros");

            // Dinero (decimal) - Recuerda la 'm' al final
            decimal precioProducto = 199.99m;
            Console.WriteLine("\n3. TIPO DECIMAL FINANCIERO (decimal):");
            Console.WriteLine("   ¡Obligatorio para dinero! Usa la 'm'.");
            Console.WriteLine("   Valor guardado: $" + precioProducto);

            Console.WriteLine("\nPresiona ENTER para cerrar.");
            Console.ReadLine();

            //suma de decimales
            Console.WriteLine("Sumar dos números decimales:");
            Console.Write("Ingresa el primer número decimal: ");
            double decimal1 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa el segundo número decimal: ");
            double decimal2 = double.Parse(Console.ReadLine());
            double sumaDecimal = decimal1 + decimal2;
            Console.WriteLine("La suma es: " + sumaDecimal);

            //resta de decimales
            Console.WriteLine("Restar dos números decimales:");
            Console.Write("Ingresa el primer número decimal: ");
            double decimal3 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa el segundo número decimal: ");
            double decimal4 = double.Parse(Console.ReadLine());
            double restaDecimal = decimal3 - decimal4;
            Console.WriteLine("La resta es: " + restaDecimal);

            //multiplicacion de decimales
            Console.WriteLine("Multiplicar dos números decimales:");
            Console.Write("Ingresa el primer número decimal: ");
            double decimal5 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa el segundo número decimal: ");
            double decimal6 = double.Parse(Console.ReadLine());
            double multiplicacionDecimal = decimal5 * decimal6;
            Console.WriteLine("La multiplicación es: " + multiplicacionDecimal);

            //calcular el precio total de una compra
            Console.WriteLine("Calcular el precio total de una compra:");
            Console.Write("Ingresa el precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());
            Console.Write("Ingresa la cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());
            decimal totalCompra = precio * cantidad;
            Console.WriteLine("El total a pagar es: $" + totalCompra);

            //calcular metros cuadrados de un terreno
            Console.WriteLine("Calcular metros cuadrados de un terreno:");
            Console.Write("Ingresa el largo del terreno en metros: ");
            double largo = double.Parse(Console.ReadLine());
            Console.Write("Ingresa el ancho del terreno en metros: ");
            double ancho = double.Parse(Console.ReadLine());
            double metrosCuadrados = largo * ancho;
            Console.WriteLine("El terreno tiene " + metrosCuadrados + " metros cuadrados.");
            



    }
}
