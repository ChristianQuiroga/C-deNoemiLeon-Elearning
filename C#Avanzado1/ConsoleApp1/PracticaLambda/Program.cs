using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLambda
{
    internal class Program
    {
        //1 Definimos primero el Delegado
        delegate int Operacion (int x, int y);
        static void Main(string[] args)
        {
            Operacion op = (a, b) => a * b;
            var res = op(2, 2);
            Console.WriteLine($"Total: {res}"); //$ para usar el {res}

            Operacion potencia = (ab, b) =>
            {
                //usamos {} para definir varias sentencias
                Console.WriteLine($"{ab} elevado a la {b} potencia");
                return (int)Math.Pow(ab, b);
            };
            int x = 2;
            int z = 4;
            int p = potencia(x, z);
            Console.WriteLine($"Total {p}");

            //Podemos usar Delegados Fun y Action
            Func<int, int, int> pot = (w, y) => (int)Math.Pow(w, y);
            Console.WriteLine($"Total {pot(5, 5)}");

            Func<string, string, bool> igual = (aa, b) => aa.Equals(b);
            string cadA = "Noemi";
            string cadB = "noemi";
            Console.WriteLine($"Son iguales? {igual(cadA, cadB)}");

            //Console.ReadLine();

            #region variables e iteraciones
            int a1 = 5;
            Func<int, int> suma = fd => fd + a1;
            //a = 10;
            Console.WriteLine($" Suma = {suma(2)}");

            Func<int, int, int> potB = (zz, y) => (int)Math.Pow(zz, y);
            int baseP = 5;
            for (int i = 1; i <= 3; i++)
            {
                int resp = potB(baseP, i);
                Console.WriteLine($"{baseP} Elevado a la {i} potenci = {resp}");

            }
            
            #endregion

            #region Tuplas
            Func<(int,int), (int, int)> invertir = c => (c.Item1 * -1, c.Item2 * -1);
            var coordenadas = (-20, 50);
            Console.WriteLine($"Coordenadas invertidas {invertir(coordenadas)}");

            Console.ReadLine();
            #endregion


        }
    }
}
