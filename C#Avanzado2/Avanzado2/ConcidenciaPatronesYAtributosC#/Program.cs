using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcidenciaPatronesYAtributosC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Coincidencia de Patrones, usamos el Operador  IS y el patron de Tipo
            object miNombre = "Christian";
            if (miNombre is string)
                Console.WriteLine("El nombre {0} tien {1} caracteres",
                    (string)miNombre, ((string)miNombre).Length);

            if (miNombre is string mm)
                Console.WriteLine("El nombre {0} tien {1} caracteres",
                    mm, mm.Length);

            //En versiones nuevas, apartir de la 8, estamos en las 17.  Patron de Propiedad
            //Este nos va a permitir evaluar la coincidencia del valor de una propiedad en un objeto
            object miNombre1 = "Christian";
            if (miNombre1 is string { Length: 5 })
                Console.WriteLine("El nombre {0} tiene 5 caracteres",
                    (string)miNombre1);


            Console.ReadLine();
        }
    }
}
