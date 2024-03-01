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
    public partial class XUCVehicle : UserControl
    {
        public XUCVehicle()
        {
            InitializeComponent();

            _PictureBox.Paint += _PictureBox_Paint;
        }

        private void _PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.Presentation != null)
            {
                PointF pnt = new PointF(this.ClientRectangle.Location.X + this.ClientRectangle.Width / 2, this.ClientRectangle.Location.Y + this.ClientRectangle.Height / 2);

                this.Presentation.Draw(e.Graphics, pnt, 5.0f, 1.0f);
            }
        }

        public void Redraw()
        {
            _PictureBox.Invalidate();
        }

        public IPresentation Presentation { get; set; }
    }
}
