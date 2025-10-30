using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiEscuela
{
    internal class Program
    {
        //Método con parámetros
        public static void ImprimirMensajeEnPantalla(string mensaje, bool guardar = false) //al final todos los parámetros opcionales
        {
            Console.WriteLine("Respuesta del sistema: ");
            Console.WriteLine(mensaje);
            if (guardar == true)
            {
                //guardar en la BD el mensaje
            }
        }

        //Método en Program
        //public static void ImprimirMensajePrueba()
        //{
        //    Console.WriteLine("Mensaje de prueba");
        //}
        static void Main(string[] args)
        {
            //    Profesor nuevoProfesor = new Profesor();
            //    nuevoProfesor.id = 0

            Console.Title = "Sistema de Adminstración Escolar";
            Profesor profesor = new Profesor();
            //
            string name = "Ruben";
            string grade = "5A";
            Estudiante estudiante = new Estudiante(name, grade);
            //Destructor del Objeto con null
            estudiante = null; 
            //
            string resp = profesor.Checar(); // invocamos el método
            ImprimirMensajeEnPantalla(resp);


            Console.WriteLine("Presione 0 para mostrar mensaje de prueba");
            int x = Int32.Parse(Console.ReadLine());
            if (x == 0)
            {
                //ImprimirMensajePrueba();
                ImprimirMensajeEnPantalla("Mensaje de prueba");
            }
            Console.ReadKey();
            

        }
    }
}
