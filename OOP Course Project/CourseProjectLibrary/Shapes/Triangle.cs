using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLibrary
{
    [Serializable]
    public class Triangle: Shape
    {
        private CPLPoint[] _verticies = new CPLPoint[3];
        public double Side
        {
            get => FrameWidth; 
        }
        public double Height 
        {
            get => FrameHeight;
        }
        private double AreaViaPoints(int x1, int y1, int x2,
                       int y2, int x3, int y3)
        {
            return Math.Abs((x1 * (y2 - y3) +
                             x2 * (y3 - y1) +
                             x3 * (y1 - y2)) / 2.0);
        }
        private void SetVerticies()
        {
            _verticies[0] = new CPLPoint(Location.X + (int)Side / 2, Location.Y);
            _verticies[1] = new CPLPoint(Location.X, Location.Y + (int)Height);
            _verticies[2] = new CPLPoint(Location.X + (int)Side, Location.Y + (int)Height);
        }
        public override void Resize(double x, double y)
        {
            base.Resize(x, y);
            SetVerticies();
        }
        public override void DrawFigure(IGraphics gr)
        {
            SetVerticies();
            var list = _verticies.Select(v => v.PointToArr()).ToList();
            gr.DrawTriangle(Choosen,ColorGrid.ARGB, ColorFill.ARGB, list, Thickness);
        }
        public override double GetSuraface() => Height * Side / 2;

        public override bool PointInShape(int pointX, int y)
        {
            var a = this.GetSuraface();
            SetVerticies();
            double A1 = AreaViaPoints(pointX, y, _verticies[1].X, _verticies[1].Y, _verticies[2].X, _verticies[2].Y);
            double A2 = AreaViaPoints(_verticies[0].X, _verticies[0].Y, pointX, y, _verticies[2].X, _verticies[2].Y);
            double A3 = AreaViaPoints(_verticies[0].X, _verticies[0].Y, _verticies[1].X, _verticies[1].Y, pointX, y);

            if (Choosen = (a == A1 + A2 + A3))
                FireClick();
            return Choosen;
        }

        public override Dictionary<string, string> ShapeProperties()
        {
            Dictionary<string, string> triangleProperties = new Dictionary<string, string>
            {
                { "Shape", "Triangle" },
                { "Base Side", $"{Side}" },
                { "Height", $"{Height}" }
            };

            return triangleProperties;
        }
        public override string ShapeSpecificInfo() =>
            $"Triangle's Legs : {Math.Sqrt(Math.Pow(Side / 2, 2) + Math.Pow(Height, 2)):0.00}\n Surface: {GetSuraface(): 0.00}";
        public override string ToString()=> $"Shape:Triangle\n Base side:{Side}\n Height:{Height}";
    }
}
