using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Unit1
{
    [Serializable]
    public class CarPark : ICloneable
    {

        const float _MaxSpeedDefault = 200;
        string _Name = "Na rozdrożu";  // Nazwa parkingu
        int _Max = 10;
        Dictionary<string, Car> _CarDict = new Dictionary<string, Car>();
        List<Car> _CarList = new List<Car>();

        [field: NonSerialized]
        public event CarParkEventDelegate CarParkEvent;


        public CarPark()
        {
            _Max = 10;
        }

        public CarPark(int iMax)
        {
            _Max = iMax;
        }

        public Car this[string registrationNumber]
        {
            get
            {
                _CarDict.TryGetValue(registrationNumber, out Car car);

                return car;
            }
            set { _CarDict[registrationNumber] = value; }
        }

        public int Max 
        {
            get { return _Max; }
        }

        public int Count
        {
            get { return _CarDict.Count; }
        }

        public bool Full
        {
            get { return this.Count >= this.Max; }
        }

        public Car this[int index]
        {
            get
            {
                Car car = null;

                if(index >= 0 && index < _CarList.Count)
                    car = _CarList[index];

                return car;
            }
            set
            {
                if (index >= 0 && index < _CarList.Count)
                    _CarList[index] = value;
            }
        }

        public bool compareCarPark(CarPark cpCopy)
        {
            if (GetType() != cpCopy.GetType()) return false;
            if (Count != cpCopy.Count) return false;
            if (_Name != cpCopy._Name) return false;
            if (_Max != cpCopy._Max) return false;

            var result = _CarList.Except(cpCopy._CarList);
            if(result == null || result.Count() != 0) return false;
            
            return true;

        }
        public void Clear()
        {
            _CarDict.Clear();
            _CarList.Clear();
        }

        public bool AddCar(Car car)
        {
            bool bAdd = false;

            if (car != null && !string.IsNullOrEmpty(car.RegistrationNumber) && !_CarDict.ContainsKey(car.RegistrationNumber))
            {
                _CarDict[car.RegistrationNumber] = car;
                _CarList.Add(car);
                bAdd = true;

                if (CarParkEvent != null)
                {
                    CarParkEvent(this, new CarParkEventArgs(car, En_ParkEvent.CarAdded));
                    if (this.Full)
                        CarParkEvent(this, new CarParkEventArgs(car, En_ParkEvent.CarParkFull));
                }
            }

            return bAdd;
        }

        public bool AddCar(string registryNumber, string mark, float fMaxSpeed)
        {
            bool bAdd = false;

            if (this.Count < this.Max)
            {
                if (!string.IsNullOrEmpty(registryNumber) && !_CarDict.ContainsKey(registryNumber))
                {
                    Car car = new Car(registryNumber, mark, fMaxSpeed);
                    _CarDict.Add(registryNumber, car);
                    _CarList.Add(car);
                    bAdd = true;

                    if (CarParkEvent != null)
                    {
                        CarParkEvent(this, new CarParkEventArgs(car, En_ParkEvent.CarAdded));
                        if (this.Full)
                            CarParkEvent(this, new CarParkEventArgs(car, En_ParkEvent.CarParkFull));
                    }
                }
            }
            else if (this.Full)
                CarParkEvent(this, new CarParkEventArgs(null, En_ParkEvent.CarParkFull));
            return bAdd;
        }

        public bool AddCar(string registryNumber, string mark)
        {
            return this.AddCar(registryNumber, mark, _MaxSpeedDefault);
        }

        public bool RemoveCar(string registryNumber)
        {
            bool bDone = false;

            if (!string.IsNullOrEmpty(registryNumber) && _CarDict.ContainsKey(registryNumber))
            {
                Car car = _CarDict[registryNumber];

                _CarDict.Remove(registryNumber);
                _CarList.Remove(car);
                bDone = true;

                if (CarParkEvent != null)
                    CarParkEvent(this, new CarParkEventArgs(car, En_ParkEvent.CarRemoved));
            }

            return bDone;
        }

        public void GetState(out string name, out int iCount)
        {
            name = _Name;
            iCount = this.Count;
        }

        public void SetState(ref string name)
        {
            name = name.ToUpper();
            _Name = name;
        }

        #region Cloning

        // Metoda ręczna

        /// <summary>
        /// Klonowanie płytkie.
        /// </summary>
        /// <returns></returns>
        public object CloneShallow()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Klonowanie głębokie.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            CarPark carParkCloned = (CarPark)MemberwiseClone();

            carParkCloned.OnCloned();
            for (int i = 0; i < this.Count; i++)
                carParkCloned.AddCar(this[i].Clone() as Car);

            return carParkCloned;
        }

        public void OnCloned()
        {
            _CarDict = new Dictionary<string, Car>();
            _CarList = new List<Car>();
        }

        /// <summary>
        /// Metoda kolonowania przez serializację.
        /// Realizowana przez przeciązenie Clone() i wykorzystanie serializacji binarnej.
        /// Wadą tego rozwiązania jest konieczność serializacji wszytskich pól klasy.
        /// Może też się zdarzyć, że pewne pola nie będą mogły być serializowane.
        /// Wtedy trzeba wykonać klonowanie ręczne.
        /// Może też tak być, że klonowanie wogóle nie będzie logicznie możliwe.
        /// Bo jak sklonować obiekt reprezentujący fizyczną drukarkę?
        /// </summary>
        /// <param name="bDeepCopy"></param>
        /// <returns></returns>
        public object Clone(bool bDeepCopy)
        {
            if (bDeepCopy)
                return CopyClass.DeepCopy(this);
            else
                return Clone();
        }

        #endregion
    }
}
