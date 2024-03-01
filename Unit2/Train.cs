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
    public enum En_TrainType
    {
        Passenger,
        Express,
        Cargo

    }
    [Serializable]
    public sealed class Train : Vehicle
    {
        #region Fields
        [NonSerialized]
        Brush _TrainBodyBrush;
        [NonSerialized]
        Pen _TrainEdgePen;
        [NonSerialized]
        Brush _TrainWagonBodyBrush;

        Color _WagonColor = Color.Khaki;
        #endregion

        public Train(int id) : base(id)
        {
            InitNoSerialized();

        }

        protected override void InitNoSerialized()
        {
            base.InitNoSerialized();
            _TrainBodyBrush = Brushes.Green;
            _TrainWagonBodyBrush = new SolidBrush(_WagonColor);
            _TrainEdgePen = new Pen(Color.Blue, 0.1f); // szerokość mała, aby po przeskalowniu była 1.0f

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
                        if (_TrainEdgePen != null)
                        {
                            _TrainEdgePen.Dispose();
                            _TrainEdgePen = null;
                        }
                        if (_TrainBodyBrush != null)
                        {
                            _TrainBodyBrush.Dispose();
                            _TrainBodyBrush = null;
                        }
                        if (_TrainWagonBodyBrush != null)
                        {
                            _TrainWagonBodyBrush.Dispose();
                            _TrainWagonBodyBrush = null;
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
        public override string NameOf { get => "Pociąg"; }

        /// <summary>
        /// Źródło napędu pojazdu.
        /// </summary>
        [DisplayName("Rodzaj")]
        [CategoryAttribute("Pociąg"), DescriptionAttribute("Rodzaj pociągu")]
        public En_TrainType TrainType { get; set; } = En_TrainType.Passenger;

        #endregion

        [DisplayName("Kolor wagonu")]
        [CategoryAttribute("Pociąg"), DescriptionAttribute("Kolor wagonu(tutaj opis dalszy..)")]
        public Color WagonColor
        {
            get
            {
                return _WagonColor;
            }
            set
            {
                _WagonColor = value;
                _TrainWagonBodyBrush = new SolidBrush(_WagonColor);
            }
        }
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
            Train v = obj as Train;
            // Warunek 4: porównanie pól wartościowych.
            if (!this.TrainType.Equals(v.TrainType)
                || !this.WagonColor.Equals(v.WagonColor))

                return false;
            return true;
        }
        public override void Draw(Graphics graphics, PointF position, float fScale, float fCourse)
        {
            float fWidth2 = this.Size.Width; // / 2.0f;
            float fHeight2 = this.Size.Height /2.0f;
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

            graphics.FillRectangle(_TrainBodyBrush, -fWidth2/2, -fHeight2, this.Size.Width/2, this.Size.Height);
            graphics.DrawRectangle(_TrainEdgePen, -fWidth2/2, -fHeight2, this.Size.Width/2, this.Size.Height);

            graphics.FillRectangle(_TrainWagonBodyBrush, (-fWidth2 / 2) - (fWidth2/1.5f), -fHeight2, this.Size.Width / 2, this.Size.Height);
            graphics.DrawRectangle(_TrainEdgePen, (-fWidth2 / 2) - (fWidth2 / 1.5f), -fHeight2, this.Size.Width / 2, this.Size.Height);

            graphics.DrawLine(_TrainEdgePen, fHeight2/3f, 0, -fWidth2 / 1.5f, 0);
            //graphics.DrawRectangle(_TrainEdgePen, -fWidth2 / 2, -fHeight2, this.Size.Width / 2, this.Size.Height);
            //graphics.DrawLine(_TrainEdgePen, 0, -fHeight2, fWidth2, 0);
            //graphics.DrawLine(_TrainEdgePen, fWidth2, 0, 0, fHeight2);
            DrawNumber(graphics, this.Focused, _FontSize);

            graphics.Transform = mOld; // Przestawienie na poprzedni układ wspolrzędnych
        }
    }
}
