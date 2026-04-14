namespace PracticaProg3;

public class ejercicio3
{
    static void Main(string[] args)
    {
        Console.WriteLine("---EJERCICIO 3: USO DE .LENGHT Y BUCLE FOR---");

        //INICIALIZACION DIRECTA 
        int[] edades = {15,22,30,18,25};

        //obtener el tamaño del arreglo dinamicamente
        int cantidadElementos = edades.Length;
        Console.WriteLine("el arreglo tiene" + cantidadElementos + "elementos");
        Console.WriteLine("----------------------------------------------");

        //itecion clasica usando indices

        for (int i = 0; i < edades.Length; i++)
        {
            Console.WriteLine("la edad en la posicion " + i + " es: " + edades[i]);
        }

        Console.WriteLine("presione enter para continuar...");
        Console.ReadLine();

        Console.WriteLine("---EJERCICIO 3.2---");
        //INICIALIZACION DINAMICA
        int [] numeros = new int {7,5,4,9,3,6,1,2};
        //obtener el tamaño del arreglo dinamicamente
        int cantNumeros = numeros.Length;
        Console.WriteLine("el arreglo tiene " + cantNumeros + " elementos");

        //iteracion clasica usando indices
        for (int i =0; i< numeros.Length; i++)
        {
            Console.WriteLine("el numero en la posicion " +i + "es :" +numeros[i]);

        }
            Console.WriteLine("presione enter para continuar...");
            Console.ReadLine();

            Console.WriteLine("---EJERCICIO 3.3---");
            //INICIALIZACION DINAMICA CON VALORES POR DEFECTO
            string [] dias = new string[] {"lunes", "martes", "miercoles", "jueves", "viernes"};
            //obtener el tamaño del arreglo dinamicamente
            int cantDias = dias.Length;
            Console.WriteLine("el arreglo tiene " + cantDias + " elementos");
            //iteracion clasica usando indices
            for (int i=0 ; i<dias.Length; i++)
        {
            Console.WriteLine("el dia en la posicion " + i + "es:" +dias[i]);
        }

        Console.WriteLine("presione enter para finalizar...");
        Console.ReadLine();

        Console.WriteLine("--EJERCICIO 3.4---");
        //INICIALIZACION DINAMICA CON VALORES POR DEFECTO
        string [] meses = new string [] {"enero" , "febrero" , "marzo" , "abril" , "mayo"};
        //obtener el tamaño del arreglo dinamicamente
        int cantMeses=meses.Length;
        Console.WriteLine("el arreglo tiene " + cantMeses + "elementos");
        //iteracion clasica usando indices
        for (int  i=0; i<meses.Length; i++)
        {
            Console.WriteLine("el mes en la posicion " + i + "es:" + meses[i]);
        }

        Console.WriteLine("presione enter para finalizar...");
        Console.ReadLine();

        Console.WriteLine("---EJERCICIO 3.5---");
        //INICIALIZACION DINAMICA CON VALORES POR DEFECTO
        int [] jugadores = new int [] {789 , 850 , 65 , 17};
        //obtener el tamaño del arreglo dinamicamente
        int cantJugadores = jugadores.Length;
        Console.WriteLine("el arreglo tiene " + cantJugadores + "elementos");
        //iteracion clasica usando indices
        for (int i=0; i<jugadores.Length; i++)
        {
            Console.WriteLine("el jugadors en la posicion " + i + "es: " +jugadores[i]);
        }

        Console.WriteLine("presione enter para finalizar...");
        Console.ReadLine();
    }
}

