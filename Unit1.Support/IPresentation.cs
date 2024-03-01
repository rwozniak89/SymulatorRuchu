using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1.Support
{
    /// <summary>
    /// Prezentacja
    /// </summary>
    interface IPresentation
    {
        /// <summary>
        /// Zdjęcie poglądowe
        /// </summary>
        Image Photo { get; set; }

        /// <summary>
        /// Prezentacja zdjęcia
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="point"></param>
        void ShowPhoto(Graphics graphics, Point point);
    }
}
