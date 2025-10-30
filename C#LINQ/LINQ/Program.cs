using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //se usa para manipular conjuntos de datos varios.
            string[] niveles = { "Basico", "Intermedio", "Avanzado" };
            var nc = niveles.Count();
            int max = 6;

            Console.WriteLine("SIN LINQ");
            foreach (var n in niveles)
            {
                if (n.Length > 6)
                    Console.WriteLine(n);
            }


            //Con linq lo obtenemos mas sencillamente. Código mas limpio y rápido.
            // linq usa métodos de extensión para hacerlo como el WHERE, tambien usan Lambda y se puede agregar Clausulas como OrdeBy.
            var ns = niveles.Where(n => n.Length > max).OrderBy(no => no);
            Console.WriteLine("\nCON LINQ");
            foreach (var n in ns)
            {
                Console.WriteLine(n);
            }

            /*Las colecciones en C# son objetos que implementam
             * IEnumerable<T>. Son las secuencia de entrada en consultas LINQ
             *Language Integrated Query o Consulta Integrada en el Lenguaje. Es un componente de .net
             */
            //Sintaxis Métodos de Extensiones y Sintaxis de Consultas; (LINQ y Expresiones de Consulta)
            //son las mismas pero linq es mas corto, se pueden usar las 2 y combinarlas, pero no en la misma sentencia.
            Console.WriteLine("\nSintaxis Expresiones de Consulta.");
            var qn =
                from nivel in niveles
                where nivel.Length > max
                orderby nivel ascending
                select nivel;

            foreach (var n in qn)
            {
                Console.WriteLine(n);
            }

            //se pueden combinar las dos sintaxis de consulta, se recomienda usar la de metodos que es mas simple
            // y de consulta cuando sea mas complicado. En este curso se va usar las de métodos.


            Console.ReadLine();
        }

    }
}
