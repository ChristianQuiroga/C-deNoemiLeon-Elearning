using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiEscuela
{
    interface MiInterfaz
    {
        //string miAtributo;  Las interfaces no pueden incluir ni constantes ni Variables. Error
        string MiPropiedad { get; set; } //Va sin modificador de acceso "public"

        //Método
        string MiMensaje(); //Va sin modificador de acceso "public"
    }
}
