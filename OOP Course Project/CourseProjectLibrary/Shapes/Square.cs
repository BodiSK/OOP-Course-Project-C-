using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLibrary
{
    [Serializable]
    public class Square : Rectangle
    {
        public double Side
        {
            get => FrameWidth; 
        }
        public override void Resize(double x, double y=-1)
        { 
            base.Resize(x, x); 
        }
        public override Dictionary<string, string> ShapeProperties()
        {
            Dictionary<string, string> squareProperties = new Dictionary<string, string>
            {
                { "Shape", "Square" },
                { "Side", $"{Side}" }
            };

            return squareProperties;
        }
        public override string ShapeSpecificInfo() => $"Diagonals: {Diagonal:0.00}\nSurface: {GetSuraface(): 0.00}";
        public override string ToString()=> $"Shape: Square\n Side:{Side}"; 
    }
}
