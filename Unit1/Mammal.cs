using Unit1.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1
{
    /// <summary>
    /// Zywienie
    /// </summary>
    public enum En_Nutrition
    {
        /// <summary>
        /// Mięsożerny
        /// </summary>
        Carnivorous = 0,
        /// <summary>
        /// Roślinożerny
        /// </summary>
        Herbivorous = 1,
        /// <summary>
        /// Wszystkożerny
        /// </summary>
        Omnivorous = 2
    }

    /// <summary>
    /// Klasa Ssak
    /// </summary>
    public class Mammal : Animal
    {
        public Mammal(string name) : base(name, true)
        {
        }

        public Mammal(string name, bool bLiveability, En_Nutrition nutrition) : base(name, true)
        {
            this.Liveability = bLiveability;
            this.Nutrition = nutrition;
        }

        /// <summary>
        /// Czy sposób rozrodu do żyworodność.
        /// W p.p. jajorodność.
        /// </summary>
        public bool Liveability { get; set; } = true;

        /// <summary>
        /// Żywienie.
        /// </summary>
        public En_Nutrition Nutrition { get; set; } = En_Nutrition.Omnivorous;
    }
}
