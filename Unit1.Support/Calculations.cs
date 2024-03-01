using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1.Support
{
    /// <summary>
    /// Klasa publiczna w ramach zestawu (assembly).
    /// </summary>
    internal class Calculations
    {
    }

    /// <summary>
    /// Klasa zawierajaca tylko metody statyczne.
    /// </summary>
    public class Calculations2
    {
        /// <summary>
        /// Prywatny konstruktor zapobiega tworzeniu instamcji klasy.
        /// </summary>
        private Calculations2() { }

        /// <summary>
        /// Przykładowa metoda statyczna.
        /// </summary>
        /// <param name="dRad"></param>
        /// <returns></returns>
        public static double Rad2Deg(double dRad)
        {
            return (180.0 / Math.PI) * dRad;
        }
    }

    /// <summary>
    /// Klasa zawierajaca tylko metody statyczne.
    /// </summary>
    public static class Calculations3
    {
        static double _MyPI;

        /// <summary>
        /// Klasa statyczna - statyczny konstruktor.
        /// </summary>
        static Calculations3()
        {
            _MyPI = Math.PI;
        }

        /// <summary>
        /// Przykładowa metoda statyczna.
        /// </summary>
        /// <param name="dRad"></param>
        /// <returns></returns>
        public static double Rad2Deg(double dRad)
        {
            return (180.0 / _MyPI) * dRad;
        }
    }
}
