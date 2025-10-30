using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincidenciaPatronesAtributosC
{
//Definimos un atributo personalizado, Heredando de System.Atribute
    internal class DatosDesarrolloAttribute : System.Attribute
    {
        public DateTime fechaCreacion;
        public string equipo;

        //Constructor
        public DatosDesarrolloAttribute(string equipo)
        {
            this.equipo = equipo;
            fechaCreacion = DateTime.Now;
        }

    }
}
