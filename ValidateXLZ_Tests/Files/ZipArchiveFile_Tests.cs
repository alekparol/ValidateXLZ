using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidateXLZ.Files;
using System;
using System.Collections.Generic;
using System.Text;

using static ValidateXLZ.LogHandler;
using System.IO;

namespace ValidateXLZ.Files_Tests
{
    [TestClass()]
    public class ZipArchiveFile_Tests
    {

        [TestMethod()]
        public void ZipArchiveFile_Constructor_Test_Null()
        {
            string testZipFilePath = Directory.GetCurrentDirectory() + @"\TestFiles\nonexistentfile.zip";
            ZipArchiveFile testZipArchiveFile = new ZipArchiveFile(testZipFilePath);

            Assert.AreEqual(1, Logger.GetLogs.Count);
            Assert.AreEqual(@"[ERROR] file " + testZipFilePath + " is not accessible!", Logger.GetLogs[0]);

            Assert.IsNull(testZipArchiveFile.GetPath);
            Assert.AreEqual(0, testZipArchiveFile.GetEntries.Count);
            Assert.AreEqual(0, testZipArchiveFile.GetEntriesNames.Count);

            Logger.Flush();
        }

        [TestMethod()]
        public void ZipArchiveFile_Constructor_Test_Empty()
        {
            string testZipFilePath = Directory.GetCurrentDirectory() + @"\TestFiles\empty.zip";
            ZipArchiveFile testZipArchiveFile = new ZipArchiveFile(testZipFilePath);

            Assert.AreEqual(1, Logger.GetLogs.Count);
            Assert.AreEqual(@"[WARNING] zip archive file " + testZipFilePath + " contains no entries.", Logger.GetLogs[0]);

            Assert.AreEqual(testZipFilePath, testZipArchiveFile.GetPath);
            Assert.AreEqual(0, testZipArchiveFile.GetEntries.Count);
            Assert.AreEqual(0, testZipArchiveFile.GetEntries.Count);
            Assert.AreEqual(0, testZipArchiveFile.GetEntriesNames.Count);

            Logger.Flush();
        }

        [TestMethod()]
        public void ZipArchiveFile_Constructor_Test_NonEmpty_EmptyFile()
        {
            string testZipFilePath = Directory.GetCurrentDirectory() + @"\TestFiles\nonempty.zip";
            ZipArchiveFile testZipArchiveFile = new ZipArchiveFile(testZipFilePath);

            Assert.AreEqual(0, Logger.GetLogs.Count);

            Assert.AreEqual(testZipFilePath, testZipArchiveFile.GetPath);
            Assert.AreEqual(1, testZipArchiveFile.GetEntries.Count);
            Assert.AreEqual(1, testZipArchiveFile.GetEntriesNames.Count);
            Assert.AreEqual("emptytext.txt", testZipArchiveFile.GetEntriesNames[0]);

            Logger.Flush();
        }

        [DataTestMethod()]
        [DataRow(@"\TestFiles\nonempty.zip", "emptytext.txt", 0, null, "jaźń")]
        public void ZipArchiveFile_Methods_LoadEntryAsString_Test(string path, string fileName, int expectedLogCount, string expectedLog, string textContained)
        {
            string testZipFilePath = Directory.GetCurrentDirectory() + path;
            ZipArchiveFile testZipArchiveFile = new ZipArchiveFile(testZipFilePath);

            string fileContent = testZipArchiveFile.LoadEntryAsString(fileName);

            Assert.AreEqual(expectedLogCount, Logger.GetLogs.Count);
            if (expectedLog != null)
            {
                Assert.AreEqual(expectedLog, Logger.GetLogs[0]);
            }
            Assert.AreEqual("", fileContent);
            Assert.IsTrue(fileContent.Contains(textContained));

            Logger.Flush();
        }

        [TestMethod()]
        public void LoadEntryAsXml_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadEntryAsXml_Test1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateEntryAsString_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateEntryAsString_Test1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateEntryAsXml_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateEntryAsXml_Test1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveEntryAsString_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveEntryAsString_Test1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveEntryAsXml_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveEntryAsXml_Test1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FSave_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FSave_Test1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FSave_Test2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FSave_Test3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FSave_Test4()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ZipArchiveFile_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ZipArchiveFile_Test1()
        {
            Assert.Fail();
        }
    }
}