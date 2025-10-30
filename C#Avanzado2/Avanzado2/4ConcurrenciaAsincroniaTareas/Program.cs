using System.Security.Cryptography.X509Certificates;

namespace _4ConcurrenciaAsincroniaTareas
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //su esqueleto seria
            //se una la libreria global using global::System.Threading.Tasks;}
            // Es mas sencillo que suar los HILOS.

            //var tarea = Task.Run(() =>
            //{

            //});

            //método RUN de la tarea
            var tr = Task.Run(() =>
            {
                Console.WriteLine("Tarea {0} se ejecuta en el hilo {1}",
                    Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000); //para que dure un tiempo
            });

            if (!tr.IsCompleted) //si no es completado esperamos.
                tr.Wait();


            //STAR
            bool iniciarTarea = true;
            var ts = new Task(() =>  //expresiones Lambda
            {
                Console.WriteLine("Tarea  {0} se ejecuta en el hilo {1}",
                    Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
            });

            if (iniciarTarea)  //esta separado de la creacion de la tarea, arriba.
                ts.Start();

            //Verificar estado
            // WAIT
            if (ts.Status == TaskStatus.Running || ts.Status == TaskStatus.WaitingToRun)
                ts.Wait();  //esperamos.


            #region Retorno de valores
            //la clase Task para las tareas, emite un valor de retorno, que no lo tiene los hilos.

            //tipo de valor a regresar en este caso string/int/etc
            Task<string> tr1 = Task.Run(() =>
            {
                var msj = $"Tarea {Task.CurrentId} " + $"se ejecuta en le hilo {Thread.CurrentThread.ManagedThreadId}";
                return msj; //falto el RETURN.
            });
            #endregion

            var imprime = tr1.Result; //lo devolvemos con RESULT
            if (tr1.IsCompleted)
                Console.WriteLine(imprime);


            #region Async y Await
            //mecanismo callback
            //asyc una vez la tarea finaliza
            await TareaFecha();
            #endregion
        }

        public static async Task TareaFecha()
        {
            var ta = Task.Run(() =>
            {
                var msj = "Tarea antecedente: " + Task.CurrentId;
                Console.WriteLine(msj);
                return DateTime.Now;
            });

            await ta.ContinueWith(a =>
            {
                var msj = "Tarea Continuación: " + Task.CurrentId;
                Console.WriteLine(msj);
                return DateTime.Now;
            });
        }
    }
}
