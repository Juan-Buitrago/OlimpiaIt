using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OlimpiaBusiness.Implementation.Exercise1
{
   public interface IDigit
    {
        /// <summary>
        /// Método que permite validar si un numero es multiplo de 3
        /// </summary>
        /// <param name="number">Numero entero el cual va a ser validado</param>
        /// <returns>Retorna un bool indicando si es multiplo o no.</returns>
        bool IsMultipleOfThree(BigInteger number);
    }
}
