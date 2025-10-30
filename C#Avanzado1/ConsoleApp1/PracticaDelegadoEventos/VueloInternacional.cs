using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDelegadoEventos
{
    public class VueloInternacional
    {
        float Iva
        {
            get
            {
                if (Redondo)
                    return 0.16f;
                return 0.04f;
            }
        }
        float Tua
        {
            get
            {
                return 360f;
            }
        }
        float ImpuestoFederalSeguridad
        {
            get
            {
                return 190.75f;
            }
        }
        public bool Redondo { get; set; }
        public int Destino { get; set; }
        public float CalcularMontoTotal(float monto)
        {
            float total = monto + (monto * Iva) + Tua;
            if (Destino == 559)
                return total + ImpuestoFederalSeguridad;
            return total;
        }
        public void CalcularTotalConImpuestos(ref float monto)
        {
            float total = monto + (monto * Iva) + Tua;
            if (Destino == 559)
                total += ImpuestoFederalSeguridad;
            monto = total;
        }
    }
}
