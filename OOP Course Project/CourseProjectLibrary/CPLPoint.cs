using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLibrary
{
    [Serializable]
    public struct CPLPoint
    {
        private int _x;
        private int _y;
        public int X 
        {
            get =>_x;
            set
            {
                if (value < 0)
                    throw new InvalidValueExeption("A coordiante of a point must be nonnegative!");
                _x = value;
            }
        }
        public int Y 
        {

            get => _y;
            set
            {
                if (value < 0)
                    throw new InvalidValueExeption("A coordiante of a point must be nonnegative!");
                _y = value;
            }
        }

        public CPLPoint(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new InvalidValueExeption("Coordinates cannot be negative numbers!");
            _x = x;
            _y = y;
        }

        public int[] PointToArr() => new int[2] { _x, _y };

    }
}