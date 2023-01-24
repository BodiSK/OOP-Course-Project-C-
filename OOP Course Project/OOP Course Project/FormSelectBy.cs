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
    public partial class FormSelectBy : Form
    {
        public List<Shape> Collection { get; set; }
        public FormSelectBy()
        {
            InitializeComponent();
        }

        private void FormSelectBy_Load(object sender, EventArgs e)
        {
            listBoxInformation.Items.Clear();
            var groups= Collection.GroupBy(element => element.GetType());//LINQ - групиране
            foreach(var key in groups)
            {
                listBoxInformation.Items.Add($"{key.Key.Name} elements on the Scene = {key.Count()}");
            }
        }

        private void ListBoxInformation_Click(object sender, EventArgs e)=>
            buttonSelection.Visible = listBoxInformation.SelectedItem != null;

        private void ButtonSelection_Click(object sender, EventArgs e)
        {
            var newColection = Collection.
                Where(el => el.GetType().Name == (listBoxInformation.SelectedItem.ToString().Split().ElementAt(0))).ToList();//LINQ - филтрация
            newColection.ForEach(s => s.Intersect(s.Copy()));
            DialogResult = DialogResult.OK;
        }
    }
}
