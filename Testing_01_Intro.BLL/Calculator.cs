using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_01_Intro.BLL.CustomExceptions;

namespace Testing_01_Intro.BLL
{
    /// <summary>
    /// Calculatrice avec un précision de 6 chiffres après la virgule
    /// </summary>
    public class Calculator
    {
        private const int PRECISION = 6;

        /// <summary>
        /// Addition de deux nombres
        /// </summary>
        /// <param name="nb1">Nombre 1</param>
        /// <param name="nb2">Nombre 2</param>
        /// <returns>Somme des deux nombres</returns>
        public double Add(double nb1, double nb2)
        {
            double result = nb1 + nb2;
            return FormatResult(result);
        }

        /// <summary>
        /// Soustraction de deux nombres
        /// </summary>
        /// <param name="nb1">Nombre 1</param>
        /// <param name="nb2">Nombre 2</param>
        /// <returns>Resultat de la soustraction</returns>
        public double Sub(double nb1, double nb2)
        {
            double result = nb1 - nb2;
            return FormatResult(result);
        }

        /// <summary>
        /// Multiplciation de deux nombres
        /// </summary>
        /// <param name="nb1">Nombre 1</param>
        /// <param name="nb2">Nombre 2</param>
        /// <returns>Resultat de la multiplication</returns>
        public double Multi(double nb1, double nb2)
        {
            double result =  nb1 * nb2;
            return FormatResult(result);
        }

        /// <summary>
        /// Division de deux nombres
        /// </summary>
        /// <param name="nb1">Nombre 1</param>
        /// <param name="nb2">Nombre 2</param>
        /// <returns>Resultat de la division</returns>
        /// <exception cref="DivByZeroCalculatorException"></exception>
        public double Div(double nb1, double nb2)
        {
            if (nb2 == 0)
            {
                throw new DivByZeroCalculatorException();
            }

            double result = nb1 / nb2;
            return FormatResult(result);
        }

        private double FormatResult(double result)
        {
            if (double.IsInfinity(result))
            {
                throw new OutOfRangeCalculatorException();
            }
            return Math.Round(result, PRECISION);
        }
    }
}
