namespace PatronesDeTuplas
{
    internal class Program
    {
        //declaramos un ENUM
        private enum Moneda
        {
            MXN,
            EUR,
            USD
        }
        static void Main(string[] args)
        {
            //utilizamos la Sentencia SWITCH con patrones
            //Definimos un FUNCTION, con Argumentos y recibe el Enum
            decimal ConvertirMoneda(decimal cantidad, Moneda inicial, Moneda final) => (inicial, final) 
                switch
                {
                    (Moneda.EUR, Moneda.MXN) => (cantidad * 21.27m), //Lambda
                    (Moneda.MXN, Moneda.EUR) => (cantidad * 0.047m),
                    _ => throw new Exception("Combinación no definida") //excepcción ! 
                };

            var total = ConvertirMoneda(500m, Moneda.MXN, Moneda.EUR);
            Console.WriteLine("Total: " + total.ToString());
            Console.ReadLine();
        }
    }
}
