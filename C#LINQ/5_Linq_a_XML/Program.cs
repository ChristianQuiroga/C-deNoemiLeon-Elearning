using System.Xml.Linq;

namespace _5_Linq_a_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //System.Xml.LINQ EXTENSIBLE MARKUP LENGUAJE (lenguaje de marcado)
            // USING SYSTEM.XML.LINQ => ESPACIO DE NOMBRES (interfaz que nos permite manipular y modificar doc. xml)

            /* XDocument
             * XDeclaration
             * XElement
             * XAtribute
             * XComment
             */

            var archivo = @"C:\Users\christian.quiroga\OneDrive - WiseTech Global Pty Ltd\Documents\CURSOS CODERHOUSE\C#deNoemiLeon Elearning\C#LINQ\5_Linq_a_XML\pagos.XML";
            var docXML = XDocument.Load(archivo);  //método load 
            var pagosProcesados = docXML.Element("pagos").Elements("pago") //método Element
                .Where(p => p.Attribute("procesado")?.Value == "true") //? Evalua si el atributo es nulo.
                .Select(p => p.Element("descripcion").Value);

            foreach (var p in pagosProcesados)
            {
                Console.WriteLine(p);
            }

            /*CREANDO TUPLAS A PARTIR DE XML
             */
            var archivo1 = @"C:\Users\christian.quiroga\OneDrive - WiseTech Global Pty Ltd\Documents\CURSOS CODERHOUSE\C#deNoemiLeon Elearning\C#LINQ\5_Linq_a_XML\pagos.XML";
            var docXML1 = XDocument.Load(archivo1);

            var pagos1 = docXML1.Descendants("pago")
                .Where(p => p.Attribute("procesado")?.Value == "true")
                .Select(p => new Tuple<string, bool, string, float>
                (
                    p.Attribute("idEmpleado").Value,
                    bool.Parse(p.Attribute("firmado").Value),
                    p.Element("descripcion").Value,
                    float.Parse(p.Element("montoBase").Value)
                ));
        }
    }
}
