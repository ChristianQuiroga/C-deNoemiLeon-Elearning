using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_2EncadenamientosOperConsulta
{
    public enum Departamento
    {
        RH = 201,
        Desarrollo = 520,
        Soporte = 402,
        Admin = 309
    }
    public class Empleado
    {
        public Guid Id { get; } = Guid.NewGuid(); //Identificado único
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Departamento Departamento { get; set; }

    }
}
