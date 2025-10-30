using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiEscuela
{
    class Cultural : Materia
    {
        #region Método abstracto
        public override decimal Evaluar() // se declara con Override y el metodo Abstracto
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
