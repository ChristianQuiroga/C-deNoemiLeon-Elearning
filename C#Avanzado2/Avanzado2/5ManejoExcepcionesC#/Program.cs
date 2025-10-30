using System.Diagnostics.CodeAnalysis;

namespace _5ManejoExcepcionesC_
{
    internal class Program
    {
        static void Main()
        {
            //esta es la estructura o esqueleto.

            //try
            //{
            //    //codigo sujeto a errores
            //}
            //catch (Exception e)
            //{

            //    //throw;
            //    //que queremos hacer en caso de error
            //}
            //finally
            //{
            //    //Se ejecuta independientemente del error.
            //}

            var total = Divicion(5, 2);
            Console.WriteLine(total);

            //llamamos al método IO
            Console.WriteLine("Nombre del Archivo");
            var archivo = Console.ReadLine(); 
            GuardarResultados(total.ToString(), archivo); //Usamos un sobre carga para que no de ERROR
            Console.ReadLine();

        }

        //Ejemplo con divisor CERO
        //creamos una funtion()
        static double Divicion(int divisor, int dividendo)
        {
            var res = 0.0;
            //var res = 0D;
            try
            {
                res = divisor / dividendo;
                //res = (double)divisor / dividendo;
            }
            catch (DivideByZeroException ex)
            {
                //guardar el error o imprimir
                //throw;
                Console.WriteLine(ex);
            }
            catch (Exception ex) //No abusar de muchos CATCH
            {
                Console.WriteLine(ex);
            }

            return res;
        }

        //Ejemplo del finally
        static void GuardarResultados(string resultado)
        {
            string ruta = @"c:\tmp1\resultado.txt";
            try
            {
                using (StreamWriter sw = File.AppendText(ruta))
                {
                    sw.WriteLine(resultado + "\n"); //salto de linea \n
                }
            }
            catch (IOException e) //IOExc. cuando se manejan archivos.
            {

                Console.WriteLine("Error leyendo archivo {0}. \nMensaje {1}.", ruta, e.Message);
            }
            finally
            {
                if (!File.Exists(ruta)) //si no existe hacemos algo para crear el archivo
                {
                    using StreamWriter sw = File.CreateText(ruta);
                    File.AppendText($"Ha ocurrido un error, en {DateTime.Now}");
                } 
            }
        }

        //Overload o sobrecarga
        static void GuardarResultados(string resultado,string archivo) 
        {

            var ruta = "";

            try
            {
                if (!archivo.Contains(".txt"))
                    //throw new Exception("Formato de archivo incorrecto "); //arrojamos una excepción! throw, Generica.
                    throw new FormatoArchivoException($"Archivo utilizado: {archivo}");

                ruta = $@"C:\tmp\{archivo}";

                using (StreamWriter sw = File.AppendText(ruta))
                {
                    sw.WriteLine(resultado + "\n");
                }
            }
            catch (IOException e)
            {

                Console.WriteLine("Error leyendo archivo {0}." + " mensaje = {1}", ruta, e.Message);
            }
            //catch(Exception e) 
            //{
            //    //excepcion Generica throw
            //    Console.WriteLine(e);
            //}
            catch (FormatoArchivoException formatoEx) when (archivo.Contains(".pdf"))
            {
                Console.Write(formatoEx.ToString());
                //Console.WriteLine("formato PDF");
            }
            catch (FormatoArchivoException formatoEx) when (archivo.Contains(".xls"))
            {
                Console.WriteLine("formato XLS");
            }
        }
    }
}
