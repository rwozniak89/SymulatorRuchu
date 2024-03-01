using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1.Support
{
    //internal protected class Animal

    /// <summary>
    /// Klasa Zwierzę
    /// </summary>
    public class Animal : IPresentation, IAttributes
    {
        public Animal(string name, bool bVertebrates)
        {
            this.Name = name;
            this.Vertebrates = bVertebrates;
        }

        /// <summary>
        /// Nazwa
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Opis
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Czy kręgowce?
        /// </summary>
        public bool Vertebrates { get; set; } = true;

        /// <summary>
        /// Zdjęcie pokazowe.
        /// </summary>
        public Image Photo { get; set; } = null;

        /// <summary>
        /// Prezentacja zdjęcia.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="point"></param>
        public virtual void ShowPhoto(Graphics graphics, Point point)
        {
            if(graphics != null && this.Photo != null)
            {
                graphics.DrawImage(this.Photo, point);
            }
        }

        public string GetVertebratesDescr()
        {
            return this.Vertebrates ? "kręgowiec" : "bezkręgowiec";
        }

        #region Klasy wewnętrzne

        private class PrivateAnimal
        {
            public string Name { get; set; }
        }

        protected class ProtectedAnimal
        {
            public string Name { get; set; }
        }

        internal protected class InternalProtectedAnimal
        {
            public string Name { get; set; }
        }

        #endregion
    }
}
