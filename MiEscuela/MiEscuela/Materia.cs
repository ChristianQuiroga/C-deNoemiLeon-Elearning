using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiEscuela
{
    abstract class Materia //Clase Abstracta
    {
        #region Atributos
        public string Cve { get; set; }
        public string Nombre { get; set; }
        public Profesor Coordinador { get; set; }
        #endregion

        #region Métodos
        //vamos a generar un método abstracto de una Clase Abstracta. Comportamiento diferentes en las clase heredadas.
        //una clase abstracta no se puede Instanciar.
        public abstract decimal Evaluar();  //Método abstracto, para ser heredado en Deportivo, cultural, Academico.
        #endregion
    }
}
