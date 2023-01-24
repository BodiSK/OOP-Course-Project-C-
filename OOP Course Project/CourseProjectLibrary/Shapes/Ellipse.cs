using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLibrary
{
    [Serializable]
    public class Ellipse : Shape
    {
        public double AxisA
        {
            get => FrameWidth ;
        }
        public double AxisB
        {
            get => FrameHeight ;
        }
        
        public override void DrawFigure(IGraphics gr)=>
           gr.DrawEllipse(Choosen, ColorGrid.ARGB, ColorFill.ARGB, Location.X, Location.Y, (int)AxisA, (int)AxisB, Thickness);
        
        public override double GetSuraface() => (Math.PI * AxisA * AxisB)/4;

        public override bool PointInShape(int pointX, int pointY)
        {
            var center = new CPLPoint(Location.X + (int)(AxisA/2 ), 
                                     Location.Y + (int)(AxisB/2));
            var p = (Math.Pow((pointX - center.X), 2) /
                     Math.Pow(AxisA/2, 2)) +
                    (Math.Pow((pointY- center.Y), 2) /
                     Math.Pow(AxisB/2, 2));
            if (Choosen = (p < 1))
                FireClick();
            return Choosen;
        }
        public override Dictionary<string, string> ShapeProperties()
        {
            Dictionary<string, string> ellipseProperties = new Dictionary<string, string>
            {
                { "Shape: ", "Ellipse" },
                { "AxisA", $"{AxisA}" },
                { "AxisB", $"{AxisB}" }
            };

            return ellipseProperties;
        }
        public override string ShapeSpecificInfo() => 
            $"SemiMajorAxisA: {AxisA/2}\n SemiMajorAxisB: {AxisB / 2}\nSurface: {GetSuraface():0,00}";
        public override string ToString()=> $"Shape: Ellipse\n AxisA:{AxisA}\n AxisB: {AxisB}\n";

    }
}
