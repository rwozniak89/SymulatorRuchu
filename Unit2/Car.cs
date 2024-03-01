using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Unit2
{
    /// <summary>
    /// Rodzaj paliwa
    /// </summary>
    [Serializable]
    public enum En_DriveSource
    {
        /// <summary>
        /// Benzyna
        /// </summary>
        Petrol,
        /// <summary>
        /// Diesel
        /// </summary>
        Diesel,
        /// <summary>
        /// Gaz
        /// </summary>
        Gas,
        /// <summary>
        /// Elektryczny
        /// </summary>
        Electric,
        /// <summary>
        /// Hybryda
        /// </summary>
        Hybrid
    }
    [Serializable]
    public sealed class Car : Vehicle
    {
        #region Fields
        [NonSerialized]
        Brush _CarBodyBrush;
        [NonSerialized]
        Pen _CarEdgePen;

        #endregion

        public Car(int id) : base(id)
        {
            InitNoSerialized();

        }

        protected override void InitNoSerialized()
        {
            base.InitNoSerialized();
            _CarBodyBrush = Brushes.YellowGreen;
            _CarEdgePen = new Pen(Color.Blue, 0.1f); // szerokość mała, aby po przeskalowniu była 1.0f
        }

        #region Dispose

        protected override void Dispose(bool disposeManagedObjs)
        {
            base.Dispose(disposeManagedObjs);
            if (!_HasBeenDisposed)
            {
                try
                {
                    if (disposeManagedObjs)
                    {
                        // Wywołanie metod Dispose/Close/Clear dla zarządzanych obiektów
                        if(_CarEdgePen != null)
                        {
                            _CarEdgePen.Dispose();
                            _CarEdgePen = null;
                        }
                    }
                    base.Dispose(disposeManagedObjs);
                }
                catch (Exception)
                {
                    _HasBeenDisposed = false;
                    throw;
                }
                _HasBeenDisposed = true;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Typ pojazdu.
        /// </summary>
        public override string NameOf { get => "Samochód"; }

        /// <summary>
        /// Źródło napędu pojazdu.
        /// </summary>
        [DisplayName("Paliwo")]
        [CategoryAttribute("Samochód"), DescriptionAttribute("Paliwo samochodu")]
        public En_DriveSource DriveSource { get; set; } = En_DriveSource.Petrol;

        #endregion

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false; 
            // Odkomentarzować, gdy klasa bazowa też nadpisuje Equals()
            //if(!base.Equals(obj))
            //    return false;
            // Warunek 1: obiekty porównywalne muszą istnieć.
            if (obj == null)
                return false;
            // Warunek 2: obiekty porównywalne muszą być tymi samymi typami.
            if (this.GetType() != obj.GetType())
                return false;
            // Warunek 3: porównanie pól referencyjnych (jeśli istnieją).
            // Warunek 3a: porównanie referencji na obiekty (do uzgodnienia).
            //if(!Object.ReferenceEquals(this, obj))
            //    return false;
            Car v = obj as Car;
            // Warunek 4: porównanie pól wartościowych.


            if (!this.DriveSource.Equals(v.DriveSource))
                return false;

            return true;
        }

        public override void Draw(Graphics graphics, PointF position, float fScale, float fCourse)
        {
            float fWidth2 = this.Size.Width / 2.0f;
            float fHeight2 = this.Size.Height / 2.0f;
            // Zapamiętanie domyślnego układu współrzędnych
            Matrix mOld = graphics.Transform;
            // Utworzenie nowego układu współrzędnych:
            // - ze środkiem układu współrzędnych w (0, 0) w this.Position
            // - osiami układu jak w układzie kartezjańskim
            // - ze skalą this.Scale
            // - obrotem this.Angle
            Matrix mNew = new Matrix();

            mNew.Translate(position.X, position.Y);
            mNew.Scale(fScale, fScale);
            mNew.Rotate(fCourse);

            graphics.Transform = mNew;  // Ustawienie układu współrzędnych na mNew

            graphics.FillRectangle(_CarBodyBrush, -fWidth2, -fHeight2, this.Size.Width, this.Size.Height);
            graphics.DrawRectangle(_CarEdgePen, -fWidth2, -fHeight2, this.Size.Width, this.Size.Height);
            graphics.DrawLine(_CarEdgePen, 0, -fHeight2, fWidth2, 0);
            graphics.DrawLine(_CarEdgePen, fWidth2, 0, 0, fHeight2);
            DrawNumber(graphics, this.Focused, _FontSize);

            graphics.Transform = mOld; // Przestawienie na poprzedni układ wspolrzędnych
        }
    }
}
