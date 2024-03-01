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
    /// Przeznaczenie samolotu
    /// </summary>
    [Serializable]
    public enum AircraftPurpose
    {
        /// <summary>
        /// Pasażerski
        /// </summary>
        Passenger,
        /// <summary>
        /// Rolniczy
        /// </summary>
        Agricultural,
        /// <summary>
        /// Cargo
        /// </summary>
        Cargo,
        /// <summary>
        /// Wojskowy
        /// </summary>
        Military,
        /// <summary>
        /// Nieznane
        /// </summary>
        Unknown
    }
    [Serializable]
    public sealed class Aircraft : Vehicle
    {
        #region Fields
        [NonSerialized]
        Brush _AirplaneBodyBrush;
        [NonSerialized]
        Pen _AirplaneEdgePen;

        PointF[] _PointsIn = new PointF[9] { new PointF(-4, 0), new PointF(-5, -2), new PointF(-4, -2), new PointF(-3, -1), new PointF(1, -1), new PointF(-1, -4), new PointF(1, -4), new PointF(3, -1), new PointF(5, -0.5f)};
        PointF[] _Points = new PointF[18];

        #endregion

        #region Constructors

        public Aircraft(int id) : base(id)
        {
            InitNoSerialized();
            // Połączenie _PointsIn z odwróconym _PointsIn aby powstał wielokąt.
            for (int i = 0; i < _PointsIn.Length; i++)
            {
                _Points[i] = new PointF(_PointsIn[i].X, _PointsIn[i].Y);
            }
            for (int i = _PointsIn.Length - 1, j = 9; i >= 0; i--, j++)
            {
                _Points[j] = new PointF(_PointsIn[i].X, -_PointsIn[i].Y);
            }
        }

        protected override void InitNoSerialized()
        {
            base.InitNoSerialized();
            _AirplaneBodyBrush = new HatchBrush(HatchStyle.DiagonalCross, Color.YellowGreen, Color.AliceBlue);
            _AirplaneEdgePen = new Pen(Color.Blue, 0.01f);
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
                        if (_AirplaneBodyBrush != null)
                        {
                            _AirplaneBodyBrush.Dispose();
                            _AirplaneBodyBrush = null;
                        }
                        if(_AirplaneEdgePen != null)
                        {
                            _AirplaneEdgePen.Dispose();
                            _AirplaneEdgePen = null;
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

        public override string NameOf { get => "Samolot"; }

        [DisplayName("Przeznaczenie")]
        [CategoryAttribute("Samolot"), DescriptionAttribute("Przeznaczenie samolotu")]
        public AircraftPurpose AircraftPurpose { get; set; } = AircraftPurpose.Unknown;

        #endregion

        public override void Draw(Graphics graphics, PointF position, float fScale, float fCourse)
        {
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

            graphics.FillPolygon(_AirplaneBodyBrush, _Points);
            graphics.DrawPolygon(_AirplaneEdgePen, _Points);
            DrawNumber(graphics, this.Focused, _FontSize);

            graphics.Transform = mOld; // Przestawienie na poprzedni układ wspolrzędnych
        }
    }
}
