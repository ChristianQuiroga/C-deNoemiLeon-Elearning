using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanzado2
{
    public class Curso
    {
        internal string Id {  get; set; }
        public string Titulo { get; set; }
        public string Descipcion {  get; set; }
        internal double Duracion { get; set; }
        public byte Nivel { get; set; }

        //para las consultas avanzadas
        public Area Area { get; set; }
        public Instructor InstructorAsignado { get; set; }
    }
}
