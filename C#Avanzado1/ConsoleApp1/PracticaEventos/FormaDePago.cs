using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticaEventos.Program;

namespace PracticaEventos
{
    public class FormaDePago //event Broadcaster/emisora
    {
        private TipoPago tipo;

        // 3 Miembro delegado en la Clase emisora.
        public event CambioFormaPagoHandler CambioFormaPago; //aca declaramos esta propiedad como Evento
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
                //CambioFormaPagoEventArgs args = new CambioFormaPagoEventArgs
                //{
                //    TipoPago = tipo,
                //    TipoAlerta = tipoAlerta
                //};
                //CambioFormaPago(this, args);


                //4 Invocación de evento.
                CambioFormaPago(tipo, tipoAlerta); //acá la usuamos, es desencadenado usando el SET
            }
        }
    }
}
