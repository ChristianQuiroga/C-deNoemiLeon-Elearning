using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiEscuela
{
    internal class Profesor:Empleado
    {
        #region Atributos
        public string Matr { get; set; }
        public Materia Materia { get; set; }
        FrecuenciaPago FrecPago { get; set; }
        #endregion

        #region Métodos
        public string Checar()
        {
            DateTime horaActual = DateTime.Now;
            //Guardar en la BD
            string resp = "Hora de registración: " + horaActual;
            return resp;
        }

        public void AsignarMateria(Materia materia)
        {
            Materia = materia;
        }
        #endregion

        #region Constructor sin paràmetros
        public Profesor()
        {
            this.Matr = "_2024";
        }
        #endregion
    }
}
