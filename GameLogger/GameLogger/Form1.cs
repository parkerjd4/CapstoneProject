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
    public partial class From1: Form
    {
        String nameOfGame = ""; 

        public From1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nameOfGame = GameName.Text;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }
    }
}
