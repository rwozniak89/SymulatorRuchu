using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unit2
{
    public partial class AddVehicleForm : Form
    {
        Vehicle _Vehicle;

        public AddVehicleForm(Vehicle vehicle)
        {
            InitializeComponent();

            _Vehicle = vehicle;
            if(_Vehicle != null)
            {
                this.Text = string.Format("Dodanie pojazdu {0}", _Vehicle.NameOf);
                this.Course = _Vehicle.Course;
                this.Speed = _Vehicle.Speed;
                this.ScaleOf = _Vehicle.Scale;
            }
        }

        float Course
        {
            get
            {
                if (string.IsNullOrEmpty(_Course_MaskedTextBox.Text))
                    return 0;
                else
                    return Convert.ToInt32(_Course_MaskedTextBox.Text);
            }
            set
            {
                _Course_MaskedTextBox.Text = value.ToString("0");
            }
        }

        float Speed
        {
            get
            {
                if (string.IsNullOrEmpty(_Speed_MaskedTextBox.Text))
                    return 0;
                else
                    return Convert.ToInt32(_Speed_MaskedTextBox.Text);
            }
            set
            {
                _Speed_MaskedTextBox.Text = value.ToString("0");
            }
        }

        float ScaleOf
        {
            get
            {
                if (string.IsNullOrEmpty(_Scale_MaskedTextBox.Text))
                    return 0;
                else
                    return Convert.ToInt32(_Scale_MaskedTextBox.Text);
            }
            set
            {
                _Scale_MaskedTextBox.Text = value.ToString("0");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if(!e.Cancel)
            {
                _Vehicle.Course = this.Course % 360;
                _Vehicle.Speed = this.Speed;
                _Vehicle.Scale = this.ScaleOf;
                if (_Vehicle is Car)
                {
                    Car car = _Vehicle as Car;

                    car.DriveSource = En_DriveSource.Electric;
                }
            }
        }
    }
}
