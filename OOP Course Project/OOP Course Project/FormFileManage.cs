using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Course_Project
{
    public partial class FormFileManage : Form
    {
        private readonly string _command;
        public string Path { get; set; }
        public FormFileManage(string comand)
        {
            InitializeComponent();
            _command = comand;
        }

        private void FormFileManage_Load(object sender, EventArgs e)
        {
           switch(_command)
            {
                case "Open":
                    button1.Text = "Open";
                    break;
                case "Save":
                    button1.Text = "Save";
                    break;
                default:
                    Close();
                    break;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please enter a valid file name!");
                return;
            }
            if (File.Exists(textBox1.Text) && _command == "Save")
            {
               DialogResult res = 
                    MessageBox.Show("A file with the given name already exists. Would you like to replace it?", "Notification", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                    return;
            }
            Path = textBox1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
