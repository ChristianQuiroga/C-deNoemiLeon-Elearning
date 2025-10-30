using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ConcuAsincTareasExcepTareas
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await TareaFecha();
        }

        //RUN
        public static async Task TareaFecha()
        {
            var ta = Task.Run(() =>
            {
                var msj = "Tarea antecedente: " + Task.CurrentId;
                Console.WriteLine(msj);
                throw null;
                return DateTime.Now;
            });
            //try
            //{
            //    ta.Wait();
            //}
            //catch (AggregateException ae)
            //{

            //    if (ae.InnerException is NullReferenceException)
            //        Console.WriteLine("Excepción NULL");
            //}

            //Otra forma de hacer una exception Sin el TRY
            ta.Wait();
            _ = ta.IsCanceled;
            if (ta.IsFaulted) 
                Console.WriteLine(ta.Exception);
            //


            await ta.ContinueWith(a =>
            {
                var msj = "Tarea Continuación: " + Task.CurrentId;
                Console.WriteLine(msj);
                return DateTime.Now;
            });
        }
    }
}
