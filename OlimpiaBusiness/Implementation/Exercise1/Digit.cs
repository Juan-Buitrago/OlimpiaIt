using OlimpiaBusiness.Implementation.Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiaBusiness.Interfaces.Exercise1
{
    public class Digit: IDigit
    {
        #region Public Methods

        /// <summary>
        /// Método que permite validar si un numero es multiplo de 3
        /// </summary>
        /// <param name="number">Numero entero el cual va a ser validado</param>
        /// <returns>Retorna un bool indicando si es multiplo o no.</returns>
        public bool IsMultipleOfThree(int number) {

            return IsDivisible(number, 3);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Método que permite validar si un numero es divisible entre otro
        /// </summary>
        /// <param name="x">Numero entero el cual va a ser dividido entre otro</param>
        /// <param name="n">Numero entero el cual va a ser dividido entre otro</param>
        /// <returns>Retorna un bool indicando si es divisible o no.</returns>
        private bool IsDivisible(int x, int n)
        {
            return (x % n) == 0;
        }
        #endregion
    }
}
