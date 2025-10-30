using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDelegadoEventos
{
    #region Estructura de DELEGADOS
    /*
     * se require de 3 puntos
     * 
       Declaramos los delegados
       Instanciar / asigna el delegado a un método objetivo
       Invocar el delegado
       
    */
    #endregion

    //Declaramos el DELEGADO
    public delegate float CalcularTotal(float subtotal);
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creamos Intanciamos
            VueloNacional vueloNac = new VueloNacional
            {
                Redondo = true,
            };

            //Instanciamos / Asignamos al DELEGADO
            //CalcularTotal total = new CalcularTotal(vueloNac.CalcularMontoTotal);
            //Instanciar / Asignamos al DELEGADO forma corta
            CalcularTotal total = vueloNac.CalcularMontoTotal;

            float precio = 5500f;

            Console.WriteLine("Costo vuelo nacional: {0}", total(precio)); //Invocamos
            //Console.ReadKey();

            //Una de las ventajas de los Delegados es
            VueloInternacional vueloInter = new VueloInternacional
            {
                Redondo = false,
                Destino = 559,
            };
            //parámetro
            float vueloInternac = 9800f;

            total = vueloInter.CalcularMontoTotal;
            //float t = total(precio);
            float t = total(vueloInternac);
            Console.WriteLine("Costo vuelo internacional sencillo {0}", t);
           


            #region parametros
            float totalAdultoMayor = CalcularConDescuentoAdultoMayor(t, total);
            Console.WriteLine("Costo vuelo internacional sencillo, descuento adulto mayor {0}", totalAdultoMayor);
            #endregion
            Console.ReadKey();

            #region Multicast
            CalcularTotal totalB = vueloInter.CalcularMontoTotal;
            totalB += CalcularTotalSeguro;
            Console.WriteLine("Costo vuelo internacional sencillo con seguro {0}", totalB(vueloInternac));
            #endregion
        }
        static float CalcularConDescuentoAdultoMayor(float monto, CalcularTotal total)
        {
            float subtotal = total(monto);
            return subtotal - (0.35f * subtotal);
        }

        static float CalcularTotalSeguro(float total)
        {
            float porcentajeSeguro = 0.1f;
            return total * porcentajeSeguro;
        }
    }
}
