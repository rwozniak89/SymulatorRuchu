using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1
{
    public struct BitsOper
    {
        int _Bits;

        public BitsOper(int bits)
        {
            _Bits = bits;
        }

        public bool this[int index]
        {
            get
            {
                return (_Bits & (1 << index)) != 0;
            }
            set
            {
                if(value)
                    _Bits |= (1 << index);
                else
                    _Bits &= ~(1 << index);

            }
        }

        public override string ToString()
        {
            return Convert.ToString(_Bits, 2);
        }
    }
}
