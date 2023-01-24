using CourseProjectLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Course_Project
{
    public partial class FormProperties : Form
    {
        public  Shape Shape { get; set; }
        private double _frameWidthSetter;
        private double _frameHeightSetter;
        private int _propertiesCount;
        private Shape _shape;
        private readonly GraphicsImplementator gr = new GraphicsImplementator();
        public FormProperties()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Visualizer.Checked)
            {
                gr.GraphicsObj = e.Graphics;
                _shape.DrawFigure(gr);
            }
            gr.GraphicsObj = null;
        }
        private void FormProperties_Load(object sender, EventArgs e)
        {
            _shape = Shape.Copy();
            _shape.MoveToNewLocation(_shape.Location.X, _shape.Location.Y, Visualizer.Location.X, Visualizer.Location.Y + 80);

            var properties = _shape.ShapeProperties();
            AdditionalInfoTextBox.Text = _shape.ShapeSpecificInfo();

            TypeOfShape.Text = properties.FirstOrDefault().Key + properties.FirstOrDefault().Value;
            Properties1.Text = properties.ElementAtOrDefault(1).Key;
            Property1TextBox.Text = properties.ElementAtOrDefault(1).Value;

            if(properties.Count>2)
            {
                Properties2.Text = properties.ElementAtOrDefault(2).Key;
                Property2TextBox.Text = properties.ElementAtOrDefault(2).Value;
                _propertiesCount = properties.Count;
            }
            else
            {
                Properties2.Visible = false;
                Property2TextBox.Visible = false;
            }
            ColorFillButton.BackColor = gr.ColorObj.FromByteArray(_shape.ColorFill.ARGB);
            ColorGridButton.BackColor = gr.ColorObj.FromByteArray(_shape.ColorGrid.ARGB);
            numericUpDownThickness.Value = _shape.Thickness;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(Property1TextBox) || 
                (Property2TextBox.Visible && !ValidateInputs(Property2TextBox)))
               return;

            AdjustFrame(Shape);
            Shape.ColorGrid.ARGB = ColorGridButton.BackColor.ToByteArray();
            Shape.ColorFill.ARGB = ColorFillButton.BackColor.ToByteArray();
            Shape.Thickness = (int)numericUpDownThickness.Value;
            DialogResult = DialogResult.OK;
        }
        private void ButtonCancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void Visualizer_CheckedChanged(object sender, EventArgs e)
        {
             if (Visualizer.Checked)
                 using ( gr.GraphicsObj = CreateGraphics())
                   _shape.DrawFigure(gr);
             else
                 Invalidate();
        }
        private void Property2TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (e.KeyChar == (char)Keys.Enter)
            {
                AdjustFrame(_shape);
                AdditionalInfoTextBox.Text = _shape.ShapeSpecificInfo();
                Invalidate();
            }
        }
        private void ColorFillButton_Click_1(object sender, EventArgs e)//избиране на цвят
        {
            var button = (Button)sender;
            var cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                button.BackColor = cd.Color;
                if (button == ColorFillButton)
                    _shape.ColorFill.ARGB = cd.Color.ToByteArray();
                else
                    _shape.ColorGrid.ARGB = cd.Color.ToByteArray();
                Invalidate();
            }
        }
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _shape.Thickness = (int)numericUpDownThickness.Value;
            Invalidate();
        }
        private void AdjustFrame(Shape shape)//преоразмеряване на фигурата според зададени стойности
        {
            if (!ValidateInputs(Property1TextBox) ||
                (Property2TextBox.Visible && !ValidateInputs(Property2TextBox)))
                return;
            _frameWidthSetter = double.Parse(Property1TextBox.Text);
            if (_propertiesCount > 2)
                _frameHeightSetter = double.Parse(Property2TextBox.Text);
            else
                _frameHeightSetter = _frameWidthSetter;
            shape.Resize(_frameWidthSetter, _frameHeightSetter);
        }
        private bool ValidateInputs(TextBox textBox)//проверка дали въведените стойности са легитимни
        {
            bool valid= double.TryParse(textBox.Text, out double result) && result > 0;
            if (!valid)
                MessageBox.Show($"Input {textBox.Text} is not valid! Correct inputs for this textbox can be positive numbers only");
            return valid;
        }
    }
}
