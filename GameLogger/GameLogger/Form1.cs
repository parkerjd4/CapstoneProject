﻿using System;
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
            win.AddToFile(Search);
            /*var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var result = client.SearchForGames(Search).ToList();
            result.ForEach(Console.WriteLine);*/
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
