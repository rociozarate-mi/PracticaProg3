namespace PracticaProg3;

public class ejericicio
{
    //guardo nombre y edades
    string [] nombres = new string[20];
    int [] edades = new int[20];
    int cantidad =20;

    //ingresamos datos 
    public void ingresarDatos()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Console.Write("Ingrese el nombre de la persona : ", i + 1);
            nombres[i] = Console.ReadLine();
            Console.Write("Ingrese la edad de: ", nombres[i]);
            edades[i] = int.Parse(Console.ReadLine());
        }

        for (int i =0 ; i<cantidad; i++)
        {
            if (edades[i] > 30)
            {
                Console.WriteLine("Puede ingresar", nombres[i]);
            }
            else
            {
                Console.WriteLine("No puede ingresar", nombres[i]);
            }
        }
    }

}
