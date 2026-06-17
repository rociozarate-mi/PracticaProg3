namespace PracticaProg3;

public class ejercicio2
{
    static void Main(string[] args)
    {
        Console.WriteLine("---EJERCICIO2: INICILIZACION DIRECTA Y FOREACH---");

        // Sintaxis planificada de inicialización
        string [] frutas = {"Manzana", "Banana", "Uva" , "Naranja"};

        // Uso de foreach
        Console.WriteLine("Listas de frutas usando foreach:");
        foreach (string fruta in frutas)
        {
            Console.WriteLine("-" + fruta);

        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();

        Console.WriteLine("--Ejercicio 2.2--");
        // Sintaxis planificada de inicialización
        string [] semana = {"lunes" , "martes" , "miercoles" , "jueves ", "viernres" };
        // Uso de foreach
        Console.WriteLine("Días de la semana usando foreach:");
        foreach (string dia in semana)
        {
            Console.WriteLine("*" +dia);
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();

        Console.WriteLine("--Ejercicio 2.3--");
        // Sintaxis planificada de inicialización
        string [] collores = {"amarillo" , "azul" , "blanco"};
        // Uso de foreach
        Console.WriteLine("Colores usando foreach:");
        foreach (string color in collores)
        {
            Console.WriteLine("+" + color);
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();

        Console.WriteLine("--EJERCICIO 2.4--");

        //SINTAXIS 

        string [] mes={"enero" , "febrero" , "marzo" , "abril"};

        // Uso de foreach
        Console.WriteLine("Meses del año usando foreach:"); 
        foreach (string m in mes)
        {
            Console.WriteLine("-" + m);
        }
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();

        Console.WriteLine("--EJERCICIO 2.5--");
        //SINTAXIS
        string [] estaciones = {"primavera","verano","otoño","invierno"};
        //uso de foreacj

        Console.WriteLine("estaciones del año");
        foreach (string estacion in estaciones)
        {
            Console.WriteLine("~" + estacion);
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }
    
}
