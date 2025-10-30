using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticaEventosEventHandlerNet.Program;

namespace PracticaEventosEventHandlerNet
{
    //2 Creamos una clase publica, lo que necesitamos pasar como parámetros a 
    public class CambioFormaPagoEventArgs : EventArgs  //por convención ponemosel nombre ...Args
    {
        public TipoAlerta TipoAlerta { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}