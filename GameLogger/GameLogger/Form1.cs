using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Diagnostics;

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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //HttpResponse<T> response = Unirest.get("https://api-2445582011268.apicast.io/characters/?fields=*&limit=10")
                //.header("user-key", "c707f6bc39116f2006b8a0d61e23175e")
               // .header("Accept", "application/json").asJson();


        }
    }
}
