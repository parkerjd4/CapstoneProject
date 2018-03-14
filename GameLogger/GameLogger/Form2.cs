using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace GameLogger
{
    public partial class Form2 : Form
    {

        public string[] imglist;
        public int count = 0; 
        public string Name1
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
        }
        public void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow window = new MainWindow();

            window.gameListImg.SelectedItems.Clear();

            
            Close();
        }

        public System.Drawing.Point LocLabel5()
        {
            System.Drawing.Point loc = new System.Drawing.Point(label5.Location.X, label5.Location.Y);
            return loc;
        }
        public System.Drawing.Point LocLabe6()
        {
            System.Drawing.Point loc = new System.Drawing.Point(label6.Location.X, label6.Location.Y);
            return loc;
        }
        public System.Drawing.Point LocLabe7()
        {
            System.Drawing.Point loc = new System.Drawing.Point(label7.Location.X, label7.Location.Y);
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

        public void SetLabel1(string label)
        {
            label1.Text += label;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(imglist[0]);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(imglist[1]);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(imglist[2]);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(imglist[3]);
        }
    }
}
