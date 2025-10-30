using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Avanzado2
{
    #region Enun Area, para practicas consultas avanzadas LINQ
    public enum Area
    {
        Programacion,
        CSharp,
        JavaScript,
        IteligenciaNegocios,
        CienciaDatos
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Introducción, sintaxis
            //Intro a LinQ (lengyage integrated Query) nueva técnologia con muchas ventajas.
            //Existen Linq to object, linq to slq, ling to XML

            var paisesUE = new List<string>() { "España", "Australia", "Italia", "Alemania", "Dinamarca", "Finlandia" }; //asignamos una List.
            var paisesUEL = new List<string>();
            foreach (var paise in paisesUE) //forma clasica de agregarlo a una lista, para luego recorrerlo.
            {
                if(paise.Length > 6)
                    paisesUEL.Add(paise);
            }

            //con linq lo hacemos en una sola línea.
            //1 obtener fuente de datos, 2 crear una consulta, 3 ejecutar la consulta. ( ejecución Diferida, ejecución Inmediata)
            var paisesUELLinq = paisesUE.Where(p => p.Length > 6); // expresion LANBDA

            Console.WriteLine("Sintaxis métodos");
            paisesUELLinq.ToList().ForEach(p => Console.WriteLine(p));


            //Basada en un consulta. Otra forma.
            var paisesUELLinqB = 
                from p in paisesUELLinq
                where p.Length > 6
                select p;
            Console.WriteLine("Sintaxis consultas");
            paisesUELLinqB.ToList().ForEach(p => Console.WriteLine(p));

            #endregion


            #region Encadenamientos de Operadores
            var paisesUE_1 = new List<string>() { "España", "Australia", "Italia", "Alemania", "Dinamarca", "Finlandia" }; //asignamos una List.
            var paisesUELargos = paisesUE_1.Where(p => p.Length > 6).OrderBy(pa => pa);  //puede ser pa o p. 
            Imprimir("\nPaises en orden", paisesUELargos);  //vamos al método

            var paisMasLargo = paisesUE_1.Where(p => p.Length >= 6).OrderByDescending(p => p.Length).First();
            Console.WriteLine("\nPais mas largo");
            Console.WriteLine(paisMasLargo);

            //con la otra sintaxis de consulta
            var paisesUELargosB = 
                from p in paisesUE_1
                where p.Length > 6
                orderby p
                select p;
            Imprimir("\nPaises en orden - Consulta", paisesUELargosB);  //vamos al método

            #endregion


            #region Subconsulta LINQ
            Console.WriteLine("\nSubconsulta LINQ\n-----------------");
            List<Curso> cursos = new List<Curso>()
            {
                new Curso
                {
                    Id = "ES-prog-001",
                    Titulo = "C# Esencial",
                    Descipcion = "Aprende lo básico e indispensabel de C#",
                    Duracion = 5400,
                    Nivel = 1,
                    Area = Area.CSharp
                },
                new Curso
                {
                    Id = "ES-prog-002",
                    Titulo = "C# Avanzado 1",
                    Descipcion = "Sube tu nivel con C# avanzado 1",
                    Duracion = 10800,
                    Nivel = 2,
                    Area = Area.CSharp
                },
                new Curso
                {
                    Id = "ES-prog-003",
                    Titulo = "LINQ",
                    Descipcion = "Aprende LINQ de cero a experto",
                    Duracion = 18000,
                    Nivel = 2,
                    Area = Area.CSharp
                },
                new Curso
                {
                    Id = "ES-prog-004",
                    Titulo = "Bases de programación",
                    Descipcion = "Aprende sobre algoritmos, estructuras de datos y lenguajes ",
                    Duracion = 21600,
                    Nivel = 1,
                    Area = Area.Programacion
                },
                new Curso
                {
                    Id = "EN-prog-020",
                    Titulo = "Secrets of data Science",
                    Descipcion = "Learn the basics of Data Science",
                    Duracion = 21600,
                    Nivel = 2,
                    Area = Area.CienciaDatos
                }
            };
            //los 3 instructores de avanzado
            var Instructores = new List<Instructor>()
            {
                new Instructor()
                {
                    Nombre = "Noemi Leon",
                    Bio = "Lider de proyectos desarrollo de Software",
                    Area = Area.CSharp
                },
                new Instructor()
                {
                    Nombre = "Danielle Simpson",
                    Bio = "Lead Manager",
                    Area = Area.CienciaDatos
                },
                new Instructor()
                {
                    Nombre = "Cristina Santos",
                    Bio = "Profesora de tiempo Completo en Universidad",
                    Area= Area.IteligenciaNegocios
                }
            };

            var cursosFiltro = cursos.Where(x => x.Duracion <= 18000 && x.Titulo.Contains("C#"))
                .OrderBy(x => x.Nivel)
                .Select(x => new
                {
                    titulo = x.Titulo,
                    nivel = x.Nivel,
                    tiempo = x.Duracion
                });

            cursosFiltro.ToList().ForEach( c=> Console.WriteLine("titulo {0}\nnivel {1}\ntiempo {2}\n", c.titulo, c.nivel, c.tiempo));

            #endregion

            #region Practica Consultas Básicas
            //obtener el título del curso con la menor duración.
            var cursoCorto = cursos.OrderByDescending(x => x.Duracion).FirstOrDefault();
            Console.WriteLine("Curso mas corto {0}, dura {1} ms ",  cursoCorto.Titulo, cursoCorto.Duracion);
            //Obtener 
            var cursosGruposNivel = cursos.Where(p => p.Id.Contains("ES"))
                .Select(c => new
                {
                    c.Id,
                    c.Titulo,
                    grupoNivel = c.Nivel
                }).GroupBy(nc => nc.grupoNivel);

            //cursosGruposNivel.ToList().ForEach(nc => Console.WriteLine("Id {0}\n titulo {1}\n Titulo {2}\n", nc.ToList(IDictionary) ));


            #endregion

            #region para practicas consultas avanzadas LINQ
            //
            var cursosPorInstructor = cursos.Where(x => x.Id.Contains("prog"))
                .Join(Instructores,
                    c => c.Area,
                    i => i.Area,
                    (c,i) => new
                    {
                        c.Id,
                        c.Titulo,
                        c.Nivel,
                        instructor = i.Nombre
                    }
                ).GroupBy(ci => ci.instructor);

            #endregion,
            Console.ReadLine();
        }

        static void Imprimir(string titulo, IEnumerable<string> ie)
        {
            Console.WriteLine(titulo);
            ie.ToList().ForEach(p => Console.WriteLine(p)); //IEnumerable
        }
    }
}
