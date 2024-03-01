using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Unit2.Support;

namespace Unit2
{
    [Serializable]
    public abstract class Vehicle : IDisposable, IPresentation
    {
        #region Constants

        const int _SpeedStepSmall = 1;
        const int _SpeedStepLarge = 10;

        const int _TurnAngleSmall = 1;  //  [deg]
        const int _TurnAngleLarge = 10; //  [deg]

        protected const int _FontSize = 2;

        #endregion

        #region Fields

        float _Course = 0;
        float _Speed = 0;
        [NonSerialized]
        protected Font _Font;
        [NonSerialized]
        protected StringFormat _StringFormat;
        [NonSerialized]
        protected Brush _NumberBrush;
        [NonSerialized]
        protected Pen _NumberPen; // szerokość mała, aby po przeskalowniu była 1.0f
        [NonSerialized]
        protected bool _HasBeenDisposed = false;


        public Person _Owner;

        #endregion

        #region Dispose

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposeManagedObjs)
        {
            if (!_HasBeenDisposed)
            {
                try
                {
                    if (disposeManagedObjs)
                    {
                        // Wywołanie metod Dispose/Close/Clear dla zarządzanych obiektów
                        
                    }
                    if (_Font != null)
                    {
                        _Font.Dispose();
                        _Font = null;
                    }
                    if (_StringFormat != null)
                    {
                        _StringFormat.Dispose();
                        _StringFormat = null;
                    }
                    if (_NumberPen != null)
                    {
                        _NumberPen.Dispose();
                        _NumberPen = null;
                    }
                }
                catch (Exception)
                {
                    _HasBeenDisposed = false;
                    throw;
                }
                _HasBeenDisposed = true;
            }
        }
        ~Vehicle()
        {
            this.Dispose(false);
        }

        #endregion

        #region Events
        [field: NonSerialized]
        public event VehicleEventDelegate VehicleEvent;

        #endregion

        #region Constructors

        public Vehicle(int id)
        {
            this.Id = id;
            InitNoSerialized();
        }

        protected virtual void InitNoSerialized()
        {
            _Font = new Font("Arial", _FontSize);
            _StringFormat = new StringFormat();
            _NumberBrush = Brushes.GreenYellow;
            _NumberPen = new Pen(Color.AliceBlue, 0.1f);

            _StringFormat.Alignment = StringAlignment.Center;
            _StringFormat.LineAlignment = StringAlignment.Center;

            _HasBeenDisposed = false;

            if(_Owner == null) _Owner = new Person();
        }

        #endregion

        #region Properties


        [DisplayName("Imię")]
        [CategoryAttribute("Właściciel"), DescriptionAttribute("Imię właściciela")]
        public string FirstName
        {
            get
            {
                return _Owner.FirstName;
            }
            set
            {
                _Owner.FirstName = value;
            }
        }

        [DisplayName("Nazwisko")]
        [CategoryAttribute("Właściciel"), DescriptionAttribute("nazwisko właściciela")]
        public string LastName
        {
            get
            {
                return _Owner.LastName;
            }
            set
            {
                _Owner.LastName = value;
            }
        }
        [DisplayName("Adres")]
        [CategoryAttribute("Właściciel"), DescriptionAttribute("Adres właściciela")]
        public string Adress
        {
            get
            {
                return _Owner.Adress;
            }
            set
            {
                _Owner.Adress = value;
            }
        }
        /// <summary>
        /// Identyfikator obiektu.
        /// </summary>
        [DisplayName("Identyfikator")]
        [CategoryAttribute("Pojazd"), DescriptionAttribute("Identyfikator pojazdu")]
        public int Id { get; set; } = 0;

        /// <summary>
        /// Nazwa typu pojazdu.
        /// </summary>
        [DisplayName("Nazwa")]
        [CategoryAttribute("Pojazd"), DescriptionAttribute("Nazwa pojazdu")]
        public abstract string NameOf { get; }

        /// <summary>
        /// Położenie obiektu.
        /// </summary>
        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public PointF Position { get; set; } = new PointF();

        /// <summary>
        /// Rozmiar obiektu
        /// </summary>
        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public SizeF Size { get; set; } = new SizeF(10, 5);

        /// <summary>
        /// Skala obiektu.
        /// </summary>
        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public float Scale { get; set; } = 1.0f;

        /// <summary>
        /// Kierunek poruszania się (kąt obrotu) [deg].
        /// Zgodnie z ruchem wskazówek zegara, między osią OX (na godzinie 3).
        /// </summary>
        [DisplayName("Kurs")]
        [CategoryAttribute("Pojazd"), DescriptionAttribute("Kierunek poruszania się")]
        public float Course
        {
            get { return _Course; }
            set
            {
                _Course = value % 360;
                SizeF vec = Calculations.GetVecFromAngle(_Course);

                this.Vector = new SizeF(vec.Width * this.Speed, vec.Height * this.Speed);
            }
        }

        /// <summary>
        /// Wektor przesunięcia obiektu.
        /// </summary>
        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        private SizeF Vector { get; set; } = new SizeF(0, 0);

        /// <summary>
        /// Granica poruszania się obiektu.
        /// </summary>
        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public RectangleF Bounds { get; set; } = new RectangleF();

        /// <summary>
        /// Prędkość poruszania się obiektu.
        /// </summary>
        [DisplayName("Prędkość")]
        [CategoryAttribute("Pojazd"), DescriptionAttribute("Prędkość poruszania się")]
        public float Speed
        {
            get
            {
                return _Speed;
            }
            set
            {
                _Speed = value;

                SizeF vec = Calculations.GetVecFromAngle(this.Course);

                this.Vector = new SizeF(vec.Width * _Speed, vec.Height * _Speed);
            }
        }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public bool Focused { get; set; } = false;

        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
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
            Vehicle v = obj as Vehicle;
            // Warunek 4: porównanie pól wartościowych.
            if (!this.Speed.Equals(v.Speed)
                || !this.NameOf.Equals(v.NameOf))
                //|| !this.Scale.Equals(v.Scale)
                //|| !this.Vector.Equals(v.Vector)
                //|| !this.Size.Equals(v.Size))
                return false;

            if(!this._Owner.Equals(v._Owner)) return false;

            return true;
        }

        /// <summary>
        /// Nadpisanie jest wymagane, gdy nadpisujemy Equals().
        /// HasCode powinien być generowany od pola, które bezie unikalnym identyfikatorem klasy.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public abstract void Draw(Graphics graphics, PointF position, float fScale, float fCourse);
        public void Draw(Graphics graphics)
        {
            this.Draw(graphics, this.Position, this.Scale, this.Course);
        }

        /// <summary>
        /// Przesunięcie obiektu o wektor this.Vector.
        /// </summary>
        public void MoveByStep()
        {
            this.Position += this.Vector;
            if (!this.Bounds.Contains(this.Position))
            {
                bool bAngleChanged = false;

                if (this.Position.Y > this.Bounds.Bottom)            // dolna granica
                {
                    this.Course = -this.Course;
                    this.Position = new PointF(this.Position.X, this.Bounds.Bottom);
                    bAngleChanged = true;
                }
                else if (this.Position.X > this.Bounds.Right)       // prawa granica
                {
                    this.Course = 180 - this.Course;
                    this.Position = new PointF(this.Bounds.Right, this.Position.Y);
                    bAngleChanged = true;
                }
                else if (this.Position.Y < this.Bounds.Top)          // górna granica
                {
                    this.Course = -this.Course;
                    this.Position = new PointF(this.Position.X, this.Bounds.Top);
                    bAngleChanged = true;
                }
                else if (this.Position.X < this.Bounds.Left)         // lewa granica
                {
                    this.Course = 180 - this.Course;
                    this.Position = new PointF(this.Bounds.Left, this.Position.Y);
                    bAngleChanged = true;
                }
                if (bAngleChanged && VehicleEvent != null)
                    VehicleEvent(this, new VehicleEventArgs(this, En_VehicleEventType.AngleChanged));
            }
        }

        protected void DrawNumber(Graphics graphics, bool bFocused, float fRadius)
        {
            if (bFocused)
                graphics.FillEllipse(_NumberBrush, -fRadius, -fRadius, 2 * fRadius, 2 * fRadius);
            else
                graphics.DrawEllipse(_NumberPen, -fRadius, -fRadius, 2 * fRadius, 2 * fRadius);
            graphics.DrawString(this.Id.ToString(), _Font, Brushes.Black, 0, 0, _StringFormat);
        }

        #region Turning

        public void TurnLeft(bool bSmall)
        {
            this.Course -= bSmall ? _TurnAngleSmall : _TurnAngleLarge;
            if(VehicleEvent != null)
                VehicleEvent(this, new VehicleEventArgs(this, En_VehicleEventType.AngleChanged));
        }

        public void TurnRight(bool bSmall)
        {
            this.Course += bSmall ? _TurnAngleSmall : _TurnAngleLarge;
            if (VehicleEvent != null)
                VehicleEvent(this, new VehicleEventArgs(this, En_VehicleEventType.AngleChanged));
        }

        #endregion

        #region Speed control

        public void Stop()
        {
            this.Speed = 0;
            if (VehicleEvent != null)
                VehicleEvent(this, new VehicleEventArgs(this, En_VehicleEventType.SpeedChanged));
        }

        public void SpeedPlus(bool bSmall)
        {
            this.Speed += bSmall ? _SpeedStepSmall : _SpeedStepLarge;
            if (VehicleEvent != null)
                VehicleEvent(this, new VehicleEventArgs(this, En_VehicleEventType.SpeedChanged));
        }

        public void SpeedMinus(bool bSmall)
        {
            if (this.Speed > 0)
            {
                int iStep = bSmall ? _SpeedStepSmall : _SpeedStepLarge;

                if (this.Speed < iStep)
                    this.Speed = 0;
                else
                    this.Speed -= iStep;
                if (VehicleEvent != null)
                    VehicleEvent(this, new VehicleEventArgs(this, En_VehicleEventType.SpeedChanged));
            }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0}:{1}", this.NameOf, this.Id);
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            InitNoSerialized();
        }

        #endregion

    }
}
