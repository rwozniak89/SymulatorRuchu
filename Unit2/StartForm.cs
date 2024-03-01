using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unit2.Support;

namespace Unit2
{
    public partial class StartForm : Form
    {
        Timer _Timer;
        int _Interval = 100;    // [ms]
        VehicleGroup _VehicleGroup;

        public StartForm()
        {
            InitializeComponent();

            _VehicleGroup = new VehicleGroup();

            _PictureBox.Paint += _PictureBox_Paint;

            _Timer = new Timer();
            _Timer.Interval = _Interval;
            _Timer.Tick += _Timer_Tick;

            _VehicleGroup.VehicleEvent += _VehicleGroup_VehicleEvent;
        }

        private void _VehicleGroup_VehicleEvent(object sender, VehicleEventArgs e)
        {
            if (e != null && e.Vehicle != null)
            {
                int iRowIndex = _VehicleGroup.VehicleList.IndexOf(e.Vehicle);

                if (iRowIndex >= 0 && iRowIndex < _VehicleGroup.CountOfVehicles)
                    _VehiclesDataGridView.InvalidateRow(iRowIndex);
            }
        }

        #region Form events

        private void _PictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (Vehicle vehicle in _VehicleGroup.VehicleList)
            {
                vehicle.Draw(e.Graphics);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            foreach (Vehicle vehicle in _VehicleGroup.VehicleList)
            {
                vehicle.Bounds = _PictureBox.ClientRectangle;
            }

            _Timer.Start();
        }

        private void _PictureBox_SizeChanged(object sender, EventArgs e)
        {
            foreach (Vehicle vehicle in _VehicleGroup.VehicleList)
            {
                vehicle.Bounds = _PictureBox.ClientRectangle;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _VehicleGroup.Dispose();
        }

        #endregion

        private void _Timer_Tick(object sender, EventArgs e)
        {
            if (_VehicleGroup.CountOfVehicles > 0)
            {
                _VehicleGroup.MoveByStep();
                _PictureBox.Invalidate();
            }
        }

        #region Vehicles

        #endregion

        Vehicle GetFocusedVehicle()
        {
            Vehicle vehicle = null;

            if(_VehiclesDataGridView.CurrentRow != null && _VehiclesDataGridView.CurrentRow.Index >= 0)
            {
                int iRowIndex = _VehiclesDataGridView.CurrentRow.Index;

                vehicle = _VehicleGroup[iRowIndex];
            }

            return vehicle;
        }

        #region Turning

        private void _TurnLeftButton_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetFocusedVehicle();

            if(vehicle != null)
                vehicle.TurnLeft(false);
        }

        private void _TurnRightButton_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetFocusedVehicle();

            if (vehicle != null)
               vehicle.TurnRight(false);
        }

        private void _TurnLeftSmallButton_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetFocusedVehicle();

            if (vehicle != null)
                vehicle.TurnLeft(true);
        }

        private void _TurnRightSmallButton_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetFocusedVehicle();

            if (vehicle != null)
                vehicle.TurnRight(true);
        }

        #endregion

        #region Speed control

        private void _StopButton_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetFocusedVehicle();

            if (vehicle != null)
                vehicle.Stop();
        }

        private void _SpeedMinusMinusButton_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetFocusedVehicle();

            if (vehicle != null)
                vehicle.SpeedMinus(false);
        }

        private void _SpeedPlusPlusButton_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetFocusedVehicle();

            if (vehicle != null)
                vehicle.SpeedPlus(false);
        }

        private void _SpeedPlusButton_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetFocusedVehicle();

            if (vehicle != null)
                vehicle.SpeedPlus(true);
        }

        private void _SpeedMinusButton_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetFocusedVehicle();

            if (vehicle != null)
                vehicle.SpeedMinus(true);
        }

        #endregion

        private void _VehiclesDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _VehicleGroup.CountOfVehicles)
            {
                Vehicle vehicle = _VehicleGroup[e.RowIndex];

                if(vehicle != null)
                {
                    _XUCVehicle.Presentation = vehicle;
                    _XUCVehicle.Redraw();

                    _PropertyGrid.SelectedObject = vehicle;

                    _VehicleGroup.SetFocusedVehicle(vehicle.Id);
                }
            }
        }

        #region Add, Generate, Remove Vehicle

        void AddVehicle(Vehicle v)
        {
            _VehiclesDataGridView.DataSource = null;

            _VehicleGroup.AddVehicle(v, _PictureBox.ClientRectangle);

            _VehiclesDataGridView.DataSource = _VehicleGroup.VehicleList;
        }

        private void _AddBike_Button_Click(object sender, EventArgs e)
        {
            AddVehicle(new Bike(_VehicleGroup.GetFirsFreeId()));
        }

        private void _AddCar_Button_Click(object sender, EventArgs e)
        {
            AddVehicle(new Car(_VehicleGroup.GetFirsFreeId()));
        }

        private void _AddAircraft_Button_Click(object sender, EventArgs e)
        {
            AddVehicle(new  Aircraft(_VehicleGroup.GetFirsFreeId()));
        }

        private void _AddTrain_Button_Click(object sender, EventArgs e)
        {
            AddVehicle(new Train(_VehicleGroup.GetFirsFreeId()));
        }

        private void _AddByGeneration_Button_Click(object sender, EventArgs e)
        {
            _VehiclesDataGridView.DataSource = null;
            _VehicleGroup.CreateVehicles(_PictureBox.ClientRectangle);
            _VehiclesDataGridView.DataSource = _VehicleGroup.VehicleList;
        }

        private void _RemoveSelected_Button_Click(object sender, EventArgs e)
        {
            if(_VehiclesDataGridView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(string.Format("Czy chcesz usunąć {0} pojazdów?", _VehiclesDataGridView.SelectedRows.Count), "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<int> vehicleListIndex2remove = new List<int>();

                    foreach (DataGridViewRow row in _VehiclesDataGridView.SelectedRows)
                        vehicleListIndex2remove.Add(row.Index);

                    _VehiclesDataGridView.DataSource = null;
                    _VehicleGroup.RemoveByIndex(vehicleListIndex2remove);
                    _VehiclesDataGridView.DataSource = _VehicleGroup.VehicleList;
                    _PictureBox.Refresh();
                }
            }
        }

        #endregion

        private void _CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Open_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullFileName = openFileDialog.FileName;
            
                

                var loadedVehicleGroup = VehicleGroup.ReadFromBinaryFile(fullFileName);
                if(_VehicleGroup == null || _VehicleGroup.CountOfVehicles == 0)
                {
                    MessageBox.Show("Wczytaną nową grupę pojazdów!");
                }
                else if (_VehicleGroup.Equals(loadedVehicleGroup))
                {
                    MessageBox.Show("Obie grupy pojzadów są takie same!");
                }
                else
                {
                    MessageBox.Show("Wczytano inną grupę pojazdów!");
                }

                _VehicleGroup.Dispose();
                _VehicleGroup = loadedVehicleGroup;

                _VehiclesDataGridView.DataSource = _VehicleGroup.VehicleList;

                
            }

        }

        private void _Save_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _VehicleGroup.SaveToBinaryFile(saveFileDialog.FileName);
            }
        }

        private void _Close_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void _Copy_Button_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetFocusedVehicle();
            if(vehicle != null)
            {
                var newVehicle = VehicleGroup.copyObjectWithNewId(vehicle, _VehicleGroup);
                if(newVehicle != null) AddVehicle(newVehicle);
                else MessageBox.Show("Nie udało się skopiować obiektu!");
            }
            else
            {
                MessageBox.Show("Najpierw zaznacz obiekt do skopiwoania");
            }
        }

        private void _Compare_Button_Click(object sender, EventArgs e)
        {
            //var org = _VehicleGroup;
            //var copy = 
        }
    }
}
