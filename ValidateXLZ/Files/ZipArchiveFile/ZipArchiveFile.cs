using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml;

using static ValidateXLZ.Functions.ZipArchiveFunctions;
using static ValidateXLZ.LogHandler;
using static ValidateXLZ.Functions.XmlFunctions;
using static ValidateXLZ.Functions.Utils;
using static ValidateXLZ.Files.FileExceptionHandling;
using static ValidateXLZ.Files.ZipArchiveExceptionHandling;

namespace ValidateXLZ.Files
{
    public class ZipArchiveFile
    {

        #region Fields

        private string _path;

        private List<ZipArchiveEntry> _entries = new List<ZipArchiveEntry>();

        #endregion

        #region Properties

        /// <summary>
        /// Returns a string variable denoting path to the zip file.
        /// </summary>
        public string GetPath
        {
            get
            {
                return _path;
            }
        }

        /// <summary>
        /// Returns a list of <code>ZipArchiveEntry</code> objects of the zip file.
        /// </summary>
        public List<ZipArchiveEntry> GetEntries
        {
            get
            {
                return _entries;
            }
        }

        /// <summary>
        /// Returns a list of <code>ZipArchiveEntry</code> objects names.  
        /// </summary>
        public List<string> GetEntriesNames
        {
            get
            {
                return _entries.ConvertAll(x => x.Name);
            }
        }

        #endregion

        #region Methods

        #region Open

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="zipEntryName"></param>
        /// <returns></returns>
        private string LoadEntryAsString(string path, string zipEntryName)
        {
            if (DoesListContain(path, _entries, zipEntryName))
            {
                using (ZipArchive zipArchive = ZipFile.Open(path, ZipArchiveMode.Read))
                {
                    ZipArchiveEntryFile zipArchiveEntry = new ZipArchiveEntryFile(zipArchive.GetEntry(zipEntryName));
                    return zipArchiveEntry.LoadEntry();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipEntryName"></param>
        /// <returns></returns>
        public string LoadEntryAsString(string zipEntryName)
        {
            return LoadEntryAsString(_path, zipEntryName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="zipEntryName"></param>
        /// <returns></returns>
        public XmlDocument LoadEntryAsXml(string path, string zipEntryName)
        {
            string s_zipEntry = LoadEntryAsString(path, zipEntryName);
            return LoadXmlDocument(s_zipEntry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipEntryName"></param>
        /// <returns></returns>
        public XmlDocument LoadEntryAsXml(string zipEntryName)
        {
            return LoadEntryAsXml(_path, zipEntryName);
        }

        #endregion

        #region Update Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="zipEntryName"></param>
        /// <param name="updatedContent"></param>
        public bool UpdateEntryAsString(string path, string zipEntryName, string updatedContent)
        {
            if (DoesListContain(path, _entries, zipEntryName))
            {
                using (ZipArchive zipArchive = ZipFile.Open(path, ZipArchiveMode.Update))
                {
                    ZipArchiveEntryFile zipArchiveEntry = new ZipArchiveEntryFile(zipArchive.GetEntry(zipEntryName));
                    zipArchiveEntry.UpdateEntry(updatedContent);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipEntryName"></param>
        /// <param name="updatedContent"></param>
        public bool UpdateEntryAsString(string zipEntryName, string updatedContent)
        {
            return UpdateEntryAsString(_path, zipEntryName, updatedContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="zipEntryName"></param>
        /// <param name="updatedContent"></param>
        public bool UpdateEntryAsXml(string path, string zipEntryName, XmlDocument updatedContent)
        {
            string s_updatedContent = SaveXmlDocument(updatedContent);
            return UpdateEntryAsString(path, zipEntryName, s_updatedContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipEntryName"></param>
        /// <param name="updatedContent"></param>
        public bool UpdateEntryAsXml(string zipEntryName, XmlDocument updatedContent)
        {
            string s_updatedContent = SaveXmlDocument(updatedContent);
            return UpdateEntryAsString(zipEntryName, s_updatedContent);
        }

        #endregion

        #region Save Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="zipEntryName"></param>
        /// <param name="updatedContent"></param>
        public void SaveEntryAsString(string path, string zipEntryName, string updatedContent)
        {
            if (DoesListContain(path, _entries, zipEntryName))
            {
                using (ZipArchive zipArchive = ZipFile.Open(path, ZipArchiveMode.Create))
                {
                    ZipArchiveEntryFile zipArchiveEntry = new ZipArchiveEntryFile(zipArchive.GetEntry(zipEntryName));
                    zipArchiveEntry.UpdateEntry(updatedContent);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipEntryName"></param>
        /// <param name="updatedContent"></param>
        public void SaveEntryAsString(string zipEntryName, string updatedContent)
        {
            UpdateEntryAsString(_path, zipEntryName, updatedContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="zipEntryName"></param>
        /// <param name="updatedContent"></param>
        public void SaveEntryAsXml(string path, string zipEntryName, XmlDocument updatedContent)
        {
            string s_updatedContent = SaveXmlDocument(updatedContent);
            UpdateEntryAsString(path, zipEntryName, s_updatedContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipEntryName"></param>
        /// <param name="updatedContent"></param>
        public void SaveEntryAsXml(string zipEntryName, XmlDocument updatedContent)
        {
            string s_updatedContent = SaveXmlDocument(updatedContent);
            UpdateEntryAsString(zipEntryName, s_updatedContent);
        }

        public void FSave(string path, string zipEntryName, List<string> filePathList)
        {
            if (DoesListContain(path, _entries, zipEntryName))
            {
                using (ZipArchive zipArchive = ZipFile.Open(path, ZipArchiveMode.Create))
                {
                    foreach (string filePath in filePathList)
                    {
                        zipArchive.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
                    }
                }
            }
        }

        public void FSave(string zipEntryName, List<string> filePathList)
        {
            FSave(_path, zipEntryName, filePathList);
        }

        public void FSave(string zipEntryName, string[] filePathArray)
        {
            FSave(zipEntryName, filePathArray.ToList());
        }

        public void FSave(string zipEntryName, string directoryPath)
        {
            string[] filePathArray = Directory.GetFiles(directoryPath);
            FSave(zipEntryName, filePathArray);
        }

        public void FSave(string zipEntryName, string directoryPath, string searchedPattern)
        {
            string[] filePathArray = Directory.GetFiles(directoryPath, searchedPattern);
            FSave(zipEntryName, filePathArray);
        }

        #endregion

        public void ChangeEntryName()
        {

        }

        #endregion

        #region Constructors

        /// <summary>
        /// An empty constructor. 
        /// </summary>
        public ZipArchiveFile()
        {

        }

        /// <summary>
        /// A constructor for nonempty zip archive file object. Passed path to zip file is stored and list of zip archive entries is initalized.
        /// </summary>
        /// <param name="path"> refers to the zip archive path.</param>
        public ZipArchiveFile(string path)
        {
            if (DoesFileExists(path))
            {
                _path = path;
                try
                {
                    using (ZipArchive zipArchive = ZipFile.Open(_path, ZipArchiveMode.Read))
                    {
                        IsZipArchiveEmpty(zipArchive, _path);
                        _entries = ConvertToList(zipArchive.Entries);
                    }
                }
                catch (Exception expection)
                {
                    Logger.LogIn("Opening a zip archive file {path} resulted in a following excpetion(s): \n" + expection.ToString());
                }
            }
        }
        #endregion
    }
}
