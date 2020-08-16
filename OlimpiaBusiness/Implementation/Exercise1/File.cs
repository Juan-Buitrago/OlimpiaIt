using OlimpiaBusiness.Interfaces.Exercise1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiaBusiness.Implementation.Exercise1
{
    public class File : IFile
    {
        #region Public Methods
        /// <summary>
        /// Método que lee un fichero de texto de una ruta especifica
        /// </summary>
        /// <param name="path">Url donde se encuentra alojado el fichero</param>
        /// <returns>Retorna una lista de string con el texto que fue obtenido del fichero.</returns>
        public List<string> GetFileContentByPath(string path)
        {
            List<string> data = new List<string>();
            try
            {
                var file = new FileStream(path, FileMode.Open);

                using (StreamReader sr = new StreamReader(file))
                {
                    while (sr.Peek() >= 0)
                    {
                        data.Add(sr.ReadLine());
                    }
                }
                return data;
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"Oops, Ocurrio un problema al intentar acceder al archivo {path}");
            }
            catch (Exception e)
            {
                throw new Exception($"Oops, Ocurrio un problema: {e.Message}");
            }
        }

        /// <summary>
        /// Método que escribe un fichero de texto en una ruta especifica
        /// </summary>
        /// <param name="path">Url donde sera escrito el fichero</param>
        /// <returns>Retorna un booleando indicando si el fichero fue escrito correctamente o no.</returns>
        public bool WriteFileForStringList(List<string> lineText, string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    foreach (var txt in lineText)
                    {
                        var tmp = $"{txt} \r";
                        fs.Write(Encoding.UTF8.GetBytes(tmp), 0, tmp.Length);
                    }
                }
                return true;
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Oops, Ocurrio un problema al intentar acceder al archivo");
            }
            catch (Exception e)
            {
                throw new Exception($"Oops, Ocurrio un problema: {e.Message}");
            }
        }
        #endregion
    }
}
