using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDelegadoEventos
{
    public class VueloNacional
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
                return 220f;
            }
        }
        public bool Redondo { get; set; } //propiedad
        public float CalcularMontoTotal(float monto)  //mètodo
        {
            return monto + (monto * Iva) + Tua;
        }
    }
}

