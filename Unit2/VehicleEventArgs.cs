using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2
{
    /// <summary>
    /// Typ zdarzenia pojazdu.
    /// </summary>
    [Serializable]
    public enum En_VehicleEventType
    {
        /// <summary>
        /// Brak.
        /// </summary>
        None = 0,
        /// <summary>
        /// Zmiana kierunku.
        /// </summary>
        AngleChanged = 1,
        /// <summary>
        /// Zmiana szybkości.
        /// </summary>
        SpeedChanged = 2,
    }

    /// <summary>
    /// Parametry zdarzenia pojazdu.
    /// </summary>
    public class VehicleEventArgs : EventArgs
    {
        public VehicleEventArgs(Vehicle vehicle, En_VehicleEventType vehicleEventType)
        {
            this.Vehicle = vehicle;
            this.VehicleEventType = vehicleEventType;
        }

        public Vehicle Vehicle { get; private set; }

        public En_VehicleEventType VehicleEventType { get; private set; }
    }

    /// <summary>
    /// Delegat zdarzenia pojazdu.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void VehicleEventDelegate(object sender, VehicleEventArgs e);
}
