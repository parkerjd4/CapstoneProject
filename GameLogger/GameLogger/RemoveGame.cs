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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
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
            foreach (XmlNode x in xnList)
            {
                if (x["Game_Name"].InnerText.Equals(Game.Name.ToString()))
                {
                    File.Delete(x["ImageCover"].InnerText);
                    File.Delete(x["ScreenShot_1"].InnerText);
                    File.Delete(x["ScreenShot_2"].InnerText);
                    File.Delete(x["ScreenShot_3"].InnerText);

                }
            }

            XElement objElement = XElement.Load(filepath);
            XElement delNode = objElement.Descendants("Game").Where(a => a.Element("Game_Name").Value == Game.Name.ToString()).FirstOrDefault();
            delNode.Remove();
            objElement.Save(filepath);
        }

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
