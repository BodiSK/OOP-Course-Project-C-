using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLibrary
{

    public delegate void Click(Shape shape);
    [Serializable]
    abstract public class Shape
    {
        private CPLColor _colorFill = new CPLColor();
        private CPLColor _colorGrid = new CPLColor();
        private int _thickness;

        protected double FrameWidth { get;  private set; }
        protected double FrameHeight { get;  private set; }
        public CPLPoint Location { get; private set; }
        public CPLColor ColorFill 
        { 
            get => _colorFill; 
            set => _colorFill = value; 
        }
        public CPLColor ColorGrid
        { 
            get => _colorGrid;
            set => _colorGrid = value;
        }
        public int Thickness
        {
            get => Choosen ? _thickness + 2 : _thickness;
            set
            {
                if (value <= 0)
                    throw new InvalidValueExeption("Argument thickness can be positive integer only!");
                _thickness = value;
            }
        }
        public bool Choosen {get; protected set;}
        protected void FireClick()
        {
            OnClick?.Invoke(this);
        }
        public abstract void DrawFigure(IGraphics gr);
        public abstract double GetSuraface();
        public abstract bool PointInShape(int pointX, int pointY);
        public abstract Dictionary<string, string> ShapeProperties();
        public abstract string ShapeSpecificInfo();
        public virtual void Resize(double x, double y)
        {
            if (x < 0 || y < 0)
                throw new InvalidValueExeption("Incorrect inputs! Parameters can be positive numbers only!");
            FrameWidth = x;
            FrameHeight = y;
        }
        public void  MoveToNewLocation(int StartingPosX, int StartingPosY,int EndPosX, int EndPosY)
        {
           Location = new CPLPoint(Math.Abs((EndPosX - StartingPosX + Location.X)), Math.Abs((EndPosY - StartingPosY + Location.Y)));
        }
        public bool Intersect(Shape shape)
        {
            return Choosen =
                Location.X < shape.Location.X + shape.FrameWidth && shape.Location.X < Location.X + FrameWidth &&
                Location.Y < shape.Location.Y + shape.FrameHeight && shape.Location.Y < Location.Y + FrameHeight;
        }
        public Shape Copy()
        {
            Choosen = false;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;

                return (Shape)formatter.Deserialize(stream);
            }
        }

        [field: NonSerializedAttribute()]   
        public event Click OnClick;
    }
}
