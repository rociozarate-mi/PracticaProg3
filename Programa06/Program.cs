namespace Programa06;

class Program
{
    static void Main(string[] args)
    {
        // --- CONSTANTES DE IDENTIDAD Y REGLAS ---
            const string NOMBRE_APP = "GameMaster Pro";
            const string VERSION = "v1.0.2";
            const int EDAD_MINIMA = 18;

            Console.WriteLine("=== " + NOMBRE_APP + " (" + VERSION + ") ===");
            Console.WriteLine("Cargando reglas del sistema...");
            Console.WriteLine("Restricción: Prohibida la venta a menores de " + EDAD_MINIMA + " años.");
            
            // Intento de uso con constantes (sin estructuras de control)
            const int EDAD_CLIENTE = 20;
            const bool PUEDE_INGRESAR = EDAD_CLIENTE >= EDAD_MINIMA; // expresión booleana

            Console.WriteLine("\nVerificando cliente de " + EDAD_CLIENTE + " años...");
            Console.WriteLine("Edad mínima: " + EDAD_MINIMA);
            Console.WriteLine("Acceso permitido (valor bool constante): " + PUEDE_INGRESAR);

            // Mostrar constantes para reforzar concepto
            Console.WriteLine("Constante NOMBRE_APP = " + NOMBRE_APP);
            Console.WriteLine("Constante VERSION = " + VERSION);

            // VOTACIONESS

            Console.WriteLine("\n=== Sistema de Votaciones ===");
            const int EDAD_VOTANTE_MINIMA = 18;
            const int EDAD_VOTANTE = 17; // Cambia este valor para probar diferentes casos
            const bool PUEDE_VOTAR = EDAD_VOTANTE >= EDAD_VOTANTE_MINIMA;
            Console.WriteLine("Edad del votante: " + EDAD_VOTANTE);
            Console.WriteLine("Edad mínima para votar: " + EDAD_VOTANTE_MINIMA);
            Console.WriteLine("¿Puede votar? (valor bool constante): " + PUEDE_VOTAR);

            // REGRISTRO DE USUARIOS
            Console.WriteLine("\n=== Registro de Usuarios ===");
            const int EDAD_REGISTRO_MINIMA = 18;
            const int EDAD_USUARIO = 22; 
            const bool PUEDE_REGISTRARSE = EDAD_USUARIO >= EDAD_REGISTRO_MINIMA;
            Console.WriteLine("Edad del usuario: " + EDAD_USUARIO);
            Console.WriteLine("Edad mínima para registrarse: " + EDAD_REGISTRO_MINIMA);
            Console.WriteLine("¿Puede registrarse? (valor bool constante): " + PUEDE_REGISTRARSE);

            //CONTOL DE ACCESO A BARES
            Console.WriteLine("\n=== Control de Acceso a Bares ===");
            const int EDAD_ACCESO_BAR_MINIMA = 18;
            const int EDAD_CLIENTE_BAR = 16;
            const bool PUEDE_ENTRAR_BAR = EDAD_CLIENTE_BAR >= EDAD_ACCESO_BAR_MINIMA;
            Console.WriteLine("Edad del cliente: " + EDAD_CLIENTE_BAR);
            Console.WriteLine("Edad mínima para entrar al bar: " + EDAD_ACCESO_BAR_MINIMA);
            Console.WriteLine("¿Puede entrar al bar? (valor bool constante): " + PUEDE_ENTRAR_BAR);

            //PUEDE CONDUCIR?

            Console.WriteLine("---- Control de Conducción -----");
            const int EDAD_CONDUCCION_MINIMA = 18;
            const int EDAD_CONDUCTOR = 19;
            const bool PUEDE_CONDUCIR = EDAD_CONDUCTOR >= EDAD_CONDUCCION_MINIMA;
            Console.WriteLine("Edad del conductor: " + EDAD_CONDUCTOR); 


            Console.ReadLine();

            //VOTACIONESS

            Console.WriteLine("\n=== Sistema de Votaciones ===");
            const int EDAD_VOTANTE_MINIMA = 18;
            const int EDAD_VOTANTE = 17; // Cambia este valor para probar diferentes casos
            const bool PUEDE_VOTAR = EDAD_VOTANTE >= EDAD_VOTANTE_MINIMA;
            Console.WriteLine("Edad del votante: " + EDAD_VOTANTE);
            Console.WriteLine("Edad mínima para votar: " + EDAD_VOTANTE_MINIMA);
            Console.WriteLine("¿Puede votar? (valor bool constante): " + PUEDE_VOTAR);

            // REGRISTRO DE USUARIOS
            Console.WriteLine("\n=== Registro de Usuarios ===");
            const int EDAD_REGISTRO_MINIMA = 18;
            const int EDAD_USUARIO = 22; 
            const bool PUEDE_REGISTRARSE = EDAD_USUARIO >= EDAD_REGISTRO_MINIMA;
            Console.WriteLine("Edad del usuario: " + EDAD_USUARIO);
            Console.WriteLine("Edad mínima para registrarse: " + EDAD_REGISTRO_MINIMA);
            Console.WriteLine("¿Puede registrarse? (valor bool constante): " + PUEDE_REGISTRARSE);

            //CONTOL DE ACCESO A BARES
            Console.WriteLine("\n=== Control de Acceso a Bares ===");
            const int EDAD_ACCESO_BAR_MINIMA = 18;
            const int EDAD_CLIENTE_BAR = 16;
            const bool PUEDE_ENTRAR_BAR = EDAD_CLIENTE_BAR >= EDAD_ACCESO_BAR_MINIMA;
            Console.WriteLine("Edad del cliente: " + EDAD_CLIENTE_BAR);
            Console.WriteLine("Edad mínima para entrar al bar: " + EDAD_ACCESO_BAR_MINIMA);
            Console.WriteLine("¿Puede entrar al bar? (valor bool constante): " + PUEDE_ENTRAR_BAR);

            //PUEDE CONDUCIR?

            Console.WriteLine("---- Control de Conducción -----");
            const int EDAD_CONDUCCION_MINIMA = 18;
            const int EDAD_CONDUCTOR = 19;
            const bool PUEDE_CONDUCIR = EDAD_CONDUCTOR >= EDAD_CONDUCCION_MINIMA;
            Console.WriteLine("Edad del conductor: " + EDAD_CONDUCTOR); 

            //
    }

}
