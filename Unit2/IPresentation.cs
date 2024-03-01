using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2
{
    public interface IPresentation
    {
        void Draw(Graphics graphics, PointF position, float fScale, float fCourse);
    }
}
