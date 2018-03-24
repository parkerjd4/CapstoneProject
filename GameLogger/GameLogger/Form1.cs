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
using System.Windows.Controls;
using System.Windows.Data;
using Newtonsoft.Json;
using unirest_net;
using unirest_net.http;
using Json;
using GiantBomb.Api;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Google.Apis;
using System.Windows.Documents;
using System.Xml;

namespace GameLogger
{
    public partial class From1: Form
    {
        string Search; 
        public From1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow win = new MainWindow();
            try
            {
                var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
                var result = client.SearchForGames(Search).ToList();
                int id = result.FirstOrDefault().Id;
                var r1 = client.GetGame(id);
                string cat = comboBox1.SelectedItem.ToString();
                win.AddToFile(Search,cat);

            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Not a vaild game.");
            }


        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string value = ((System.Windows.Forms.TextBox)sender).Text;
            
            
            Search = value; 

        }

        private void Grab_gamesAsync()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
