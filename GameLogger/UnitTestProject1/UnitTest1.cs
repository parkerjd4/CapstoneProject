using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLogger;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System;

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
        public void CompareXML()
        {
            Class1 test = new Class1();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var complete = System.IO.Path.Combine(systemPath, "GameLogger");
            var OGXML = System.IO.Path.Combine(complete, "OGFile.xml");
            var testXML = System.IO.Path.Combine(complete, "TestFile.xml");
            test.AddToFile("skyrim");
            test.AddToFile("persona 4 golden");

            var originalFile = GetFileHash(OGXML);
            var testFile = GetFileHash(testXML);

            Assert.AreEqual(testFile, originalFile);
        }
    }
}
