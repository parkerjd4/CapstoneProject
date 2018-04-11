using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLogger;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System;
using System.Xml;
using GiantBomb.Api;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public string GetFileHash(string filename)
        {
            var hash = new SHA1Managed();
            var clearBytes = File.ReadAllBytes(filename);
            var hashedBytes = hash.ComputeHash(clearBytes);
            return ConvertBytesToHex(hashedBytes);
        }

        public string ConvertBytesToHex(byte[] bytes)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x"));
            }
            return sb.ToString();
        }

        [TestMethod]
        public void CompareXML1()
        {
            Class1 test = new Class1();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var OGXML = System.IO.Path.Combine(complete, "OGFile.xml");
            var testXML = System.IO.Path.Combine(complete, "TestFile.xml");
            System.IO.File.WriteAllText(OGXML, string.Empty);
            File.AppendAllText(OGXML, String.Format("<GameList>" + Environment.NewLine + "</GameList>"));
            test.AddToFile("skyrim", "Playing ");
            //test.AddToFile("persona 4 golden");

            var originalFile = GetFileHash(OGXML);
            var testFile = GetFileHash(testXML);

            Assert.AreEqual(testFile, originalFile);
        }

        [TestMethod]
        public void CompareXML2()
        {
            Class1 test = new Class1();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var OGXML = System.IO.Path.Combine(complete, "OGFile.xml");
            var testXML = System.IO.Path.Combine(complete, "TestFile1.xml");
            System.IO.File.WriteAllText(OGXML, string.Empty);
            File.AppendAllText(OGXML, String.Format("<GameList>" + Environment.NewLine + "</GameList>"));
            test.AddToFile("persona 4 golden", "Playing ");

            var originalFile = GetFileHash(OGXML);
            var testFile = GetFileHash(testXML);

            Assert.AreEqual(testFile, originalFile);
        }

        [TestMethod]
        public void CompareXML3()
        {
            Class1 test = new Class1();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var OGXML = System.IO.Path.Combine(complete, "OGFile.xml");
            var testXML = System.IO.Path.Combine(complete, "TestFile2.xml");
            System.IO.File.WriteAllText(OGXML, string.Empty);
            File.AppendAllText(OGXML, String.Format("<GameList>" + Environment.NewLine + "</GameList>"));
            test.AddToFile("skyrim", "Playing ");
            test.AddToFile("persona 4 golden", "Playing ");

            var originalFile = GetFileHash(OGXML);
            var testFile = GetFileHash(testXML);

            Assert.AreEqual(testFile, originalFile);
        }
        [TestMethod]
        public void TestGenre()
        {
            Class1 test = new Class1();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var testXML = System.IO.Path.Combine(complete, "TestFile.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(testXML);
            XmlNodeList xnList = doc.SelectNodes("/GameList/Game");
            var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var result = client.SearchForGames("skyrim").ToList();
            var Game = client.GetGame(result.First().Id);
            string GenreTest = test.GetGenre(Game.Genres);
            string Genre1 = "";
            foreach (XmlNode x in xnList)
            {
                 Genre1 = x["Genres"].InnerText;
            }
            Assert.AreEqual(GenreTest, Genre1);
        }

        [TestMethod]
        public void TestPlatforms()
        {
            Class1 test = new Class1();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var testXML = System.IO.Path.Combine(complete, "TestFile.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(testXML);
            XmlNodeList xnList = doc.SelectNodes("/GameList/Game");
            var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var result = client.SearchForGames("skyrim").ToList();
            var Game = client.GetGame(result.First().Id);
            string PlatformsTest = test.GetPlatforms(Game.Platforms);
            string Platforms1 = "";
            foreach (XmlNode x in xnList)
            {
                Platforms1 = x["Platforms"].InnerText;
            }
            Assert.AreEqual(PlatformsTest, Platforms1);
        }

        [TestMethod]
        public void TestPublishers()
        {
            Class1 test = new Class1();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var testXML = System.IO.Path.Combine(complete, "TestFile.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(testXML);
            XmlNodeList xnList = doc.SelectNodes("/GameList/Game");
            var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var result = client.SearchForGames("skyrim").ToList();
            var Game = client.GetGame(result.First().Id);
            string PublishersTest = test.GetPublishers(Game.Publishers);
            string Publishers1 = "";
            foreach (XmlNode x in xnList)
            {
                Publishers1 = x["Publishers"].InnerText;
            }
            Assert.AreEqual(PublishersTest, Publishers1);
        }

        [TestMethod]
        public void TestDeveloper()
        {
            Class1 test = new Class1();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var testXML = System.IO.Path.Combine(complete, "TestFile.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(testXML);
            XmlNodeList xnList = doc.SelectNodes("/GameList/Game");
            var client = new GiantBombRestClient("23896f4f00ce753ef98a3c79c42c3d4e226dded0");
            var result = client.SearchForGames("skyrim").ToList();
            var Game = client.GetGame(result.First().Id);
            string DeveloperTest = test.GetDevelopers(Game.Developers);
            string Developer1 = "";
            foreach (XmlNode x in xnList)
            {
                Developer1 = x["Developers"].InnerText;
            }
            Assert.AreEqual(DeveloperTest, Developer1);
        }
    }


}
