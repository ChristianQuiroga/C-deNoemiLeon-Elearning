using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiEscuela
{
    class Deportiva : Materia
    {
        #region Método abstracto
        public override decimal Evaluar() // se declara con Override y el metodo Abstracto
        {
            //throw new NotImplementedException();  Excepción
            //Evaluar en base a prueba y asistencia.
            //consultar dato en BD para regresar resultado.
            decimal calific = 90.0M; // M es decimal
            return calific;
        }
        #endregion
    }
}
