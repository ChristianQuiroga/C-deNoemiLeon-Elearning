using Newtonsoft.Json.Linq;

namespace _4_3ObjetosJsonYConsultasLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            JObject obj = JObject.Parse(@"{
                'nombre': 'Jonh Doe',
                'nivel': 'Junior',
                'edad': 25,
                'lenguajes': ['.NET','PHP']
            }");
            string nivel = (string)obj["nivel"];
            Console.WriteLine(nivel);


            //podemos hacer consultas linq al objeto
            IList<string> lenguajes = obj["lenguajes"].Select(l => (string)l).ToList();
            foreach (var l in lenguajes)
            {
                Console.WriteLine(l);
            }
        }
    }
}
