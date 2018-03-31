using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiantBomb.Api;
using GiantBomb.Api.Model;

namespace GameLogger
{
    public partial class RecommendGames : Form
    {
        public RecommendGames()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        internal void SetTableContents(List<Game> similarGames)
        {
            var Game = similarGames[0];
            linkLabel1.Text = similarGames[0].Name.ToString();
            linkLabel2.Text = similarGames[1].Name.ToString();
            linkLabel3.Text = similarGames[2].Name.ToString();
            linkLabel4.Text = similarGames[3].Name.ToString();
            var Client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var Result1 = Client.SearchForGames(similarGames[0].Name.ToString()).ToList();
            var Game1 = Client.GetGame(Result1.First().Id);
            var Result2 = Client.SearchForGames(similarGames[1].Name.ToString()).ToList();
            var Game2 = Client.GetGame(Result2.First().Id);
            var Result3 = Client.SearchForGames(similarGames[2].Name.ToString()).ToList();
            var Game3 = Client.GetGame(Result3.First().Id);
            var Result4 = Client.SearchForGames(similarGames[4].Name.ToString()).ToList();
            var Game4 = Client.GetGame(Result4.First().Id);


            label4.Text = Game1.Deck.ToString(); 
            //string.Join(Environment.NewLine + "                    ", similarGames[0].Deck.ToString().Split().Select((word, index) => new { word, index }).GroupBy(y => y.index / 9).Select(grp => string.Join(" ", grp.Select(y => y.word))));
            label5.Text = Game2.Deck.ToString();
            label6.Text = Game3.Deck.ToString();
            label7.Text = Game4.Deck.ToString();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
