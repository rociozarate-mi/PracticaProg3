namespace PracticaProg3;

public class ejercicio01
{
    static void Main(string[] args)
    {
        Console.WriteLine("---EJERCICIO 01: FUNDAMENTOS DE ARREGLOS-- ");

        //1. Dedeclaracion e inicilizacion de un arreglo de enteros"

        //Los valores por defecto son 0
        int[] numeros = new int[3];

        //2. Asignacion de valores manual por indice

        numeros [0] =10;
        numeros[1] =20;
        numeros[2] =30;

        //3. Acceso y lectura de valores

        Console.WriteLine("Valor en indice 0: " + numeros[0]);
        Console.WriteLine("Valor en indice 1: " + numeros[1]);      
        Console.WriteLine("Valor en indice 2: " + numeros[2]);  

        //4.Intento de acceso a un indice invalido 

        Console.WriteLine("Intento de acceso a indice 3: " + numeros[3]); //Esto generara una excepcion de indice fuera de rango    

        Console.WriteLine("presione enter para continuar...");
        Console.ReadLine();

        Console.WriteLine("--Ejercicio 1.2---");

        //1. Declaracion e inicializacion 

        int [] numeros2 = new int[4];

        //Asignacion de valores

        numeros2[0] = 1;
        numeros2[1] =3;
        numeros[2]=5;
        numeros2[3] =7;

        //3. Acceso y lectura de valores

        Console.WriteLine("Valor en indice 0: " +numeros2[0]);
        Console.WriteLine("Valor en indice 1: " +numeros2[1]);
        Console.WriteLine("Valor en indice 2: " +numeros2[2]);
        Console.WriteLine("Valor en indice 3: " +numeros2[3]);

        Console.WriteLine("presione enter para continuar...");
        Console.ReadLine();
  
        Console.WriteLine("--EJERCICIO 1.3--");

        //1. Declaracion e inicializacion
        int[] arrays = new int [2];

        //2. Asignacion de valores
         arrays [0] = 50;
         arrays [1] = 55;

        //3. Acceso y lectura de valores
        Console.WriteLine("Valor en indice 0: " + arrays[0]);
        Console.WriteLine("Valor en indice 1: " + arrays[1]);
        Console.WriteLine("presione enter para continuar...");
        Console.ReadLine();

        Console.WriteLine("--EJERCICIO 1.4--");

        //1. Declaracion e inicializacion
        int[] caja = new int [5];

        //2. Asignacion de valores
        caja [0]=2;
        caja[1]=4;
        caja[2]=6;
        caja[3]=8;
        caja[4]=10;
        //3. Acceso y lectura de valores
        Console.WriteLine("Valor en indice 0: " + caja[0]);
        Console.WriteLine("Valor en indice 1: " + caja[1]);
        Console.WriteLine("Valor en indice 2: " + caja[2]);
        Console.WriteLine("Valor en indice 3: " + caja[3]);
        Console.WriteLine("Valor en indice 4: " + caja[4]);
        Console.WriteLine("presione enter para continuar...");
        Console.ReadLine();

         Console.WriteLine("--EJERCICIO 1.5--");

        //1. Declaracion e inicializacion

        int[] lugares = new int [3];

        //2. Asignacion de valores

        lugares [0] = 1;
        lugares [1] = 2;
        lugares [2] = 3;

        //3. Acceso y lectura de valores
        Console.WriteLine("Valor en indice 0: " + lugares[0]);
        Console.WriteLine("Valor en indice 1: " + lugares[1]);
        Console.WriteLine("Valor en indice 2: " + lugares[2]);
        Console.WriteLine("presione enter para continuar...");
        Console.ReadLine();
    }
    
}
