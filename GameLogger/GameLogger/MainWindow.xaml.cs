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
using System.Drawing;
using System.IO;
using System.Xml;
using System.Windows.Forms;

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
            gameListView.AutoGenerateColumns = true;
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

            DataGridTextColumn imagecol = new DataGridTextColumn();
            imagecol.Header = "Image";
            imagecol.Binding = new System.Windows.Data.Binding("ImageOfGame");
            gameListView.Columns.Add(imagecol);

            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "Game Name" ;
            textColumn1.Binding = new System.Windows.Data.Binding("GameName");
            gameListView.Columns.Add(textColumn1);
            foreach (XmlNode xn in xnList)
            {
                string gameName = xn["Game_Name"].InnerText;
                /*TextAndImageColumn colName = new TextAndImageColumn();
                dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
                colName.DefaultCellStyle = dataGridViewCellStyle1;
                colName.FillWeight = 10F;
                colName.HeaderText = gameName ;
                colName.Image = System.Drawing.Image.FromFile("C:\\Users\\Dillon\\Source\\Repos\\CapstoneProject\\GameLogger\\GameLogger\\Properties\\placeholder.png");
                colName.Name = "test";
                colName.ReadOnly = true;
                colName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                colName.Width = 60;
                */
                

                DataGridTextColumn textColumn = new DataGridTextColumn();
                textColumn.Header = gameName;
                textColumn.Binding = new System.Windows.Data.Binding(gameName);
                System.Drawing.Image t = System.Drawing.Image.FromFile("C:\\Users\\Dillon\\Source\\Repos\\CapstoneProject\\GameLogger\\GameLogger\\Properties\\placeholder.png");
                gameListView.Items.Add(new GameData() {image = t, GameName = gameName});




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
