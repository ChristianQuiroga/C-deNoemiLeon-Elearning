using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5ManejoExcepcionesC_
{
    internal class FormatoArchivoException : Exception
    {
        public FormatoArchivoException() { }
        public FormatoArchivoException(string mensaje) : base(String.Format("Formato de archivo incorrecto {0}", mensaje)) { }

    }
}
