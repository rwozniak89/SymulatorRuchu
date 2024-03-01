using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Unit2
{
    /// <summary>
    /// Rodzaj roweru
    /// </summary>
    [Serializable]
    public enum BikeUsing
    {
        /// <summary>
        /// Dziecięcy
        /// </summary>
        Kids,
        /// <summary>
        /// Damski
        /// </summary>
        Womens,
        /// <summary>
        /// Męski
        /// </summary>
        Mens,
        /// <summary>
        /// Dla każdego
        /// </summary>
        Any
    }
    [Serializable]
    public sealed class Bike : Vehicle
    {
        #region Fields

        [NonSerialized]
        Brush _WheelBrush;
        [NonSerialized]
        Pen _WheelPen;  // szerokość mała, aby po przeskalowniu była 1.0f

        Color _ColorBike = Color.Blue;
        #endregion

        #region Constructors

        public Bike(int id) : base(id)
        {
            InitNoSerialized();
        }

        protected override void InitNoSerialized()
        {
            base.InitNoSerialized();
            _WheelBrush =  new SolidBrush(ColorBike);
            _WheelPen = new Pen(Color.Blue, 0.1f);  // szerokość mała, aby po przeskalowniu była 1.0f
        }

        #endregion

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
                        if (_WheelPen != null)
                        {
                            _WheelPen.Dispose();
                            _WheelPen = null;
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
        [DisplayName("Kolorek")]
        [CategoryAttribute("Rower"), DescriptionAttribute("Kolorek koła")]
        public Color ColorBike {
            get
            {
                return _ColorBike;
            }
            set
            {
                _ColorBike = value;
                _WheelBrush = new SolidBrush(_ColorBike);
            }
        }

        /// <summary>
        /// Typ pojazdu.
        /// </summary>
        public override string NameOf { get => "Rower"; }

        [DisplayName("Rodzaj")]
        [CategoryAttribute("Rower"), DescriptionAttribute("Rodzaj roweru - dziecięcy, damski, męski")]
        public BikeUsing BikeUsing { get; set; } = BikeUsing.Any;

        #endregion

        #region Methods

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
            Bike v = obj as Bike;
            // Warunek 4: porównanie pól wartościowych.
            if (!this.ColorBike.Equals(v.ColorBike)
                || !this.BikeUsing.Equals(v.BikeUsing))

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

            graphics.FillEllipse(_WheelBrush, -_FontSize - fWidth2, -_FontSize, 2 * _FontSize, 2 * _FontSize);
            graphics.FillEllipse(_WheelBrush, -_FontSize + fWidth2, -_FontSize, 2 * _FontSize, 2 * _FontSize);
            graphics.DrawLine(_WheelPen, -fWidth2, 0, fWidth2, 0);
            DrawNumber(graphics, this.Focused, _FontSize);

            graphics.Transform = mOld; // Przestawienie na poprzedni układ wspolrzędnych
        }


        #endregion
    }
}
