using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiEscuela
{
    public enum FrecuenciaPago
    {
        Quincenal,
        Mensual,
        Bimestral
    }
    internal class Empleado
    {
        #region Atributos con propiedades autogestionadas!
        //en las prop. autogest. Macc + tipoDato + Nombre(mayusula la primer letra) + get y set.
        // Modificador de Acceso (public, privado,...)
        private int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo {  get; set; }
        public int Edad { get; set; }
        public string Nac { get; set; }
        public decimal Pago { get; set; }
        #endregion

        #region Constructor
        public Empleado()
        {
            this.Activo = true;
        }
        #endregion
        //sobrecarga
        public Empleado(string nombre)
        {
            Nombre = nombre;
            this.Activo = true;
        }
        #region Métodos
        public void CalcularPago()
        {

        }
        #endregion
    }
}
