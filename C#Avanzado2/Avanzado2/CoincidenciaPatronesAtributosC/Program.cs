using System.ComponentModel;
using System.Reflection;

namespace CoincidenciaPatronesAtributosC
{
    internal class Program
    {
        
        //Clase interna
        public class Peticion
        {
            internal int Puerto { get; set; }
            internal string Metodo { get; set; }
            internal string TipoDeContenido { get; set; }
        }
        
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

            //En versiones nuevas, apartir de la 8, estamos en las 17.
            //Patron de Propiedad
            //Este nos va a permitir evaluar la coincidencia del valor de una propiedad en un objeto
            //object miNombre = "Christian";
            if (miNombre is string { Length: 9 })
                Console.WriteLine("El nombre {0} tiene 9 caracteres",
                    (string)miNombre);

            bool ProcesarPeticion(Peticion pet) => pet switch
            {
                { TipoDeContenido: "image/*", Metodo: "GET" } => true,
                { Puerto: 8880, Metodo: string { Length: 2 } } => true,
                { TipoDeContenido: "image/*", Metodo: "POST" } when pet.Puerto.ToString().Length <= 4 => true,
                { Metodo: "PUT", Puerto: 3000, TipoDeContenido: string ct } => ct.EndsWith("*"),
                _ => false
            };


            //Ejemplo de Atributos con Argumentos multiples.
            int a = 5;
            int b = 5;
            var s = Suma(a,b);
            Console.WriteLine($"La suma de {a} + {b} = {s}" );

            Console.ReadLine();
        }

        //[Obsolete("Método obsolet. Usar método Add en su lugar", false)] //declaramos un ATRIBUTO
        //[Description("Suma los valores de los argumentos...")] //estan definidos en CORE .NET ComponentModel
        [DatosDesarrollo("3A")] //Atributo personalizado
        static int Suma(int A, int B)
        {
            //Atributo personalizado
            MethodBase metodo = MethodBase.GetCurrentMethod();
            DatosDesarrolloAttribute attr = (DatosDesarrolloAttribute)metodo.
                GetCustomAttributes(typeof(DatosDesarrolloAttribute), true)[0]; //lo Casteamos. Devuelve un arreglo y tomamos el primero.

            return A + B;
        }
    }
}
