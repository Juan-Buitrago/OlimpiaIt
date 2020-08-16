using Ninject;
using Ninject.Modules;
using OlimpiaBusiness.Implementation.Exercise1;
using OlimpiaBusiness.Interfaces.Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Application
{
    class Program
    {
        const string pathDataFile = "Files/Number.txt";
        const string pathResponseDataFile = "Files/Response.txt";
        const string pathFile = "Files";

        static void Main(string[] args)
        {
            System.Console.WriteLine("Test OlimpiaIt");
            try
            {
                IKernel kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());
                IDigit digit = kernel.Get<IDigit>();
                IFile file = kernel.Get<IFile>();

                List<string> numbers = file.GetFileContentByPath(pathDataFile);
                List<string> response = new List<string>();

                numbers.ForEach(delegate (String number)
                {
                    var isMultiple = digit.IsMultipleOfThree(BigInteger.Parse(number));
                    var txt = isMultiple ? "SI" : "NO";
                    response.Add(txt);
                    Console.WriteLine($"El numero {number} {txt} es multiplo de 3");
                });

                if (file.WriteFileForStringList(response, pathResponseDataFile)) {
                    Console.WriteLine($"El fichero de respuesta fue escrito correctamente en: {pathResponseDataFile}");
                }   
            }
            catch (Exception e) {

                Console.WriteLine(e.Message);
            }
            System.Console.WriteLine("Finish Olimpia Test");
            Console.ReadKey();
        }

    }

    public class DependInj : NinjectModule
    {
        public override void Load()
        {
            Bind<IDigit>().To<Digit>();
            Bind<IFile>().To<File>();
        }
    }
}
