using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticaEventosEventHandlerNet.Program;


namespace PracticaEventosEventHandlerNet
{
    public class FormaDePago //event Broadcaster/emisora
    {
        private TipoPago tipo;

        // 1 Aca definimos el Evento predefinido con Argumentos, poniendo la clase que vamos a usar. cambioformapagoenventargs
        //Miembro delegado en la Clase emisora.
        //public event CambioFormaPagoHandler CambioFormaPago; //aca declaramos esta propiedad como Evento
        public event EventHandler<CambioFormaPagoEventArgs> CambioFormaPago;
        public TipoPago Tipo
        { //propiedad
            get
            {
                return tipo;
            }
            set
            {
                TipoAlerta tipoAlerta = TipoAlerta.Error;
                if (value.Equals(TipoPago.Tarjeta)
                    || value.Equals(TipoPago.Transferencia)
                    || value.Equals(TipoPago.Otros))
                {
                    tipo = value;
                    tipoAlerta = TipoAlerta.Exito;
                }
                //4 Invocamos al método.
                CambioFormaPagoEventArgs args = new CambioFormaPagoEventArgs
                {
                    TipoPago = tipo,
                    TipoAlerta = tipoAlerta
                };
                
                CambioFormaPago(this, args); //invocamos, this porq es el objeto que estamos pasando.


                //4 Invocación de evento.
               // CambioFormaPago(tipo, tipoAlerta); //acá la usuamos, es desencadenado usando el SET
            }
        }
    }
}
