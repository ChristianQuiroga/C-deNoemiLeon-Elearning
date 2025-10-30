namespace _3ConcurrenciaAsincronicaHilos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Console.WriteLine("Hello, World!");
            //Thread = Hilo, tiene propiedades NAME, STAR...
            Thread t = new Thread(ImprimeConteo);
            t.Name = "Conteo";
            t.Start();
            //asignamos un variable para ejecutar el Join, tiempo que se va terminar la ejecución milisegundos.
            var terminado = t.Join(1); 


            for (int i = 100; i >= 0; --i)
            {
                Console.WriteLine("X");
            }
        }
        static void ImprimeConteo()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            //sleep para pausar el hilo actual
            Thread.Sleep(1000); // espera 1000 ms y dsp hace el for de abajo.

            for (int i = 100; i >= 0; --i)
            {
                Console.WriteLine(i);
            }
        }
    }
}
