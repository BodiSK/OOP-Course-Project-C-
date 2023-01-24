using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLibrary
{
    [Serializable]
    public class Circle: Ellipse
    {
        public double Diameter
        {
            get => FrameWidth;
        }
        public double Radius
        {
            get => FrameWidth / 2; 
        }
        public override void Resize(double diameter, double y=-1)
        {
            base.Resize(diameter, diameter);
        }
        public override Dictionary<string, string> ShapeProperties()
        {
            Dictionary<string, string> circleProperties = new Dictionary<string, string>
            {
                { "Shape: ", "Circle" },
                { "Diameter", $"{Diameter}" }
            };

            return circleProperties;
        }
        public override string ShapeSpecificInfo()=> $"Radius: {Radius}\n Surface: {GetSuraface():0.00}";
        public override string ToString()=> $"Shape: Circle\n Radius:{Radius} ";
        
    }
}
