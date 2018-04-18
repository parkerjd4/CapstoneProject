using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiantBomb.Api;
using GiantBomb.Api.Model;

namespace GameLogger
{
    public partial class RecommendGames : Form
    {
        string GameName1;
        string GameName2;
        string GameName3;
        string GameName4; 

        public RecommendGames()
        {
            InitializeComponent();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void Label3_Click(object sender, EventArgs e)
        {
        }

        private void Label4_Click(object sender, EventArgs e)
        {
        }

        internal void SetTableContents(List<Game> similarGames)
        {
            var Client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            WebClient client = new WebClient();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, @"GameLogger\Images");
            System.IO.Directory.CreateDirectory(complete);
            try
            {
                linkLabel1.Text = similarGames[0].Name.ToString();
                var Result1 = Client.SearchForGames(similarGames[0].Name.ToString()).ToList();
                var Game1 = Client.GetGame(Result1.First().Id);
                GameName1 = Game1.SiteDetailUrl.ToString();
                string url = Game1.Image.MediumUrl.ToString().Trim();               
                var filepath = System.IO.Path.Combine(complete, Game1.Id + ".png");
                if(!(File.Exists(filepath)))
                {
                    client.Headers["User-Agent"] = "josedpar";
                    client.DownloadFile(new Uri(url), filepath);
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = System.Drawing.Image.FromFile(filepath);
                label4.Text = Game1.Deck.ToString();

            }
            catch(ArgumentOutOfRangeException)
            {
                linkLabel1.Text = "Missing Game";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = GameLogger.Properties.Resources.question_mark;
                label4.Text = "Missing Game";

            }
            try
            {
                linkLabel2.Text = similarGames[1].Name.ToString();
                var Result2 = Client.SearchForGames(similarGames[1].Name.ToString()).ToList();
                var Game2 = Client.GetGame(Result2.First().Id);
                GameName2 = Game2.SiteDetailUrl.ToString();
                string url1 = Game2.Image.MediumUrl.ToString().Trim();
                var filepath1 = System.IO.Path.Combine(complete, Game2.Id + ".png");
                if (!(File.Exists(filepath1)))
                {
                    client.Headers["User-Agent"] = "josedpar123";
                    client.DownloadFile(new Uri(url1), filepath1);
                }
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = System.Drawing.Image.FromFile(filepath1);
                label5.Text = Game2.Deck.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                linkLabel2.Text = "Missing Game";
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = GameLogger.Properties.Resources.question_mark;
                label5.Text = "Missing Game";

            }
            try
            {
                linkLabel3.Text = similarGames[2].Name.ToString();
                var Result3 = Client.SearchForGames(similarGames[2].Name.ToString()).ToList();
                var Game3 = Client.GetGame(Result3.First().Id);
                GameName3 = Game3.SiteDetailUrl.ToString();
                string url2 = Game3.Image.MediumUrl.ToString().Trim();
                var filepath2 = System.IO.Path.Combine(complete, Game3.Id + ".png");
                if (!(File.Exists(filepath2)))
                {
                    client.Headers["User-Agent"] = "josedparCAP";
                    client.DownloadFile(new Uri(url2), filepath2);
                }
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.Image = System.Drawing.Image.FromFile(filepath2);
                label6.Text = Game3.Deck.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                linkLabel3.Text = "Missing Game";
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.Image = GameLogger.Properties.Resources.question_mark;
                label6.Text = "Missing Game";
            }
            try
            {
                linkLabel4.Text = similarGames[3].Name.ToString();
                var Result4 = Client.SearchForGames(similarGames[3].Name.ToString()).ToList();
                var Game4 = Client.GetGame(Result4.First().Id);
                GameName4 = Game4.SiteDetailUrl.ToString();
                string url3 = Game4.Image.MediumUrl.ToString().Trim();
                var filepath3 = System.IO.Path.Combine(complete, Game4.Id + ".png");
                if (!(File.Exists(filepath3)))
                {
                    client.Headers["User-Agent"] = "josedparSTONE";
                    client.DownloadFile(new Uri(url3), filepath3);
                }
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.Image = System.Drawing.Image.FromFile(filepath3);
                label7.Text = Game4.Deck.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                linkLabel4.Text = "Missing Game";
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.Image = GameLogger.Properties.Resources.question_mark;
                label7.Text = "Missing Game";
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TopMost = false;
            try
            {
                linkLabel1.LinkVisited = true;
                System.Diagnostics.Process.Start(GameName1);
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(GameName2);
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(GameName1);
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void Label7_Click(object sender, EventArgs e)
        {
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabel2.LinkVisited = true;
                System.Diagnostics.Process.Start(GameName2);
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabel3.LinkVisited = true;
                System.Diagnostics.Process.Start(GameName3);
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabel4.LinkVisited = true;
                System.Diagnostics.Process.Start(GameName4);
            }
            catch(InvalidOperationException)
            {          
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(GameName3);
            }
            catch(InvalidOperationException)
            {
            }       
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(GameName4);
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
