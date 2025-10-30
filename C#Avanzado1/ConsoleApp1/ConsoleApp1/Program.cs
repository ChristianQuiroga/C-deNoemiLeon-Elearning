using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DELEGADOS Y EVENTOS, NO QUEDO CLARO.

            //TUPLAS    
            // 3 Formas para definirlas
            //1 Forma simple
            var proveedor = ("Manuel", "Gutierrez", 50);
            Console.WriteLine($"Proveedor: {proveedor.Item1} {proveedor.Item2} {proveedor.Item3}");

            //2 forma valores nombrados
            var proveedorB = (name: "Manuel",  lastName: "Gutierrez", age: 50);
            Console.WriteLine($"Edad del proveedor {proveedorB.age}");

            //3 forma definir los Tipos de la tupla.
            (string Nombre, string Apellido) miTupla = (Nombre: "Carmen", Apellido: "Nieto");
            Console.WriteLine($"Mitupla {miTupla.Nombre}");

            miTupla.Nombre = "Cecilia";
            Console.WriteLine($"Mitupla {miTupla.Nombre}");

            Console.ReadLine();

            //la forma como lo maneja c# es la primer forma, las otras son para mas facilidad el desarrollador.
            // item1, item2 etc...


            //LAMBDA

        }
    }
}
