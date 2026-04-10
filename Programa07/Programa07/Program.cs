namespace Programa07;

class Program
{
    static void Main(string[] args)
    {
        // --- CONSTANTES DE CÁLCULO Y CONTROL ---
            const decimal TASA_IVA = 0.21m; // 21% fijo
            const bool MODO_PRUEBA = false; // Control de seguridad
            const char SIMBOLO_PESO = '$';

            Console.WriteLine("--- MÓDULO DE FACTURACIÓN ---");
            Console.WriteLine("Modo prueba activo: " + MODO_PRUEBA);

            decimal precioBase = 1500.50m;
            decimal impuestoCalculado = precioBase * TASA_IVA;
            decimal total = precioBase + impuestoCalculado;

            Console.WriteLine("Detalle de la compra:");
            Console.WriteLine("Precio: " + SIMBOLO_PESO + precioBase);
            Console.WriteLine("IVA (" + (TASA_IVA * 100) + "%): " + SIMBOLO_PESO + impuestoCalculado);
            Console.WriteLine("TOTAL A PAGAR: " + SIMBOLO_PESO + total);

            Console.ReadLine();

            //CALCULO DE COMPRA
            Console.WriteLine("CÁLCULO DE DESCUENTO ");
            const decimal DESCUENTO_PROMOCIONAL = 0.10; // 10% de descuento
            decimal precioOriginal = 2000;
            decimal descuentoCalculado = precioOriginal * DESCUENTO_PROMOCIONAL;   
            decimal precioFinal = precioOriginal - descuentoCalculado;
            Console.WriteLine("Precio original: " + SIMBOLO_PESO + precioOriginal);
            Console.WriteLine("Descuento promocional (" + (DESCUENTO_PROMOCIONAL * 100) + "%): " + SIMBOLO_PESO + descuentoCalculado);
            Console.WriteLine("Precio final con descuento: " + SIMBOLO_PESO + precioFinal);

            // PRECIO DE COMBUSTIBLE
            Console.WriteLine("CÁLCULO DE PRECIO DE COMBUSTIBLE");    
            const decimal PRECIO_GASOLINA = 1.25; 
            const decimal PRECIO_DIESEL = 1.10; 
            decimal litrosGasolina = 50;
            decimal litrosDiesel = 30;
            decimal costoGasolina = litrosGasolina * PRECIO_GASOLINA;
            decimal costoDiesel = litrosDiesel * PRECIO_DIESEL;
            Console.WriteLine("Litros de gasolina: " + litrosGasolina);
            Console.WriteLine("Precio por litro de gasolina: " + SIMBOLO_PESO + PRECIO_GASOLINA);
            Console.WriteLine("Costo total de gasolina: " + SIMBOLO_PESO + costoGasolina);
            Console.WriteLine("Litros de diesel: " + litrosDiesel);
            Console.WriteLine("Precio por litro de diesel: " + SIMBOLO_PESO + PRECIO_DIESEL);
            Console.WriteLine("Costo total de diesel: " + SIMBOLO_PESO + costoDiesel);

            // CALCULO DE INTERESES
            Console.WriteLine("CÁLCULO DE INTERESES");
            const decimal TASA_INTERES_ANUAL = 0.05; // 5% anual
            decimal montoPrestamo = 10000;
            decimal interesCalculado = montoPrestamo * TASA_INTERES_ANUAL;
            Console.WriteLine("Monto del préstamo: " + SIMBOLO_PESO + montoPrestamo);
            Console.WriteLine("Tasa de interés anual: " + (TASA_INTERES_ANUAL * 100) + "%");
            Console.WriteLine("Interés calculado: " + SIMBOLO_PESO + interesCalculado);

            // CALCULO DE PROPINA
            Console.WriteLine("CÁLCULO DE PROPINA");
            const decimal PORCENTAJE_PROPINA = 0.15; // 15% de propina
            decimal totalCuenta = 80.75;    
            decimal propinaCalculada = totalCuenta * PORCENTAJE_PROPINA;
            Console.WriteLine("Total de la cuenta: " + SIMBOLO_PESO + totalCuenta);
            Console.WriteLine("Porcentaje de propina: " + (PORCENTAJE_PROPINA * 100) + "%");
            Console.WriteLine("Propina calculada: " + SIMBOLO_PESO + propinaCalculada);







    }
}
