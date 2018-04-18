using GiantBomb.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;

namespace GameLogger
{
    public partial class Form2 : Form
    {

        public string[] imglist;
        public int count = 0;
        public string Status;
        public string SetNewStatus; 
        public string GameName
        {
            get => this.Name;
            set
            {
                this.Name = value;
            }
        }
        public Form2()
        {
            InitializeComponent();
            BringToFront();
        }
        public void Form2_Load(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MainWindow window = new MainWindow();
            window.gameListImg.SelectedItems.Clear();
            Close();
        }
        public void SetStatus(string stat)
        {
            SetNewStatus = stat;
        }

        public System.Drawing.Point LocLabel5()
        {
            System.Drawing.Point loc = new System.Drawing.Point(label5.Location.X, label5.Location.Y);
            return loc;
        }
        public System.Drawing.Point LocLabel6()
        {
            System.Drawing.Point loc = new System.Drawing.Point(label6.Location.X, label6.Location.Y);
            return loc;
        }
        public System.Drawing.Point LocLabel7()
        {
            System.Drawing.Point loc = new System.Drawing.Point(label7.Location.X, label7.Location.Y);
            return loc;
        }
        public System.Drawing.Point LocLabel8()
        {
            System.Drawing.Point loc = new System.Drawing.Point(label8.Location.X, label8.Location.Y);
            return loc;
        }

        public void SetLocLabel5(int x, int y)
        {
            label5.Location = new System.Drawing.Point(x, y);
        }
        public void SetLocLabel6(int x, int y)
        {         
            label6.Location = new System.Drawing.Point(x, y);     
        }
        public void SetLocLabel7(int x, int y)
        {
            label7.Location = new System.Drawing.Point(x, y);
        }
        public void SetLocLabel8(int x, int y)
        {
            label8.Location = new System.Drawing.Point(x, y);
        }

        public void SetLabel1(string label)
        {
            label1.Text += label;
            GameName = label;
        }
        public void SetLabel2(string label)
        {
            label2.Text += label;
        }
        public void SetLabel3(string label)
        {
            label3.Text += label;
        }
        public void SetLabel4(string label)
        {
            label4.Text += label;
        }
        public void SetLabel5(string label)
        {
            label5.Text += label;
        }
        public void SetLabel6(string label)
        {
            label6.Text += label;
        }
        public void SetLabel7(string label)
        {
            label7.Text += label;
        }
        public void SetLabel8(string label)
        {
            label8.Text += label;
            Status = label;
        }
       
        public void SetImgList(string[] imgs)
        {
            imglist = imgs;
        }
        public void SetPicBox(string[] file)
        {         
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(file[0]);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile(file[0]);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Image.FromFile(file[1]);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = Image.FromFile(file[2]);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.Image = Image.FromFile(file[3]);
            count++;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            ImageLarger imageLarger = new ImageLarger();
            Image image = pictureBox1.Image;
            var len = image.Size;           
            imageLarger.CreatePictureBox(len, image);
            imageLarger.Show();
            TopMost = false;
            imageLarger.TopMost = true;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(imglist[0]);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(imglist[1]);
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(imglist[2]);
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(imglist[3]);
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            EditForm Edit = new EditForm();
            Edit.Show();
            Edit.TopMost = true;
            Edit.SetGameName(label1.Text.Substring(label1.Text.Length-GameName.Length));

            Edit.Name = "Change Status";
            Edit.SetLabel1("Please change the status of " + label1.Text.Substring(label1.Text.Length - GameName.Length) +".");
            string[] list = new string[5];
            string name = "Set Status";
            list[0] = "Playing";
            list[1] = "Plan to Play";
            list[2] = "Completed";
            list[3] = "On Hold";
            list[4] = "Dropped";
            if((label1.Text.Substring(label1.Text.Length - GameName.Length)).Length >= 20)
            {
                System.Drawing.Size Small = new System.Drawing.Size(Edit.Width+50, Edit.Height);
                Edit.Size = Small; 
                if((label1.Text.Substring(label1.Text.Length - GameName.Length)).Length >= 30)
                {
                    System.Drawing.Size Larger = new System.Drawing.Size(Edit.Width + 45, Edit.Height);
                    Edit.Size = Larger;
                }
            }                                    
            Edit.SetComboBox1(name, list);
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {           
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            var Game = label1.Text.Substring(6, label1.Text.Length - 6);

            XmlNodeList xnList = doc.SelectNodes("/GameList/Game");
            XmlNode xmlNode = doc.SelectSingleNode("/GameList");
            Form2 form2 = new Form2();

            foreach (XmlNode x in xnList)
            {
                if (x["Game_Name"].InnerText.Equals(Game))
                {
                    String Status = x["Status"].InnerText;
                    label8.Text = label8.Text.Substring(0,8);
                    label8.Text += Status;
                    break;
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var Client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var Result = Client.SearchForGames((label1.Text.Substring(6, label1.Text.Length - 6))).ToList();
            var Game = Client.GetGame(Result.First().Id);

            RecommendGames recommendGames = new RecommendGames();
            TopMost = false;
            recommendGames.Show();
            recommendGames.TopLevel = true;
            recommendGames.SetTableContents(Game.SimilarGames);
        }
    }
}
