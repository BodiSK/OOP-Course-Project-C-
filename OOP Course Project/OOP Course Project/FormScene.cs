using CourseProjectLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rectangle = CourseProjectLibrary.Rectangle;

namespace OOP_Course_Project
{
    public partial class FormScene : Form
    {
        private List<Shape> _shapes = new List<Shape>();
        private Point _mouseDownLocation;
        private Shape _frame;
        private PictureBox _pictureBox;
        private int _thickness;
        private bool _selectionMode;
        private bool _alreadySaved;
        private readonly GraphicsImplementator gr = new GraphicsImplementator();

        public FormScene()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
            _selectionMode = false;
        } 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            gr.GraphicsObj = e.Graphics;
            foreach (var s in _shapes)
                s.DrawFigure(gr);

            _frame?.DrawFigure(gr);
            toolStripSurfaceStatusLabel.Text = _shapes.Select(s => s.GetSuraface())
                             .DefaultIfEmpty()
                             .Aggregate((f,s)=>f+s).ToString("0.00");//LINQ - проекция + агрегация
            optionsToolStripMenuItem.Visible = _shapes.Any(s => s.Choosen);
            gr.GraphicsObj= null;
        }
        private void FormScene_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDownLocation = e.Location;
            if (!Click(_mouseDownLocation))
                ToolStripStatusCurrentShapeLabel.Text = "";
            Invalidate();
        }
        private void FormScene_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripMouseLocStatusLabel.Text = e.Location.ToString();
            if (_frame != null && e.Button == MouseButtons.Left)
            {
                var point = new Point
                {
                    X = Math.Min(e.Location.X, _mouseDownLocation.X),
                    Y = Math.Min(e.Location.Y, _mouseDownLocation.Y)
                };
                _frame.MoveToNewLocation(_frame.Location.X, _frame.Location.Y, point.X, point.Y);
                _frame.Resize(Math.Abs(e.Location.X - _mouseDownLocation.X), Math.Abs(e.Location.Y - _mouseDownLocation.Y));
            }
            if (e.Button == MouseButtons.Right)
            {
                foreach (var s in _shapes)
                    if (s.Choosen)
                    {
                        s.MoveToNewLocation(_mouseDownLocation.X, _mouseDownLocation.Y, e.Location.X, e.Location.Y);
                        break;
                    }
                _mouseDownLocation = e.Location;
            }
            Invalidate();
        }

        private void FormScene_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _frame != null)
            {
                if (!_selectionMode)
                    _shapes.Add(_frame);
                else
                {
                    foreach (var s in _shapes)
                        s.Intersect(_frame);
                    _selectionMode = false;
                    toolStripeSelectMenuItem.BackColor = Color.Transparent;
                }
            }

            _frame = null;
            Invalidate();
        }
        private void FormScene_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //LINQ - филтрация, проекция, сортиране
            var shape = _shapes.Where(s => s.Choosen).
                Select((s, i) => new
                {
                    obj = s,
                    index = i
                }).OrderByDescending(s => s.index).Select(s => (Shape)s.obj).ElementAtOrDefault(0);
            if (shape != null)
            {
                var fp = new FormProperties
                {
                    Shape = shape,
                };
                fp.ShowDialog();
            }
        }
        private void FormScene_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_alreadySaved)
            {
                DialogResult res =
                    MessageBox.Show("Do you want to save this file?", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    var fm = new FormFileManage("Save");
                    fm.ShowDialog();
                    if (fm.DialogResult != DialogResult.Cancel)
                    {
                        var path = fm.Path;
                        var formatter = new BinaryFormatter();

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            formatter.Serialize(stream, _shapes);
                        }
                    }
                }
            }
        }
        private void OnClick(Shape shape)
        {
            MenuStripOptions.Visible = true;
            ToolStripStatusCurrentShapeLabel.Text = shape.ToString();
        }
        private new bool Click(Point point)
        {
            //LINQ сортиране (разделяне на данни + взимане на елемент)
            var sh = _shapes.AsEnumerable().Reverse().SkipWhile(s => !s.PointInShape(point.X, point.Y)).FirstOrDefault();
            if (sh != null)
            {
                _shapes.Remove(sh);
                _shapes.Add(sh);
                return true;
            }
            return false;
        }
        private void FileToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)//меню File
        {
            if (NewToolStripMenuItem.Selected)
            { 
                _shapes.Clear();
                return;
            }
            string path;
            FormFileManage fm;
            var formatter = new BinaryFormatter();

            if (OpenToolStripMenuItem.Selected)//отваряне на съществуващ файл
            {
                fm = new FormFileManage("Open");
                fm.ShowDialog();
                path = fm.Path;
                if (fm.DialogResult != DialogResult.Cancel)
                {
                    if (!File.Exists(path))
                    {
                        MessageBox.Show("File not found!");
                        return;
                    }

                    using (var stream = new FileStream(path, FileMode.Open))
                    {
                        _shapes = (List<Shape>)formatter.Deserialize(stream);
                        foreach (var s in _shapes)
                            s.OnClick += OnClick;
                    }
                }
            }
            if (saveToolStripMenuItem.Selected)//запазване на данните във файл
            {
                fm = new FormFileManage("Save");
                fm.ShowDialog();
                path = fm.Path;
                if (fm.DialogResult != DialogResult.Cancel)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        formatter.Serialize(stream, _shapes);
                    }

                    _alreadySaved = true;
                    Close();
                }
            }
        }
        private void CreateFigureToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)//меню за създаване на фигура
        {
            if (CircleToolStripMenuItem.Selected)
                _frame = new Circle();
            if (EllipseToolStripMenuItem.Selected)
                _frame = new Ellipse();
            if (SquareToolStripMenuItem.Selected)
                _frame = new Square();
            if (RectangleToolStripMenuItem.Selected)
                _frame = new Rectangle();
            if (TriangleToolStripMenuItem.Selected)
                _frame = new Triangle();


            if (_frame != null)
            {
                _frame.OnClick += OnClick;
                _frame.ColorFill.ARGB= PictureBoxColorFill.BackColor.ToByteArray();
                _frame.ColorGrid.ARGB = PictureBoxColorGrid.BackColor.ToByteArray();
                _frame.Thickness = _thickness != 0 ? _thickness : 1;
            }
        }
        private void ToolStripeSelectMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (byTypeToolStripMenuItem.Selected && _shapes.Count() != 0)
            {
                var fsb = new FormSelectBy();
                fsb.Collection = _shapes;
                fsb.ShowDialog();
            }
            else
            {
                _selectionMode = true;
                toolStripeSelectMenuItem.BackColor = Color.Beige;
                _frame = new Rectangle();
                _frame.ColorFill.ARGB = Color.Transparent.ToByteArray();
                _frame.ColorGrid.ARGB = Color.LightGray.ToByteArray();
            }
        }
        private void TicknessToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)//задава дебелина на линии
        {
            foreach (ToolStripItem item in TicknessToolStripMenuItem.DropDownItems)
                if (item.Selected)
                    _thickness = int.Parse(item.Text);
        }
        private void PictureBoxColorPurple_Click(object sender, EventArgs e)//избиране на цвят
            => _pictureBox = (PictureBox)sender;

        private void ButtonMoreColors_Click(object sender, EventArgs e)//избиране на допълнителни цветове
        {
            var cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                _pictureBox = new PictureBox
                {
                    BackColor = cd.Color
                };
            }
        }
        private void ColorFillToolStripMenuItem_Click(object sender, EventArgs e) =>
            PictureBoxColorFill.BackColor = _pictureBox != null ? _pictureBox.BackColor : Color.White;//задава цвят на вътрешност при чертане


        private void ColorGridToolStripMenuItem_Click(object sender, EventArgs e) =>
            PictureBoxColorGrid.BackColor = _pictureBox != null ? _pictureBox.BackColor : Color.Black;//задава цвят на рамка при чертане

        private void OptionsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (CopyToolStripMenuItem.Selected)//копиране на избраните фигури
            {
                List<Shape> copies = _shapes
                    .Where(s => s.Choosen).Select(s => s.Copy()).ToList();//LINQ филтрация+проекция
                copies.ForEach(c => c.MoveToNewLocation(c.Location.X, c.Location.Y, Location.X, Location.Y));
                copies.ForEach(c => c.OnClick += OnClick);
                _shapes = _shapes.Concat(copies).ToList();//LINQ - конкатенация    
            }
            if (DeletetoolStripMenuItem.Selected)//изтриване на избраните фигури
                _shapes = _shapes.Where(s => !s.Choosen).ToList();//LINQ - филтрация
            if (changeToGivenColorToolStripMenuItem.Selected)
                _shapes.Where(s => s.Choosen).ToList().ForEach(el => {
                    el.ColorFill.ARGB = PictureBoxColorFill.BackColor.ToByteArray();
                    el.ColorGrid.ARGB = PictureBoxColorGrid.BackColor.ToByteArray();
                });
        }
        private void FormScene_Resize(object sender, EventArgs e) =>
            ToolStripSizeOfFormStatusLabel.Text = $"{this.Width} X {this.Height}";
    }
}
