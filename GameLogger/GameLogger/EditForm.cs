using GiantBomb.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GameLogger
{
    public partial class EditForm : Form
    {
        string GameName;

        public EditForm()
        {
            InitializeComponent();
        }

        public void SetLabel1(string name)
        {
            label1.Text = name; 
        }
        public void SetComboBox1(string name, string[] list)
        {
            comboBox1.Text = name; 
            for(int i = 0; i < list.Length; i++)
            {
                comboBox1.Items.Add(list[i]);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        public void SetGameName(string name)
        {
            GameName = name; 
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var result = client.SearchForGames(GameName).ToList();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            var Game = client.GetGame(result.First().Id);
            XmlNodeList xnList = doc.SelectNodes("/GameList/Game");
            XmlNode xmlNode = doc.SelectSingleNode("/GameList");
            Form2 form2 = new Form2();
            foreach (XmlNode x in xnList)
            {
                if (x["Game_Name"].InnerText.Equals(Game.Name.ToString()))
                {
                    x["Status"].InnerText = comboBox1.SelectedItem.ToString();
                    form2.SetStatus(x["Status"].InnerText);
                    break;
                }
            }
            doc.Save(filepath);
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
