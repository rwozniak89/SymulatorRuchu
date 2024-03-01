using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit1.Support;

namespace Unit1
{
    /// <summary>
    /// Klasa Ryba
    /// </summary>
    public class Fish : Animal
    {
        public Fish(string name) : base(name, true) 
        {
            this.IsFreshwater = true;
        }

        public Fish(string name, bool bIsFreshwater):this(name)
        {
            this.IsFreshwater = bIsFreshwater;
        }

        public bool IsFreshwater { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public override void ShowPhoto(Graphics graphics, Point point)
        {
            base.ShowPhoto(graphics, point);

            GraphicsUnit gu = graphics.PageUnit;
            RectangleF rect = this.Photo.GetBounds(ref gu);

            graphics.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public new string GetVertebratesDescr()
        {
            return "ryba kręgowiec";
        }

        public string ToString(bool bFull)
        {
            if (bFull)
            {
                return string.Format("{0}, {1}, {2}", this.Name, IsFreshwater ? "słodkowodna" : "niesłodkowodna", base.GetVertebratesDescr());
            }
            else
                return this.Name;
        }
    }
}
