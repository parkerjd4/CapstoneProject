﻿using System;
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

            GameName1 = Game1.SiteDetailUrl.ToString();
            GameName2 = Game1.SiteDetailUrl.ToString();
            GameName3 = Game1.SiteDetailUrl.ToString();
            GameName4 = Game1.SiteDetailUrl.ToString();

            string url = Game1.Image.MediumUrl.ToString().Trim();
            string url1 = Game2.Image.MediumUrl.ToString().Trim();
            string url2 = Game3.Image.MediumUrl.ToString().Trim();
            string url3 = Game4.Image.MediumUrl.ToString().Trim();
            WebClient client = new WebClient();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, @"GameLogger\Images");
            System.IO.Directory.CreateDirectory(complete);

            var filepath = System.IO.Path.Combine(complete, Game1.Id + ".png");
            var filepath1 = System.IO.Path.Combine(complete, Game2.Id + ".png");
            var filepath2 = System.IO.Path.Combine(complete, Game3.Id + ".png");
            var filepath3 = System.IO.Path.Combine(complete, Game4.Id + ".png");

            client.Headers["User-Agent"] = "josedpar";
            client.DownloadFile(new Uri(url), filepath);
            client.Headers["User-Agent"] = "josedpar123";
            client.DownloadFile(new Uri(url1), filepath1);
            client.Headers["User-Agent"] = "josedparCAP";
            client.DownloadFile(new Uri(url2), filepath2);
            client.Headers["User-Agent"] = "josedparSTONE";
            client.DownloadFile(new Uri(url3), filepath3);

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = System.Drawing.Image.FromFile(filepath);

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = System.Drawing.Image.FromFile(filepath1);

            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = System.Drawing.Image.FromFile(filepath2);

            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = System.Drawing.Image.FromFile(filepath3);





            label4.Text = Game1.Deck.ToString(); 
            //string.Join(Environment.NewLine + "                    ", similarGames[0].Deck.ToString().Split().Select((word, index) => new { word, index }).GroupBy(y => y.index / 9).Select(grp => string.Join(" ", grp.Select(y => y.word))));
            label5.Text = Game2.Deck.ToString();
            label6.Text = Game3.Deck.ToString();
            label7.Text = Game4.Deck.ToString();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var Client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var Result = Client.SearchForGames(GameName1).ToList();
            var Game = Client.GetGame(Result.First().Id);
            linkLabel1.LinkVisited = true;

            System.Diagnostics.Process.Start(Game.SiteDetailUrl);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}