using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            //label4.Text = Game.Description.ToString(); 
            //string.Join(Environment.NewLine + "                    ", similarGames[0].Deck.ToString().Split().Select((word, index) => new { word, index }).GroupBy(y => y.index / 9).Select(grp => string.Join(" ", grp.Select(y => y.word))));
            //label5.Text = string.Join(Environment.NewLine + "                    ", similarGames[1].Deck.ToString().Split().Select((word, index) => new { word, index }).GroupBy(y => y.index / 9).Select(grp => string.Join(" ", grp.Select(y => y.word))));
            //label6.Text = string.Join(Environment.NewLine + "                    ", similarGames[2].Deck.ToString().Split().Select((word, index) => new { word, index }).GroupBy(y => y.index / 9).Select(grp => string.Join(" ", grp.Select(y => y.word))));
            //label7.Text = string.Join(Environment.NewLine + "                    ", similarGames[3].Deck.ToString().Split().Select((word, index) => new { word, index }).GroupBy(y => y.index / 9).Select(grp => string.Join(" ", grp.Select(y => y.word))));

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
