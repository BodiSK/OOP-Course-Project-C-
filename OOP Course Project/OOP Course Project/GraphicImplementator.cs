using CourseProjectLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Course_Project
{
    public class GraphicsImplementator:IGraphics
    {
        public Graphics GraphicsObj { get; set; }
        public Color ColorObj { get; set; }
        public void DrawEllipse(bool choosen, byte[] colorGrid, byte[] colorFill, int x, int y, int axisA, int axisB, int thickness)
        {
            if (GraphicsObj != null)
            {
                using (var brush = new SolidBrush(ColorObj.FromByteArray(colorFill)))
                    GraphicsObj.FillEllipse(brush, x, y, axisA, axisB);
                using (var pen = new Pen(choosen ? Color.Red : ColorObj.FromByteArray(colorGrid), thickness))
                    GraphicsObj.DrawEllipse(pen, x, y, axisA, axisB);
            }
        }
        public void DrawRectangle(bool choosen, byte[] colorGrid, byte[] colorFill, int x, int y, int width, int height, int thickness)
        {
            if (GraphicsObj != null)
            {
                using (var brush = new SolidBrush(ColorObj.FromByteArray(colorFill)))
                    GraphicsObj.FillRectangle(brush, x, y, width, height);
                using (var pen = new Pen(choosen ? Color.Red : ColorObj.FromByteArray(colorGrid), thickness))
                    GraphicsObj.DrawRectangle(pen, x, y, width, height);
            }
        }
        public void DrawTriangle(bool choosen, byte[] colorGrid, byte[] colorFill, List<int[]> _verticies, int thickness)
        {
            var ver = _verticies.Select(v => new Point(v[0], v[1])).ToArray();
            if (GraphicsObj != null)
            {
                using (var brush = new SolidBrush(ColorObj.FromByteArray(colorFill)))
                    GraphicsObj.FillPolygon(brush, ver);
                using (var pen = new Pen(choosen ? Color.Red : ColorObj.FromByteArray(colorGrid), thickness))
                    GraphicsObj.DrawPolygon(pen, ver);
            }
        }
    }
}
