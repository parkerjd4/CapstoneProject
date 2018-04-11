using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLogger
{
    public partial class ImageLarger : Form
    {
        public ImageLarger()
        {
            InitializeComponent();
            BringToFront();
        }

        internal void CreatePictureBox(Size len, Image img)
        {
            //Size = new System.Drawing.Size(len.Width + 100, len.Height+100);
            //pictureBox1.Size = new System.Drawing.Size(len.Width, len.Height);
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
