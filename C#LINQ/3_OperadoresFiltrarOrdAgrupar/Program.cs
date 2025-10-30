using System.Collections.Generic;

namespace _3_OperadoresFiltrarOrdAgrupar
{
    internal class Program
    {
        /*Operadores de Consulta
             * Filtrado => Where, Take, TakeWhile, Skip...
             * Ordenado => OrderBy, OrderByDescending, then, Reverse...
             * Agrupado => GroupBy,...
             * 
             * Proyección => Select, SelectMany
             * Conversion => ToArray, ToDictionary, Tolist, AsEnumerable
             * Join => Join, GroupJoin
             * 
             * Elemento => ElementAt, ElementAtOrDefault, First, Last, Single, ...OrDefault...
             * Agregación => Average, Count, Sum, Max, Min, Aggregat, LongCount
             * Cuantificación => All, Any, Contains, SequenceEqual
             */
        static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>()
            {
                new Empleado() {
                    Nombre = "Daniela", //7
                    Apellido = "Perez",//5
                    Departamento = Departamento.Desarrollo,
                    Edad = 29,
                    IdExterno = 1
                },
                new Empleado() {
                    Nombre = "Jose", //4
                    Apellido = "Lima Rico", //9
                    Departamento = Departamento.Desarrollo,
                    Edad = 40,
                    IdExterno = 2
                },
                new Empleado() {
                    Nombre = "Fernanda", //8
                    Apellido = "Vega Valle", //10
                    Departamento = Departamento.Desarrollo,
                    Edad = 35,
                    IdExterno = 3
                },
                new Empleado() {
                    Nombre = "Fabiola", //7
                    Apellido = "Cortés Vázques", //14
                    Departamento = Departamento.Desarrollo,
                    Edad = 25,
                    IdExterno = 4,
                    Pagos = new List<Pago>
                    {
                        new Pago
                        {
                            Descripcion = "Quincena #1: Diciembre",
                            Fecha = new DateTime(2022,12,15),
                            Monto = 15000.95f,
                            Procesado = true,
                        },
                    }
                },
                new Empleado() {
                      Nombre = "Mónica", //6
                    Apellido = "Correa", //6
                    Departamento = Departamento.Soporte,
                    Edad = 22,
                    IdExterno = 5,
                    Pagos = new List<Pago>
                    {
                        new Pago
                        {
                            Descripcion = "Quincena #21: Noviembre",
                            Fecha = new DateTime(2020,11,15),
                            Monto = 18000.95f,
                            Procesado = true,
                        },
                        new Pago
                        {
                            Descripcion = "Quincena #22: Noviembre",
                            Fecha = new DateTime(2020,11,30),
                            Monto = 20000.95f,
                            Procesado = false,
                        }
                    }
                },
            };
            //Reverse
            var filtro = empleados.Where(e => e.Edad <= 30).Reverse();
            ImprimeEmpleados(filtro, "Reverse");
            //Skip
            var fs = filtro.Skip(1);
            ImprimeEmpleados(fs, "Skip");
            //TakeWhile
            var ft = filtro.TakeWhile(e => e.Edad <= 25);
            ImprimeEmpleados(ft, "TakeWhile");
            //GroupBy (ordenar y agrupar)
            var foa = empleados.Where(e => e.Edad <= 30)
                .OrderBy(e => e.Nombre)
                .GroupBy(e => e.Departamento);
            
            //ImprimeEmpleados(foa, "GroupBy");
            foreach (var obj in foa)
            {
                Console.WriteLine("{0}:", obj.Key);
                foreach( var o in obj)
                {
                    Console.WriteLine("  {0}", o.Nombre +" / "+ o.Apellido + " / " + o.Edad);
                }
            
            }

            #region tipos de datos MinValue Maxvalue
            Console.WriteLine("Signed integral types:");

            Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
            Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");

            Console.WriteLine("");
            Console.WriteLine("Unsigned integral types:");

            Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
            Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
            Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");

            Console.WriteLine("");
            Console.WriteLine("Floating point types:");
            Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
            Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
            Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
            Console.WriteLine("");
            #endregion 


            /* OPERADORES DE PROYECCION */
            //SELECT
            var pagos = empleados.Where(e => e.Departamento == Departamento.Desarrollo)
                .Select(e => e.Pagos); //secuencias de secuencias, el mejor operador es el Many
            

            //SELECTMANY
            var pagosB = empleados.Where(e => e.Departamento == Departamento.Desarrollo
                    && e.Pagos != null)
                .SelectMany(e => e.Pagos); //IEnumerable de T.
            //ImprimeEmpleados(pagosB, "SELECT");  ??

            //CUANTIFICADORES devuelven un valor Bool
            //ANY, true si ALGUNO de los elementos cumple la condición.
            var monto = 20000f;
            var existePagoMenor = pagosB.Any(p => p.Monto <= monto);

            //ALL, true unicamente si TODOS los elementos cumplen con la condición.
            var existePagoMayor = pagosB.All(p => p.Monto <= monto);



            /* OPERADORES DE AGREGACION Y CONVERSION */
            //métodos que realizan un cálculo y devuelven un valor escalar. AVERAGE, COUNT, SUM, MAX, MIN
            var pagosEmpleados = empleados.Where(e => e.Pagos != null)
                            .SelectMany(e => e.Pagos, (e, pago) => new
                            {
                                e.Nombre,
                                pago.Descripcion,
                                pago.Monto
                            });

            //AVERAGE, COUNT, SUM, MAX, MIN
            var cantidadPagos = pagosEmpleados.Count(); //total de elementos
            var promedioPagos = pagosEmpleados.Average(p => p.Monto); //Promedio
            Console.WriteLine($"Promedio de monto {promedioPagos}"); //
            var pagoMin = pagosEmpleados.Min(p => p.Monto); //obtenemos el mínimo
            Console.WriteLine($"Pago Mínimo {pagoMin}");

            // Elementos de conversión, array, diccionario, lista, Enum etc.
            var arr = pagosEmpleados.ToArray(); //a arreglo o arraya
            var ls = pagosEmpleados.ToList();   //Lista


            try
            {
                //Operadores de Elemento, regresan un único elemento de una secuencia dada, first, firstOrDefault, Last, LastOrDefault.
                var pago = pagosEmpleados.First(p => p.Monto < 500);
                Console.WriteLine("Pago: { pago.Monto}");
            }
            catch (Exception)
            {

                Console.WriteLine("Pago: NULL");
            }
           
            var pago1 = pagosEmpleados.FirstOrDefault(p => p.Monto < 500); // Contempla el Valor Nulo que puede traer First.
            Console.WriteLine("Pago: {pago1.Monto}");

            //Operador Single
            try
            {
                var spago = pagosEmpleados.Single(pago => pago.Monto == 200); //excepción si no encuentra el elemento.
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                
            }
            var sdpago = pagosEmpleados.SingleOrDefault(pago => pago.Monto == 200);


            //element
            try
            {
                var elpago = pagosEmpleados.ElementAt(10); //excepción si no encuentra el elemento.
              
            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
               
            }
            var eldpago = pagosEmpleados.ElementAtOrDefault(0);

        }

        /*Métodos para imprimir*/
        static void ImprimeEmpleado(Empleado e)
        {
            string fila = string.Format("{0,-40} {1,-10} {2,-20} {3,-10} {4}",
                                        e.Id, e.Nombre, e.Apellido, e.Edad, e.Departamento);
            Console.WriteLine(fila);
        }
        static void ImprimeEmpleados(IEnumerable<Empleado> lista, string titulo = "//** --- **//")
        {
            Console.WriteLine(titulo);
            var encabezado = string.Format("{0,-40} {1,-10} {2,-20} {3,-10} {4}",
                                        "ID", "Nombre", "Apellido", "Edad", "Departamento");
            Console.WriteLine(encabezado);
            foreach (var f in lista)
            {
                string fila = string.Format("{0,-40} {1,-10} {2,-20} {3,-10} {4}",
                    f.Id, f.Nombre, f.Apellido, f.Edad, f.Departamento);
                Console.WriteLine(fila);
            }
        }
    }
}
