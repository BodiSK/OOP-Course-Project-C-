using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Course_Project
{
    public static class Extensions
    {
        public static Color FromByteArray(this Color c, byte [] argb )
        {
            if (argb.Length != 4)
                throw new Exception("Invalid inputs! ARGB components must be exactly 4");
            return Color.FromArgb(argb[0], argb[1], argb[2], argb[3]);
        }
        public static byte [] ToByteArray(this Color c)
        {
            var argb = new byte[] { c.A, c.R, c.G, c.B };
            return argb; ;
        }
    }
}
