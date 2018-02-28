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
    }
}
