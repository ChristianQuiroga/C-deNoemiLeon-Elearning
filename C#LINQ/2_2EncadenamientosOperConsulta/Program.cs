
namespace _2_2EncadenamientosOperConsulta
{
    public class Program
    {

        static void Main(string[] args)
        {
            /*Operadores de Consulta ESTANDAR
             * 
             * Filtrado => Where, Take, TakeWhile, Skip...
             * Ordenado => OrderBy, OrderByDescending, then, Reverse...
             * Agrupado => GroupBy,...
             * 
             * Proyección => Select, SelectMany
             * Conversion => ToArray, ToDictionary, Tolist, AsEnumerable
             * Join => Join, GroupJoin
             * 
             * Elemento => Element, ElementAtOrDefault, First, Last, Single...
             * Agregación => Average, Count, Sum, Max, Min, Aggregat, LongCount
             * Cuantificación => All, Any, Contains, SequenceEqual
             */

            List<Empleado> empleados = new List<Empleado>()
            {
                new Empleado() {
                    Nombre = "Daniela", //7
                    Apellido = "Perez",//5
                    Departamento = Departamento.Desarrollo
                },
                new Empleado() {
                    Nombre = "Jose", //4
                    Apellido = "Lima Rico", //9
                    Departamento = Departamento.Desarrollo
                },
                new Empleado() {
                    Nombre = "Fernanda", //8
                    Apellido = "Vega Valle", //10
                    Departamento = Departamento.Desarrollo
                },
                new Empleado() {
                      Nombre = "Fabiola", //7
                    Apellido = "Cortés Vázques", //14
                    Departamento = Departamento.Desarrollo
                },
                new Empleado() {
                      Nombre = "Mónica", //6
                    Apellido = "Correa", //6
                    Departamento = Departamento.Soporte
                },
            };

            //obtener los empleados del dep. que su nombre empiece con F, del depto de Desarrollo.
            var em = empleados.Where(u => u.Departamento == Departamento.Desarrollo
                                && u.Nombre.ToLower().Contains("f"));

            var enOrdenado = em.OrderBy(u => u.Id);
            imprimir(enOrdenado);


            //otra forma mucho mas rápida. Con el método ENCADENADO  Order by.(tiene que ser compatible primero método con el ultimo método)
            var em1 = empleados.Where(u => u.Departamento == Departamento.Desarrollo
                                && u.Nombre.ToLower().Contains("f")).OrderBy(u => u.Id);
            imprimir(em1);

            //acá tenemos 3 métodos encadenados, where, orderby, select, se pueden agregar varias mientras sean compatibles una con la otra.
            var filtro = empleados.Where(u => u.Departamento == Departamento.Desarrollo
                               && u.Nombre.ToLower().Contains("f"))
                            .OrderBy(u => u.Id)
                            .Select(u => new  //generamos un objeto nuevo con SELECT
                            {
                                u.Id,
                                u.Nombre,
                                InicialAp = u.Apellido.Substring(0, 1),
                                Depto = u.Departamento.ToString()
                            });

            var encabezado = string.Format("{0,-40} {1,-10} {2,-10} {3}",
                "ID", "Nombre", "Apellido", "Departamento");
            Console.WriteLine(encabezado);
            foreach (var f in filtro)
            {
                string fila = string.Format("{0,-40} {1,-10} {2,-10} {3}",
                    f.Id, f.Nombre, f.InicialAp, f.Depto);
                Console.WriteLine(fila);
            }

            //PRACTICA
            var filtro2 = empleados.Where(e => (e.Departamento == Departamento.Soporte
                                                || e.Departamento == Departamento.Desarrollo)
                                && e.Apellido.ToLower().StartsWith("c"))
                            .OrderByDescending(e => e.Nombre)
                            .Select(e => new
                            {
                                e.Nombre,
                                e.Apellido,
                                e.Departamento
                            });

            /*Ejecución diferida, tiene ventajas ante la ejecución de datos y sincronización de datos*/
            Console.WriteLine("/**Ejecución Diferida **/");
            var empleadoNuevos = new List<Empleado>
            {
                 new Empleado
                 {
                    Nombre = "Fabricio", //8
                    Apellido = "Cordero",//7
                    Departamento = Departamento.Desarrollo
                },
                  new Empleado() {
                    Nombre = "Julia", //5
                    Apellido = "Lombardo",//8
                    Departamento = Departamento.Admin
                },
            };
            empleados.AddRange(empleadoNuevos);
            /*Ejecución diferida*/


            /*Ejecución inmediata, "Lazy execution"
             * se ejecuta Linq con operadores de conversion o elementos únicos. */
            //var filtroArr = filtro2.ToArray();
            var filtroArr = filtro2.FirstOrDefault();

            var encabezado1 = string.Format("{0,-10} {1,-20} {2}",
                 "Nombre", "Apellido", "Cod. Departamento");
            Console.WriteLine(encabezado1);
            foreach (var f in filtro2) //linq recien se Ejecuta acá
            {
                string fila = string.Format("{0,-10} {1,-20} {2}",
                   f.Nombre, f.Apellido, f.Departamento);
                Console.WriteLine(fila);
            }


            //Pasamos a sintaxis con expresiones Basadas en consulta.
            var qe = from e in empleados
                     where (e.Departamento == Departamento.Soporte
                            || e.Departamento == Departamento.Desarrollo)
                            && e.Apellido.ToLower().StartsWith("c")
                     orderby e.Nombre ascending
                     select new
                     {
                         e.Nombre,
                         e.Apellido,
                         Depto = e.Departamento
                     };
            Console.WriteLine();
            foreach (var f in qe)
            {
                string fila = string.Format("{0,-10} {1,-20} {2}",
                   f.Nombre, f.Apellido, f.Depto);
                Console.WriteLine(fila);
            }


            /*Subconsultas LINQ*/
            var subq = empleados.Where(e => e.Apellido.Split()  //divido la cadena
                            .LastOrDefault()                    //busco el último
                            .StartsWith("V"));                  //que comience con V.
            Console.WriteLine("\n/*Subconsultas LINQ*/");
            imprimir(subq);

            /*Practica SUBCONSULTAS */
            // el apellido mas corto PEREZ de 5 caracteres!
            // y el nombre de 5 caracteres es Julia. Se muestra Julia y su apellido es Lombardo.
            var subq1 = empleados.Where(e => e.Nombre.Length == empleados
                                        .OrderBy(eb => eb.Apellido.Length)
                                        .Select(eb => eb.Apellido.Length)
                                        .First());
            //Console.Clear();                                    
            Console.Write("/*Practica SUBCONSULTAS */");
            imprimir(subq1, true);

            //SUBCONSULTA Pasamos a sintaxis con expresiones de consulta.
            // el apellido mas corto PEREZ de 5 caracteres!
            // y el nombre de 5 caracteres es Julia. Se muestra Julia y su apellido es Lombardo.
            var qeSub = from e in empleados
                        where e.Nombre.Length ==
                        (from eb in empleados
                         orderby eb.Apellido.Length
                         select eb.Apellido.Length
                        ).First()
                        select e;
            Console.Write("/*Practica SUBCONSULTAS Sintaxis de expresiones */");
            imprimir(qeSub, true);
            //otra forma
            var qeSub1 = from e in empleados
                         where e.Nombre.Length ==
                         empleados.OrderBy(eb => eb.Apellido.Length).First().Apellido.Length
                         select e;
            Console.Write("/*Practica Otra forma SUBCONSULTAS Sintaxis de expresiones */");
            imprimir(qeSub1, true);
        }


        #region Métodos
        private static void imprimir(IEnumerable<Empleado> filtro)
        {
            var encabezado = string.Format("{0,-40} {1,-10} {2,-20} {3}",
                "ID", "Nombre", "Apellido", "Departamento");
            Console.WriteLine(encabezado);
            foreach (var f in filtro)
            {
                string fila = string.Format("{0,-40} {1,-10} {2,-20} {3}",
                    f.Id, f.Nombre, f.Apellido, f.Departamento);
                Console.WriteLine(fila);
            }
            Console.WriteLine("\n");

        }
        private static void imprimir(IEnumerable<Empleado> filtro, bool a)
        {
            var encabezado = string.Format("{0,-20} {1}",
                "Nombre", "Apellido");
            Console.WriteLine("\n"+encabezado);
            foreach (var f in filtro)
            {
                string fila = string.Format("{0,-20} {1}",
                    f.Nombre, f.Apellido);
                Console.WriteLine(fila);
            }
            Console.WriteLine("\n");

        }
        #endregion
    }
}
