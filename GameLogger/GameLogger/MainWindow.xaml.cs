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
using Microsoft.CSharp.RuntimeBinder;
using System.Collections.ObjectModel;
using System.ComponentModel;
using GiantBomb.Api;
using System.Text.RegularExpressions;
using GiantBomb.Api.Model;
using System.Net;
using System.Net.Http.Headers;

namespace GameLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<ImageSource> gameImg = new ObservableCollection<ImageSource>();
        public ObservableCollection<string> GameList { get; set; }
        public string APIURL = "?api_key=23896f4f00ce753ef98a3c79c42c3d4e226dded0";



        public MainWindow()
        {
            InitializeComponent();
            GameList = new ObservableCollection<string>();
            

            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");
            System.IO.Directory.CreateDirectory(complete);
            
            if (!(File.Exists(filepath)))
            {
                File.Create(filepath).Close();
                File.AppendAllText(filepath, String.Format("<GameList>" + Environment.NewLine + "</GameList>"));

            }
            /*DataGridTextColumn imagecol = new DataGridTextColumn();
            imagecol.Header = "Image";
            imagecol.Binding = new System.Windows.Data.Binding("ImageOfGame");

            gameListView.Columns.Add(imagecol);

            DataGridTextColumn text = new DataGridTextColumn();
            text.Header = "Game Name";
            text.Binding = new System.Windows.Data.Binding("GameName");
            gameListView.Columns.Add(text);*/




            LoadFile(filepath);
        }

        public void AddToFile(string text)
        {
            var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var result = client.SearchForGames(text).ToList();
            
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "Game", null);
            var Game = client.GetGame(result.First().Id);

            XmlNode GameName = doc.CreateElement("Game_Name");
            XmlNode Description = doc.CreateElement("Description");
            XmlNode ReleaseDate = doc.CreateElement("Release_Date");
            XmlNode Platforms = doc.CreateElement("Platforms");
            XmlNode Genre = doc.CreateElement("Genres");
            XmlNode Publishers = doc.CreateElement("Publishers");
            XmlNode Developers = doc.CreateElement("Developers");
            

            GameName.InnerText = Game.Name.ToString();
            Description.InnerText = Game.Deck.ToString();
            ReleaseDate.InnerText = Game.OriginalReleaseDate.ToString();
            Genre.InnerText = GetGenre(Game.Genres.ToList());
            Platforms.InnerText = GetPlatforms(Game.Platforms.ToList());
            Publishers.InnerText = GetPublishers(Game.Publishers.ToList());
            Developers.InnerText = GetDevelopers(Game.Developers.ToList());


            node.AppendChild(GameName);
            node.AppendChild(Description);
            node.AppendChild(Genre);
            node.AppendChild(Platforms);
            node.AppendChild(ReleaseDate);
            node.AppendChild(Publishers);
            node.AppendChild(Developers);
            DownloadImages(Game, doc, node);

            doc.DocumentElement.AppendChild(node);
            doc.Save(filepath);
        }

        private void DownloadImages(Game game,XmlDocument doc,XmlNode node)
        {
            string url = game.Image.IconUrl.ToString().Trim();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, game.Id + ".png");

            WebClient client = new WebClient();
            client.Headers["User-Agent"] = "josedpar";
            client.DownloadFile(new Uri(url), filepath);
            
            XmlNode ImgPath = doc.CreateElement("ImagePath");
            ImgPath.InnerText = filepath;
            node.AppendChild(ImgPath);


        }

        public string GetGenre(List<Genre> list)
        {
            string y = "";
            foreach (var x in list)
            {
                if (y == "")
                {
                    y += x.Name;
                }
                else
                {
                    y += ", " + x.Name;
                }
            }
            return y; 
        }

        public string GetPlatforms(List<Platform> list)
        {
            string y = "";
            foreach (var x in list)
            {
                if (y == "")
                {
                    y += x.Name;
                }
                else
                {
                    y += ", " + x.Name;
                }
            }
            return y;
        }

        public string GetPublishers(List<Publisher> list)
        {
            string y = "";
            foreach (var x in list)
            {
                if (y == "")
                {
                    y += x.Name;
                }
                else
                {
                    y += ", " + x.Name;
                }
            }
            return y;
        }

        public string GetDevelopers(List<Developer> list)
        {
            string y = "";
            foreach (var x in list)
            {
                if (y == "")
                {
                    y += x.Name;
                }
                else
                {
                    y += ", " + x.Name;
                }
            }
            return y;
        }


        public void LoadFile(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList xnList = doc.SelectNodes("/GameList/Game");

            foreach (XmlNode xn in xnList)
            {
                string gameName = xn["Game_Name"].InnerText;
                GameList.Add(gameName);
                //gameImg.Add(new BitmapImage(new Uri(@"C:\Users\Dillon\Source\Repos\CapstoneProject\GameLogger\GameLogger\Properties\placeholder.png")));
                gameListImg.ItemsSource = GameList;
                //gameListImg.ItemsSource = gameImg;


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
                DataGridTextColumn textColumn = new DataGridTextColumn();
                textColumn.Header = gameName;
                textColumn.Binding = new System.Windows.Data.Binding(gameName);
                gameListView.Items.Add(new GameData() {GameName = gameName});*/

            }
            
          
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
    }
}
