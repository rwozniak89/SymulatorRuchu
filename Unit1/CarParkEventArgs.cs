using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1
{
    public enum En_ParkEvent
    {
        None = 0,
        CarAdded = 1,
        CarRemoved = 2,
        CarParkFull = 3
    }

    public class CarParkEventArgs : EventArgs
    {
        public CarParkEventArgs(Car car, En_ParkEvent parkEvent)
        {
            this.Car = car;
            this.ParkEvent = parkEvent;
        }

        public Car Car
        {
            get;
            private set;
        }

        public En_ParkEvent ParkEvent { get; private set; }
    }

    public delegate void CarParkEventDelegate(object sender, CarParkEventArgs e);
}
