using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1.Support
{
    /// <summary>
    /// Atrybuty
    /// </summary>
    interface IAttributes
    {
        /// <summary>
        /// Nazwa
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Opis
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Czy kręgowce?
        /// </sum
        bool Vertebrates { get; set; }
    }
}
