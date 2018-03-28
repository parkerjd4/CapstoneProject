using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLogger
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        public void SetLabel1(string name)
        {
            label1.Text = name; 
        }
        public void SetComboBox1(string name, string[] list)
        {
            comboBox1.Text = name; 
            for(int i = 0; i < list.Length; i++)
            {
                comboBox1.Items.Add(list[i]);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
