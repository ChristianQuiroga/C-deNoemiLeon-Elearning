using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEventos
{
    public class Program
    {
              

        /*SINTAXIS
         * 
         * 1 Declaramos el DELEGADO
         * 2 método compatible en la Clase suscriptora.
         * 3 Miembro delegado en clase EMISORA
         * 4 Invocación de evento.
        */

        //declaramos 2 ENUN
        public enum TipoAlerta
        {
            Error = 1,
            Advertencia = 2,
            Exito = 3
        }
        public enum TipoPago
        {
            Tarjeta = 1,
            Transferencia = 2,
            Otros = 3
        }
        // 1 Declaramos el Delegado
        public delegate void CambioFormaPagoHandler(TipoPago tipoPago, TipoAlerta tipoAlerta);

        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa una forma de pago: ");
            Console.WriteLine("1 - Tarjeta \n2 - Transferencia \n3 - Otros ");
            string tipoPago = Console.ReadLine();

            FormaDePago fm = new FormaDePago();
            fm.CambioFormaPago += fm_seleccionFormaPago;

            //instrucció para el  Evento Encadenado
            fm.CambioFormaPago += fm_ContinuarProcesoPago;

            fm.Tipo = (TipoPago)Enum.Parse(typeof(TipoPago), tipoPago); //Hacemos un CAST, lo pasamos a tipo ENUM

            Console.ReadKey();



        }

        // 2 esta es nuestra clase subscriptora (EVENTHANDLER)
        //este metodo tiene que estar fuera del progama principal
        static void fm_seleccionFormaPago(TipoPago tipo, TipoAlerta tipoAlerta)
        {
            if (tipoAlerta.Equals(TipoAlerta.Error))
                Console.WriteLine("Error, elegiste forma de pago incorrecta ");
            else if (tipoAlerta.Equals(TipoAlerta.Exito))
                Console.WriteLine("Forma de pago seleccionada: {0} ", tipo.ToString());
        }

        /*
         * Otro Tipo es Cadena de EVENTOS o EVENTOS ENCADENADOS
         * Es una lista de Eventos, se ejecunta de forma Asincronica (uno detras del otro, en orden)
         * 
         */
        static void fm_ContinuarProcesoPago(TipoPago tipo, TipoAlerta tipoAlerta)
        {
            bool estatus = false;
            if (tipoAlerta.Equals(TipoAlerta.Exito))
            {
                Console.WriteLine("Continuando con el proceso de pago por ",tipo.ToString());
                Console.WriteLine("Presione x para continuar...",tipo.ToString());
                string tipoPago = Console.ReadLine();   
                if(tipoPago== "x")
                    estatus = true;
            }
            Console.WriteLine("Confirmación recibida, estatus de la operación {0}", estatus ? "Confirmada" : "cancelada");

        }
    }
}
