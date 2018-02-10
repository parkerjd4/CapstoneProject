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

namespace GameLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public MainWindow()
        {
            InitializeComponent();

            
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");
            System.IO.Directory.CreateDirectory(complete);

            if (!(File.Exists(filepath)))
            {
                File.Create(filepath).Close();
                File.AppendAllText(filepath, String.Format("<GameList>" + Environment.NewLine + "</GameList>"));

            }
            LoadFile(filepath);
        }

        internal void AddToFile(string text)
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "Game", null);
            XmlNode gameName = doc.CreateElement("Game_Name");
            gameName.InnerText = text;
            node.AppendChild(gameName);
            doc.DocumentElement.AppendChild(node);
            doc.Save(filepath);

            LoadFile(filepath);

        }

        private void LoadFile(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList xnList = doc.SelectNodes("/GameList/Game");
            foreach (XmlNode xn in xnList)
            {
             string gameName = xn["Game_Name"].InnerText;
            }
         }

        private void Menu(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Click_Add(object sender, RoutedEventArgs e)
        {
            From1 wind = new From1();
            wind.Show();

        }

        public void CheckxmlFiles()
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");



        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
