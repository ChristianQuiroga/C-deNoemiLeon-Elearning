namespace _3_5OperadoresJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Empleados
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
            //Pagos
            var nPagos = new List<Pago>()
            {
                new Pago
                {
                    Descripcion = "Quincena Junio",
                    Fecha = new DateTime(2020,06,15),
                    Monto = 12000.95f,
                    Procesado = true,
                    IdExternoEmpleado = 2
                },
                new Pago
                {
                    Descripcion = "Quincena Septiembre",
                    Fecha = new DateTime(2020,06,30),
                    Monto = 22000.95f,
                    Procesado = false,
                    IdExternoEmpleado = 3
                },
                new Pago
                {
                    Descripcion = "Bono Diciembre",
                    Fecha = new DateTime(2020,12,15),
                    Monto = 50000.00f,
                    Procesado = true,
                    IdExternoEmpleado = 3
                }
            };

            //JOIN
            // para evitar ciclos anidados, usamos el JOIN
            // SExterna, SInterna, llaveExterna (idExterno), llaveInterna (idInterno), proyeccion de lo que queremos se devuelva.
            var empleadosPAgo = empleados.Join(nPagos,
                                    emp => emp.IdExterno,
                                    pago => pago.IdExternoEmpleado,
                                    (emp, pago) => new
                                    {
                                        emp.Nombre,
                                        pago.Monto
                                    });

            //Imprimir
            foreach(var e in empleadosPAgo)
            {
                Console.WriteLine(e);
            }

            //GroupJoin
            var empleadosPagosGrupo = empleados.GroupJoin(nPagos,
                                        emp => emp.IdExterno, //llave selectora
                                        pago => pago.IdExternoEmpleado, //
                                        (emp, pagos) => new  //hacemos la proyección o sea el SELECT
                                        {
                                            Empleado = emp.Nombre,
                                            PagoAgregados = pagos
                                        });

            //imprimir
            foreach(var e in empleadosPagosGrupo)
            {
                if (e.PagoAgregados.Count() > 0)
                    Console.WriteLine(e.Empleado);
                    foreach (var p in e.PagoAgregados)
                        Console.WriteLine(p.Monto);
            }
        }
    }
}
