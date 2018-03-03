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
using System.Diagnostics;

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
            XmlNode Id = doc.CreateElement("Id");
            XmlNode Description = doc.CreateElement("Description");
            XmlNode ReleaseDate = doc.CreateElement("Release_Date");
            XmlNode Platforms = doc.CreateElement("Platforms");
            XmlNode Genre = doc.CreateElement("Genres");
            XmlNode Publishers = doc.CreateElement("Publishers");
            XmlNode Developers = doc.CreateElement("Developers");

            GameName.InnerText = Game.Name.ToString();

            Id.InnerText = Game.Id.ToString();
            Description.InnerText = Game.Deck.ToString();
            ReleaseDate.InnerText = Game.OriginalReleaseDate.ToString();
            Genre.InnerText = GetGenre(Game.Genres.ToList());
            Platforms.InnerText = GetPlatforms(Game.Platforms.ToList());
            Publishers.InnerText = GetPublishers(Game.Publishers.ToList());
            Developers.InnerText = GetDevelopers(Game.Developers.ToList());


            node.AppendChild(GameName);
            node.AppendChild(Id);
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
            string url = game.Image.SuperUrl.ToString().Trim();
            string url1 = game.Images[7].SuperUrl.ToString().Trim();
            string url2 = game.Images[8].SuperUrl.ToString().Trim();
            string url3 = game.Images[9].SuperUrl.ToString().Trim();

            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, @"GameLogger\Images");
            System.IO.Directory.CreateDirectory(complete);

            var filepath = System.IO.Path.Combine(complete, game.Id + ".png");
            var filepath1 = System.IO.Path.Combine(complete, game.Id + "_1.png");
            var filepath2 = System.IO.Path.Combine(complete, game.Id + "_2.png");
            var filepath3 = System.IO.Path.Combine(complete, game.Id + "_3.png");


            WebClient client = new WebClient();

            client.Headers["User-Agent"] = "josedpar";
            client.DownloadFile(new Uri(url), filepath);

            client.Headers["User-Agent"] = "josedpar123";
            client.DownloadFile(new Uri(url1), filepath1);

            client.Headers["User-Agent"] = "josedparCAP";
            client.DownloadFile(new Uri(url2), filepath2);

            client.Headers["User-Agent"] = "josedparSTONE";
            client.DownloadFile(new Uri(url3), filepath3);


            XmlNode ImgPath = doc.CreateElement("ImageCover");
            XmlNode ImgScreen1 = doc.CreateElement("ScreenShot_1");
            XmlNode ImgScreen2 = doc.CreateElement("ScreenShot_2");
            XmlNode ImgScreen3 = doc.CreateElement("ScreenShot_3");

            ImgPath.InnerText = filepath;
            ImgScreen1.InnerText = filepath1;
            ImgScreen2.InnerText = filepath2;
            ImgScreen3.InnerText = filepath3;

            node.AppendChild(ImgPath);
            node.AppendChild(ImgScreen1);
            node.AppendChild(ImgScreen2);
            node.AppendChild(ImgScreen3);


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
            int count = 0;
            foreach (var x in list)
            {
                
                if (y == "")
                {
                    y += x.Name;
                }
                else
                {
                    if (count % 2 == 0)
                    {
                        y += Environment.NewLine + "                  " + x.Name;
                    }
                    else
                    {
                        y += ", " + x.Name;
                    }

                }
                count++;
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
            }                     
         }

        private void Menu_Click_Add(object sender, RoutedEventArgs e)
        {
            From1 wind = new From1();
            wind.Show();
        }

        private void DeleteXML()
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");
            File.Delete(filepath);


        }

        

        public void CheckxmlFiles()
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");
        }

        private void gameListImg_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Form2 View = new Form2();
            //View.Show();
            //View.TopMost = true;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "game_list.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNodeList xnList = doc.SelectNodes("/GameList/Game");

            var item = sender as System.Windows.Controls.ListViewItem;
            if (item != null && item.IsSelected)
            {
                string a = item.DataContext.ToString();
                Form2 View = new Form2();

                foreach (XmlNode x in xnList)
                {
                    if (x["Game_Name"].InnerText.Equals(a))
                    {
                        string Name = x["Game_Name"].InnerText;
                        string Description = x["Description"].InnerText;
                        string Genres = x["Genres"].InnerText;
                        string Platforms = x["Platforms"].InnerText;
                        string Release_Date = x["Release_Date"].InnerText;
                        string Publishers = x["Publishers"].InnerText;
                        string Developers = x["Developers"].InnerText;
                        string ImageCover = x["ImageCover"].InnerText;
                        string ScreenShot_1 = x["ScreenShot_1"].InnerText;
                        string ScreenShot_2 = x["ScreenShot_2"].InnerText;
                        string ScreenShot_3 = x["ScreenShot_3"].InnerText;
                        string[] img = { ImageCover, ScreenShot_1, ScreenShot_2, ScreenShot_3};
                        View.SetImgList(img);
                        View.SetPicBox(ImageCover);
                        string lines = string.Join(Environment.NewLine+"                      ", Description.Split().Select((word, index) => new { word, index }).GroupBy(y => y.index / 9).Select(grp => string.Join(" ", grp.Select(y => y.word))));
                        View.SetLabel1(Name);
                        View.SetLabel2(Release_Date);
                        View.SetLabel3(Developers);
                        View.SetLabel4(Publishers);
                        View.SetLabel5(Platforms);
                        View.SetLabel6(Genres);
                        View.SetLabel7(lines);
                    }
                        
                }
                View.Show();
                View.TopMost = true;       
            }
        }


    }
}
