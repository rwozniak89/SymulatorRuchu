using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2.Support
{
    /// <summary>
    /// Klasa kalkulacji.
    /// </summary>
    public class Calculations
    {
        /// <summary>
        /// Konstruktor prywatnu.
        /// Zakłada się, że klasa będzie posiadać tylko metody i właściwości statyczne.
        /// </summary>
        private Calculations() { }

        /// <summary>
        /// Przelicza radiany na stopnie.
        /// </summary>
        /// <param name="dRad"></param>
        /// <returns></returns>
        public static double Rad2Deg(double dRad)
        {
            return (180.0 / Math.PI) * dRad;
        }

        /// <summary>
        /// Przelicza stopnie na radiany.
        /// </summary>
        /// <param name="dDeg"></param>
        /// <returns></returns>
        public static double Deg2Rad(double dDeg)
        {
            return dDeg * Math.PI / 180.0;
        }

        /// <summary>
        /// Wyznacza wektor jednostkowy dla wektora vec.
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        static SizeF GetNormalVec(SizeF vec)
        {
            double dSize = Math.Sqrt(vec.Width * vec.Width + vec.Height * vec.Height);

            if (dSize != 0)
            {
                return new SizeF((float)(vec.Width / dSize), (float)(vec.Height / dSize));
            }
            else
                return vec;
        }

        /// <summary>
        /// Wyznacza wektor kierunkowy dla kąta angleDeg.
        /// </summary>
        /// <param name="angleDeg">Kąt między osią OX zgodnie z kierunkiem ruchu wskazówek zegara [deg].</param>
        /// <returns></returns>
        public static SizeF GetVecFromAngle(double angleDeg)
        {
            //  II  |  I
            // -----------
            //  III |  IV

            double x = 0, y = 0;
            double angleRad = Deg2Rad(angleDeg % 360); // Przeliczenie kąta do zakresu [0 .. 360>


            double distans = 1.0f;
            //Solution 1: https://copyprogramming.com/howto/c-how-to-move-point-a-given-distance-d-and-get-a-new-coordinates
            double x2 = distans * Math.Cos(angleRad);
            double y2 = distans * Math.Sin(angleRad);


            //return GetNormalVec(pointOut);
            return new SizeF((float)x2, (float)y2);

            ///albo inne rozwiazanie
            // na osi OX
            if (angleRad == 0.0)
            {
                x = 1;
                y = 0;
            }
            else
            {
                int vec1;

                if (angleRad < 0)
                {
                    vec1 = Math.Abs((int)(angleRad / (2 * Math.PI))) + 1;
                    angleRad += 2 * Math.PI * vec1;
                }
                else
                {
                    if (angleRad > (2 * Math.PI))
                    {
                        vec1 = (int)(angleRad / (2 * Math.PI));
                        angleRad -= 2 * Math.PI * vec1;
                    }
                }

                // na osi OY
                if (angleRad == (Math.PI / 2))
                {
                    x = 0;
                    y = 1;
                }
                else
                {
                    // na osi -OX
                    if (angleRad == Math.PI)
                    {
                        x = -1;
                        y = 0;
                    }
                    else
                    {
                        if (angleRad == (Math.PI * 1.5))
                        {
                            x = 0;
                            y = -1;
                        }
                        else
                        {
                            // w I ćwiartce
                            if ((angleRad > 0) && (angleRad < (Math.PI / 2)))
                            {
                                x = 1;
                                y = Math.Tan(angleRad);
                            }
                            else
                            {
                                // w II ćwiartce
                                if ((angleRad > (Math.PI / 2)) && (angleRad < Math.PI))
                                {
                                    x = -1;
                                    y = -Math.Tan(angleRad);
                                }
                                else
                                {
                                    // w III ćwiartce
                                    if ((angleRad > Math.PI) && (angleRad < (Math.PI * 1.5)))
                                    {
                                        x = -1;
                                        y = -Math.Tan(angleRad);
                                    }
                                    else
                                    {
                                        // w IV ćwiartce
                                        if ((angleRad > (Math.PI * 1.5)) && (angleRad < (Math.PI * 2)))
                                        {
                                            x = 1;
                                            y = Math.Tan(angleRad);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return GetNormalVec(new SizeF((float)x, (float)y));
        }

        public static SizeF GetVecFromAngle2(double angleDeg)
        {
            double x = 0, y = 0;
            double angleRad = Deg2Rad(angleDeg % 360); // Przeliczenie kąta do zakresu [0 .. 360>

            x = Math.Cos(angleRad);
            y = Math.Sin(angleRad);
            return GetNormalVec(new SizeF((float)x, (float)y));
        }
    }
}
