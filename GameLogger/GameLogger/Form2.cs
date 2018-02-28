using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace GameLogger
{
    public partial class Form2 : Form
    {
        public string Name1
        {
            get => this.Name;
            set
            {
                this.Name = value;
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow window = new MainWindow();

            window.gameListImg.SelectedItems.Clear();
            
            Close();
        }

        public System.Drawing.Point LocLabel()
        {
            System.Drawing.Point loc = new System.Drawing.Point(label1.Location.X, label1.Location.Y);
            return loc;
        }

        public void SetLabel1(string label)
        {
            label1.Text += label;
        }
        public void SetLabel2(string label)
        {
            label2.Text += label;
        }
        public void SetLabel3(string label)
        {
            label3.Text += label;
        }
        public void SetLabel4(string label)
        {
            label4.Text += label;
        }
        public void SetLabel5(string label)
        {
            label5.Text += label;
        }
        public void SetLabel6(string label)
        {
            label6.Text += label;
        }
        public void SetLabel7(string label)
        {
            label7.Text += label;
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
