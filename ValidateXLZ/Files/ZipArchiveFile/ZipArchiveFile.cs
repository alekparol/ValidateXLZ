using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using ValidateXLZ.Utilities;

using static ValidateXLZ.Utilities.LogHandler;
using static ValidateXLZ.Exceptions.CheckConditions;
using static ValidateXLZ.Functions.FileFunctions;
using static ValidateXLZ.Functions.XmlFunctions;
using static ValidateXLZ.Functions.Utils;

using static ValidateXLZ.Functions.ZipArchiveFunctions;

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
        public string Path
        {
            get
            {
                return _path;
            }
        }

        /// <summary>
        /// Returns a list of <code>ZipArchiveEntry</code> objects of the zip file.
        /// </summary>
        public List<ZipArchiveEntry> Entries
        {
            get
            {
                return _entries;
            }
        }

        /// <summary>
        /// Returns a list of <code>ZipArchiveEntry</code> objects names.  
        /// </summary>
        public List<string> EntriesNames
        {
            get
            {
                return _entries.ConvertAll(x => x.Name);
            }
        }

        #endregion

        #region Methods

        #region Find Methods

        #region Hidden Methods

        /// <summary>
        /// A method that searches through <code>IReadOnlyCollection</code> for the element that matches the passed string.
        /// </summary>
        /// <param name="zipArchiveEntryList"> represents a passed zip archive entries list.</param>
        /// <param name="zipArchiveEntryName"> represents a passed name for which the funcion searches.</param>
        /// <returns>Entry that matches the passed zip archive entry's name.</returns>
        private ZipArchiveEntry FirstByName(List<ZipArchiveEntry> zipArchiveEntryList, string zipArchiveEntryName)
        {
            return zipArchiveEntryList.FirstOrDefault(x => x.Name.ToLower().Contains(zipArchiveEntryName));
        }

        /// <summary>
        /// A method that searches through <code>IReadOnlyCollection</code> for the element that matches the passed string.
        /// </summary>
        /// <param name="zipArchiveEntryCollection"> represents a passed zip archive entries collection.</param>
        /// <param name="zipArchiveEntryName"> represents a passed name for which the funcion searches.</param>
        /// <returns>Entry that matches the passed zip archive entry's name.</returns>
        private ZipArchiveEntry FirstByName(IReadOnlyCollection<ZipArchiveEntry> zipArchiveEntryCollection, string zipArchiveEntryName)
        {
            return FirstByName(ConvertToList<ZipArchiveEntry>(zipArchiveEntryCollection), zipArchiveEntryName);
        }

        /// <summary>
        /// A method that uses <code>FirstByName</code> method but also adds a log entry.
        /// </summary>
        /// <param name="zipArchiveEntryList"> represents a passed zip archive entries list.</param>
        /// <param name="zipArchiveEntryName"> represents a passed name for which the funcion searches.</param>
        /// <returns>Entry that matches the passed zip archive entry's name.</returns>
        private ZipArchiveEntry FindFirstByName(List<ZipArchiveEntry> zipArchiveEntryList, string zipArchiveEntryName)
        {
            ZipArchiveEntry foundEntry = FirstByName(zipArchiveEntryList, zipArchiveEntryName);
            DoesListContain<ZipArchiveEntry>(foundEntry);
            return foundEntry;
        }

        /// <summary>
        /// A method that uses <code>FirstByName</code> method but also adds a log entry.
        /// </summary>
        /// <param name="zipArchiveEntryCollection">represents a passed zip archive entries collection.</param>
        /// <param name="zipArchiveEntryName"> represents a passed name for which the funcion searches.</param>
        /// <returns>Entry that matches the passed zip archive entry's name.</returns>
        private ZipArchiveEntry FindFirstByName(IReadOnlyCollection<ZipArchiveEntry> zipArchiveEntryCollection, string zipArchiveEntryName)
        {
            ZipArchiveEntry foundEntry = FirstByName(zipArchiveEntryCollection, zipArchiveEntryName);
            DoesListContain<ZipArchiveEntry>(foundEntry);
            return foundEntry;
        }

        #endregion

        #region Used Methods

        /// <summary>
        /// A method that saerches through object's entries list for the element that matches the passed string.
        /// </summary>
        /// <param name="zipArchiveEntryName"> represents a passed name for which the funcion searches.</param>
        /// <returns>Entry that matches the passed zip archive entry's name.</returns>
        private ZipArchiveEntry FirstByName(string zipArchiveEntryName)
        {
            return FirstByName(_entries, zipArchiveEntryName);
        }

        /// <summary>
        /// A method that searches through object's entires list for the element that matches the passed string and adds a log entry. 
        /// </summary>
        /// <param name="zipArchiveEntryName"></param>
        /// <returns></returns>
        private ZipArchiveEntry FindFirstByName(string zipArchiveEntryName)
        {
            return FindFirstByName(_entries, zipArchiveEntryName);
        }

        #endregion

        #endregion

        #region Open Methods

        public string SOpen(string zipEntryName)
        {
            DoesListContain(_entries, zipEntryName);

            using (ZipArchive zipArchive = ZipFile.OpenRead(_path))
            {
                ZipArchiveEntry zipArchiveEntry = FindZipEntryByName(zipArchive, zipEntryName);
                return LoadFileContent(zipArchiveEntry);
            }
        }

        public XmlDocument XOpen(string zipEntryName)
        {
            return LoadXmlDocument(SOpen(zipEntryName));
        }

        #endregion

        #region Update Methods

        public void SUpdate(string path, string zipEntryName, string updatedContent)
        {

            DoesListContain(_entries, zipEntryName);

            using (ZipArchive zipArchive = ZipFile.Open(path, ZipArchiveMode.Update))
            {
                ZipArchiveEntry zipArchiveEntry = FindZipEntryByName(zipArchive, zipEntryName);
                SaveZipArchiveEntry(zipArchiveEntry, updatedContent);
            }
        }

        public void XUpdate(string path, string zipEntryName, XmlDocument updatedContent)
        {

            DoesListContain(_entries, zipEntryName);

            using (ZipArchive zipArchive = ZipFile.Open(path, ZipArchiveMode.Update))
            {
                ZipArchiveEntry zipArchiveEntry = FindZipEntryByName(zipArchive, zipEntryName);
                SaveZipArchiveEntry(zipArchiveEntry, updatedContent);
            }
        }

        #endregion

        #region Save Methods

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// An empty constructor. 
        /// </summary>
        public ZipArchiveFile()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public ZipArchiveFile(string path)
        {
            _path = path;
            DoesExists(_path);
            using (ZipArchive zipArchive = ZipFile.OpenRead(_path))
            {
                IsZipArchiveEmpty(zipArchive);
                _entries = ConvertToList<ZipArchiveEntry>(zipArchive.Entries);
            }
        }

        #endregion
    }
}
