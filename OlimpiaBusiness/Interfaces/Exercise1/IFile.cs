using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiaBusiness.Interfaces.Exercise1
{
    public interface IFile
    {
        /// <summary>
        /// Método que lee un fichero de texto de una ruta especifica
        /// </summary>
        /// <param name="path">Url donde se encuentra alojado el fichero</param>
        /// <returns>Retorna una lista de string con el texto que fue obtenido del fichero.</returns>
        List<string> GetFileContentByPath(string path);

        /// <summary>
        /// Método que escribe un fichero de texto en una ruta especifica
        /// </summary>
        /// <param name="path">Url donde sera escrito el fichero</param>
        /// <returns>Retorna un booleando indicando si el fichero fue escrito correctamente o no.</returns>
        bool WriteFileForStringList(List<string> lineText, string path);
    }
}
