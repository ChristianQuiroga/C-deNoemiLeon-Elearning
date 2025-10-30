using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PracticaEventosEventHandlerNet 
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

        // No vamos a definir el DELEGADO ya que viene predefinido con NET (tenemos dos, con o sin parámetros)
        // 1 Declaramos el Delegado
        //public delegate void CambioFormaPagoHandler(TipoPago tipoPago, TipoAlerta tipoAlerta);

        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa una forma de pago: ");
            Console.WriteLine("1 - Tarjeta \n2 - Transferencia \n3 - Otros ");
            string tipoPago = Console.ReadLine();

            FormaDePago fm = new FormaDePago();
            fm.CambioFormaPago += fm_seleccionFormaPago; //invocamos

            //instrucció para el  Evento Encadenado
            fm.CambioFormaPago += fm_ContinuarProcesoPago;

            fm.Tipo = (TipoPago)Enum.Parse(typeof(TipoPago), tipoPago); //Hacemos un CAST, lo pasamos a tipo ENUM

            Console.ReadKey();


        }


        // 3 Acá tenemos que hacer coincidir la firma, argumentos.
        //static void fm_seleccionFormaPago(TipoPago tipo, TipoAlerta tipoAlerta)
        static void fm_seleccionFormaPago(object emisor, CambioFormaPagoEventArgs args)
        {
            if (args.TipoAlerta.Equals(TipoAlerta.Error))
                Console.WriteLine("Error, elegiste forma de pago incorrecta ");
            else if (args.TipoAlerta.Equals(TipoAlerta.Exito))
                Console.WriteLine("Forma de pago seleccionada: {0} ", args.TipoPago.ToString());
        }

        /*
         * Otro Tipo es Cadena de EVENTOS o EVENTOS ENCADENADOS
         * Es una lista de Eventos, se ejecunta de forma Asincronica (uno detras del otro, en orden)
         * 
         */
        //static void fm_ContinuarProcesoPago(TipoPago tipo, TipoAlerta tipoAlerta)
        static void fm_ContinuarProcesoPago(object emisor, CambioFormaPagoEventArgs args)
        {
            bool estatus = false;
            if (args.TipoAlerta.Equals(TipoAlerta.Exito))
            {
                Console.WriteLine("Continuando con el proceso de pago por ", args.TipoPago.ToString());
                Console.WriteLine("Presione x para continuar...", args.TipoPago.ToString());
                string tipoPago = Console.ReadLine();
                if (tipoPago == "x")
                    estatus = true;
            }
            Console.WriteLine("Confirmación recibida, estatus de la operación {0}", estatus ? "Confirmada" : "cancelada");

        }
    }
}
