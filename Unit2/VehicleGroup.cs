using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unit2.Support;

namespace Unit2
{
    [Serializable]
    public class VehicleGroup : IDisposable
    {
        float _DefaultScale = 10;
        float _DefaultSpeed = 10;
        int _FirstFreeId = 1;
        Dictionary<int, Vehicle> _VehiclesDict = new Dictionary<int, Vehicle>();
        List<Vehicle> _VehiclesList = new List<Vehicle>();

        [field: NonSerialized]
        public event VehicleEventDelegate VehicleEvent;

        protected bool _HasBeenDisposed = false;

        public VehicleGroup()
        {

        }

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
                        this.Clear();

                    }
                    foreach(Vehicle v in _VehiclesDict.Values)
                    {
                        v.Dispose();
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
        ~VehicleGroup()
        {
            this.Dispose(false);
        }

        #endregion

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

            VehicleGroup vg = obj as VehicleGroup;

            //porówanie list

            var list = this.VehicleList.Except(vg.VehicleList);
            if(list == null || list.Count() > 0) return false;

            return true;
        }

        public static Vehicle copyObjectWithNewId(Vehicle vehicle, VehicleGroup vehicleGroup)
        {
            Vehicle v1 = CopyClass.DeepCopy(vehicle);
            if( v1 != null )
            {
                v1.Id = vehicleGroup.GetFirsFreeId();
                return v1;
            }
            return null;
            
            

        }
        


        public Vehicle this[int index]
        {
            get
            {
                if(index >= 0 && index < _VehiclesList.Count)
                    return _VehiclesList[index];
                else
                    return null;
            }
        }

        public List<Vehicle> VehicleList
        {
            get { return _VehiclesList; }
        }

        public Dictionary<int, Vehicle> VehicleDict
        {
            get { return _VehiclesDict; }
        }

        public int CountOfVehicles
        {
            get { return _VehiclesList.Count; }
        }

        public void Clear()
        {
            foreach(Vehicle vehicle in _VehiclesDict.Values)
                if(vehicle != null)
                    vehicle.Dispose();
            _VehiclesDict.Clear();
            _VehiclesList.Clear();
        }

        public int GetFirsFreeId()
        {
            while (_VehiclesDict.ContainsKey(_FirstFreeId))
                _FirstFreeId++;

            return _FirstFreeId;
        }

        public void AddVehicle(Vehicle v, RectangleF bounds)
        {
            float fDefaultScale = _DefaultScale;
            float fDefaultSpeed = _DefaultSpeed;

            if (v != null)
            {
                v.Course = new Random().Next(360);
                if (v is Aircraft)
                {
                    v.Scale = fDefaultScale;
                    v.Speed = fDefaultSpeed * 4;
                }
                else if (v is Car)
                {
                    v.Scale = fDefaultScale / 2;
                    v.Speed = fDefaultSpeed;
                }
                else if (v is Train)
                {
                    v.Scale = fDefaultScale;
                    v.Speed = fDefaultSpeed;
                }
                else if (v is Bike)
                {
                    v.Scale = fDefaultScale / 4;
                    v.Speed = fDefaultSpeed / 6;
                }


                v.Position = new PointF(bounds.Width / 2, bounds.Height / 2);
                v.Bounds = bounds;
                if (this.AddVehicles(v))
                    v.VehicleEvent += V_VehicleEvent;
            }
        }

        private void V_VehicleEvent(object sender, VehicleEventArgs e)
        {
            if(VehicleEvent != null)
                VehicleEvent(sender, e);
        }

        bool AddVehicles(Vehicle vehicle)
        {
            bool bAdded = false;

            if (vehicle != null && !_VehiclesDict.ContainsKey(vehicle.Id))
            {
                _VehiclesDict.Add(vehicle.Id, vehicle);
                _VehiclesList.Add(vehicle);
                bAdded = true;
            }

            return bAdded;
        }

        public void CreateVehicles(Rectangle bounds)
        {
            float fDefaultScale = _DefaultScale;
            float fDefaultSpeed = _DefaultSpeed;
            Vehicle v;
            int iAngleDeg = 0;
            int iAngleStepDeg = 36;

            for (int i = 0; i < 10; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        v = new Car(this.GetFirsFreeId());
                        break;
                    case 1:
                        v = new Bike(this.GetFirsFreeId());
                        break;
                    case 2:
                        v = new Aircraft(this.GetFirsFreeId());
                        break;
                    case 3:
                        v = new Train(this.GetFirsFreeId());
                        break;
                    default:
                        v = null;
                        break;
                }
                if (v != null)
                {
                    v.Position = new PointF(bounds.Width / 2, bounds.Height / 2);
                    iAngleDeg += iAngleStepDeg;
                    iAngleDeg = iAngleDeg % 360;
                    v.Course = iAngleDeg;
                    v.Bounds = bounds;
                    if (v is Aircraft)
                    {
                        v.Scale = fDefaultScale;
                        v.Speed = fDefaultSpeed * 4;
                    }
                    else if (v is Car)
                    {
                        v.Scale = fDefaultScale / 2;
                        v.Speed = fDefaultSpeed;
                    }
                    else if (v is Train)
                    {
                        v.Scale = fDefaultScale;
                        v.Speed = fDefaultSpeed;
                    }
                    else if (v is Bike)
                    {
                        v.Scale = fDefaultScale / 4;
                        v.Speed = fDefaultSpeed / 6;
                    }
                    if (this.AddVehicles(v))
                        v.VehicleEvent += V_VehicleEvent;
                }
            }
        }

        public void RemoveByIndex(List<int> vehicleListIndex2remove)
        {
            if(vehicleListIndex2remove != null && vehicleListIndex2remove.Count > 0)
            {
                List<Vehicle> list = new List<Vehicle>();

                foreach (int index in vehicleListIndex2remove)
                {
                    if (index >= 0 && index < _VehiclesList.Count)
                    {
                        list.Add(_VehiclesList[index]);
                    }
                }
                foreach (Vehicle v in list)
                {
                    if (v != null && _VehiclesDict.ContainsKey(v.Id))
                    {
                        v.VehicleEvent -= V_VehicleEvent;
                        _VehiclesList.Remove(v);
                        _VehiclesDict.Remove(v.Id);
                        v.Dispose();
                    }
                }
            }
        }

        public void SetFocusedVehicle(int id)
        {
            foreach (Vehicle vehicle in _VehiclesList)
            {
                vehicle.Focused = vehicle.Id == id;
            }
        }

        public void MoveByStep()
        {
            foreach (Vehicle vehicle in _VehiclesList)
            {
                vehicle.MoveByStep();
            }
        }

        public void SaveToBinaryFile(string filename)
        {
            SerializeVehicles.WriteToBinaryFile(filename, this);
        }

        public static VehicleGroup ReadFromBinaryFile(string filename)
        {
            return SerializeVehicles.ReadFromBinaryFile<VehicleGroup>(filename);
        }
    }
}
