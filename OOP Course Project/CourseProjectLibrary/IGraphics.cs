using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLibrary
{
    public interface IGraphics
    {
         void DrawEllipse(bool choosen, byte [] colorGrid, byte [] colorFill, int x, int y, int axisA, int axisB, int thickness);
         void DrawRectangle(bool choosen,byte[] colorGrid, byte[] colorFill, int x, int y, int width, int height, int thickness);
         void DrawTriangle(bool choosen, byte [] colorGrid, byte [] colorFill, List<int []> _verticies, int thickness);
    }
}
