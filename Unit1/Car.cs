using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1
{
    [Serializable]
    public class Car : ICloneable
    {
        readonly float _MaxSpeed = 0;
        float _Speed = 0;

        public Car()
        {
            _MaxSpeed = 200;
            this.RegistrationNumber = "";
            this.Mark = "";
        }

        public Car(string registrationNumber, string mark, float maxSpeed)
        {
            this.RegistrationNumber = registrationNumber;
            this.Mark = mark;
            _MaxSpeed = maxSpeed;
        }

        /// <summary>
        /// Numer rejestracyjny
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Marka samochodu.
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// Prędkość [km/h]
        /// </summary>
        public float Speed
        {
            get { return _Speed; }
            set { _Speed = value; }
        }

        /// <summary>
        /// Podaje, czy jest ustawiony numer rejestracyjny samochodu.
        /// </summary>
        public bool IsRegistartionNumer { get { return !string.IsNullOrEmpty(RegistrationNumber); } }

        /// <summary>
        /// Przyśpieszenie o fAcceleraion [km/h]
        /// </summary>
        /// <param name="fAcceleration"></param>
        public void Acceleration(float fAcceleration)
        {
            _Speed += fAcceleration;
            if(_Speed < 0)
                _Speed = 0;
            if(_Speed > _MaxSpeed)
                _Speed = _MaxSpeed;
        }

        public override string ToString()
        {
            return string.Format("Samochód jedzie z prędkością {0} km/h", this.Speed);
        }

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
            Car car = obj as Car;
            // Warunek 4: porównanie pól wartościowych.
            if (!this.RegistrationNumber.Equals(car.RegistrationNumber)
                || !this.Mark.Equals(car.Mark)
                || !this.Speed.Equals(car.Speed))
                return false;

            return true;
        }

        /// <summary>
        /// Nadpisanie jest wymagane, gdy nadpisujemy Equals().
        /// HasCode powinien być generowany od pola, które bezie unikalnym identyfikatorem klasy.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.RegistrationNumber.GetHashCode();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
