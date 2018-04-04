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

        private void Button1_Click(object sender, EventArgs e)
        {
            MainWindow win = new MainWindow();

            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            Boolean FoundGame = false;

            try
            {
                if(comboBox1.SelectedItem != null)
                {
                    var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
                    var result = client.SearchForGames(Search).ToList();
                    int id = result.FirstOrDefault().Id;
                    var r1 = client.GetGame(id);
                    DialogResult dialogResult = MessageBox.Show("Is this the correct game, " + r1.Name.ToString() + "?", "Correct Game?", MessageBoxButtons.YesNo);

                    if(dialogResult == DialogResult.Yes)
                    {
                        XmlNodeList xnList = doc.SelectNodes("/GameList/Game");
                        XmlNode xmlNode = doc.SelectSingleNode("/GameList");
                        foreach (XmlNode x in xnList)
                        {
                            if (x["Game_Name"].InnerText.Equals(r1.Name.ToString()))
                            {
                                FoundGame = true;
                                break;
                            }
                        }
                        if (!FoundGame)
                        {
                            string cat = comboBox1.SelectedItem.ToString();
                            win.AddToFile(Search, cat);
                        }
                        else
                        {
                            MessageBox.Show("Game is already in the list.");
                        }
                    }                    
                }
                else
                {
                    MessageBox.Show("Please choose a Category.");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Not a vaild game.");
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

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
