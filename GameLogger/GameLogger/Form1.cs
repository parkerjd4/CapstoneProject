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
using IgdbApi;

namespace GameLogger
{
    public partial class From1: Form
    {   
        public From1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.AddToFile(GameName.Text);
        }

        private async void TextBox1_TextChangedAsync(object sender, EventArgs e)
        {
            Grab_gamesAsync();

        }

        private async Task Grab_gamesAsync()
        {
            IIgdbGamesApi gamesApi = new IgdbApi.IgdbApi("c707f6bc39116f2006b8a0d61e23175e");
            var games = await gamesApi.GetGamesAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
