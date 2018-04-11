using GiantBomb.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GameLogger
{
    public partial class RemoveGame : Form
    {
        public RemoveGame()
        {
            InitializeComponent();
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            Button1_Click(sender, e);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
                var result = client.SearchForGames(textBox1.Text).ToList();
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var complete = System.IO.Path.Combine(systemPath, "GameLogger");
                var filepath = System.IO.Path.Combine(complete, "game_list.xml");

                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);
                var Game = client.GetGame(result.First().Id);
                XmlNodeList xnList = doc.SelectNodes("/GameList/Game");
                XmlNode xmlNode = doc.SelectSingleNode("/GameList");
                Boolean FoundGame = false;
                DialogResult dialogResult = MessageBox.Show("Is this the correct game, " + Game.Name.ToString() + "?", "Correct Game?", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    foreach (XmlNode x in xnList)
                    {
                        if (x["Game_Name"].InnerText.Equals(Game.Name.ToString()))
                        {
                            File.Delete(x["ImageCover"].InnerText);
                            File.Delete(x["ScreenShot_1"].InnerText);
                            File.Delete(x["ScreenShot_2"].InnerText);
                            File.Delete(x["ScreenShot_3"].InnerText);
                            FoundGame = true;
                            break;
                        }
                    }
                    if (FoundGame)
                    {
                        XElement objElement = XElement.Load(filepath);
                        XElement delNode = objElement.Descendants("Game").Where(a => a.Element("Game_Name").Value == Game.Name.ToString()).FirstOrDefault();
                        delNode.Remove();
                        objElement.Save(filepath);
                    }
                    else
                    {
                        MessageBox.Show("Could not find the game.");
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Not a vaild game.");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Not a vaild game.");
            }
        }

        private void Button2_Click(object sender, EventArgs e) => Close();

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
