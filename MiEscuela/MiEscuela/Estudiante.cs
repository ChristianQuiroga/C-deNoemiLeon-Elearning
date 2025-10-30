using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MiEscuela
{
    internal class Estudiante
    {
        public int Id { get; set; }
        private string Matr {  get; set; }
        public string Nombre { get; set; }
        public string GradoGrupo { get; set; }
        public bool Estatus { get; set; }
       
        #region Métodos
        public string Registrar() //se puede decir que es como una Funtion()
        {
            //se puede registrar en la BD
            string resp = "Alumno registrado";
            return resp;
        }
        public string DarDeBaja()
        {
            this.Estatus = false;
            //Editar en la BD el registro
            // metodo EditarRegistroEnDB()
            string resp = "Alumno dado de baja";
            return resp;
        }

        //sobrecarga de método
        public string DarDeBaja(string motivo = "")
        {
            this.Estatus = false;
            //edit in DB.
            string resp = "";
            if (motivo != "")
            {
                resp = "Alumno dado de baja. Motivo: " + motivo;
            }
            else
            {
                resp = "Alumno dado de baja";
            }
            
            return resp;
        }

        //sobrecarga de método 2, con diferentes parámetros.
        public void DarDeBaja(string cveUsuario, string pwd, string motivo)
        {
            //consultar que el usuario tiene los permisos requeridos
            //verificarUsuario(cveUsuario, pwd)
            //Si usuario verificado :
            //eliminar el registro del estudianten
            //guardar el movimiento en un log.
 
        }

        #endregion

        #region Constructor con PARAMETROS!
        public Estudiante(string nombre, string gradoGrupo)
        {
            Nombre = nombre;
            GradoGrupo = gradoGrupo;
        }
        //sobrecarga de constructor
        public Estudiante(bool estatus)
        {
            Estatus = estatus;
            Nombre = "";
        }
        #endregion
    }
}
