using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLibrary
{
    [Serializable]
    public class CPLColor
    {
        private  byte[] _argb;
        public byte [] ARGB
        { 
            get=>_argb;
            set 
            {
                if (value == null)
                { 
                    _argb = new byte[4];
                    return;
                }
                if (value.Length != 4)
                    throw new InvalidValueExeption("The number of components to form an argb must be 4! ");
                _argb = value;
            }
        }
        public CPLColor()
        {

        }
        public CPLColor(byte alpha, byte red, byte green, byte blue)
        {
            _argb = new byte[4];
            _argb[0] = alpha;
            _argb[1] = red;
            _argb[2] = green;
            _argb[3] = blue;
        }
    }
}