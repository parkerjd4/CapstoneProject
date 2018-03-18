using GiantBomb.Api;
using GiantBomb.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace UnitTestProject1
{
    class Class1
    {
        public void AddToFile(string text)
        {
            var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var result = client.SearchForGames(text).ToList();

            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var filepath = System.IO.Path.Combine(complete, "OGFile.xml");
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

        private void DownloadImages(Game game, XmlDocument doc, XmlNode node)
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


    }
}
