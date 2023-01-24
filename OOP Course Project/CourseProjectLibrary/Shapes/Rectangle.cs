using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLibrary
{
    [Serializable]
    public class Rectangle : Shape
    {
        public double Width
        {
            get => FrameWidth; 
        }
        public double Height 
        {
            get => FrameHeight; 
        }
        public double Diagonal
        {
            get => Math.Sqrt(FrameHeight * FrameHeight + FrameWidth * FrameWidth);
        }
        public override void DrawFigure(IGraphics gr) =>
            gr.DrawRectangle(Choosen, ColorGrid.ARGB, ColorFill.ARGB, Location.X, Location.Y, (int)Width, (int)Height, Thickness);
                       
        public override double GetSuraface() => Width * Height;

        public override bool PointInShape(int pointX, int pointY)
        {
            if (Choosen = (Location.X <= pointX && pointX <= Location.X + Width &&
                   Location.Y <= pointY && pointY <= Location.Y + Height))
                FireClick();
            return Choosen;
        }
        public override Dictionary<string, string> ShapeProperties()
        {
            Dictionary<string, string> rectangleProperties = new Dictionary<string, string>
            {
                { "Shape", "Rectangle" },
                { "Width", $"{Width}" },
                { "Height", $"{Height}" }
            };

            return rectangleProperties;
        }
        public override string ShapeSpecificInfo() => $"Diagonal: {Diagonal: 0.00}\n Surface: {GetSuraface(): 0.00}";
        public override string ToString()=>  $"Shape: Rectangle\n Width:{Width}\n Height:{Height}" ;
        
    }
}
