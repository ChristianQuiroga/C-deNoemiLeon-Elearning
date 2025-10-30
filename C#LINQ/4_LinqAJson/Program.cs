using Newtonsoft.Json;
using System.ComponentModel;

namespace _4_LinqAJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //tenemos que instalar NewtonSoftJson, se puede instalar por Nuget o PowerShell para desarrolladores
            // con el comando Install Package Newtonsoft.json
            //en powersell: installpackage newtonsoft.json

            var archivo = @"C:\Users\christian.quiroga\OneDrive - WiseTech Global Pty Ltd\Documents\CURSOS CODERHOUSE\C#deNoemiLeon Elearning\C#LINQ\LINQ\empleados.json";
            var empleados = ObtenerEmpleados(archivo); //invocamos el método

            var nombre = empleados.Where(e => e.Edad <= 25) //
                .Select(e => e.Nombre).FirstOrDefault(); //para que sea una sola y no una secuencia de secuencias Error.
            Console.WriteLine(nombre);

            Console.ReadLine();
           
        }

        //Método, para poder acceder al Json
        static List<Empleado> ObtenerEmpleados(string ruta)
        {
            List<Empleado> listaE = new List<Empleado>();
            //using (System.IO.StreamReader r = new System.IO.StreamReader(ruta))
            using (System.IO.StreamReader r = new(ruta))
            {
                string json = r.ReadToEnd();
                listaE = JsonConvert.DeserializeObject<List<Empleado>>(json);
            }
            return listaE;
        }
    }
}
