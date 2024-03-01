using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1
{
    internal class Drawable : IDisposable
    {
        int _FontSize = 20;
        StringFormat _StringFormat = null;
        Pen _Pen = null;
        Brush _Brush = null;
        Font _Font = null;
        Bitmap _Bitmap = null;

        protected bool _HasBeenDisposed = false;

        public Drawable()
        {
            _Pen = new Pen(Color.AliceBlue, 1.0f);
            _Brush = new SolidBrush(Color.Red);
            _StringFormat = new StringFormat();
            _Font = new Font("Arial", _FontSize);
            _Bitmap = new Bitmap(1000, 1000);
        }

        public void Draw()
        {

        }

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
                    if (_Pen != null)
                    {
                        _Pen.Dispose();
                        _Pen = null;
                    }
                    if(_Brush != null)
                    {
                        _Brush.Dispose();
                        _Brush = null;
                    }
                    if(_Bitmap != null)
                    {
                        _Bitmap.Dispose();
                        _Bitmap = null;
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
        ~Drawable()
        {
            this.Dispose(false);
        }
    }
}
