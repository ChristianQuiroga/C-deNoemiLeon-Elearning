using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace MiEscuela
{
    class MiClase : MiInterfaz
    {
        //Aca tenemos que definir mis Atributos, propiedades y Métodos de la claseInterfaz.
        int numero;
        public int Numero { get; set; }
        string miPropiedad;

        //Tenemos 2 formas de hacerlo, clasica y autoimplementada.

        //string MiInterfaz.MiPropiedad
        //{
        //    get { return miPropiedad; }
        //    set { miPropiedad = value; }
        //}

        string MiInterfaz.MiPropiedad { get; set; }

        //Método
        string MiInterfaz.MiMensaje()
        {
            string msj = "Mensaje desde MiClase.MiMensaje()";
            return msj;
        }

    }
}
