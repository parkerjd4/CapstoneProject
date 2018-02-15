using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace GameLogger
{
    class GameData 
    {
        
        public BitmapSource Picture { get; set; }
        public string Name { get; set; }

    }
    class RootObject
    {
        public List<string> Response { get; set; }
    }
}
