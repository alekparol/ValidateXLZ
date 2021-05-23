using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;

using static ValidateXLZ.Functions.XmlFunctions;
using static ValidateXLZ.LogHandler;

namespace ValidateXLZ.Files
{
    public class ZipArchiveEntryFile
    {

        #region Fields

        private ZipArchiveEntry _zipArchiveEntry;

        #endregion

        #region Properties
        /// <summary>
        /// Returns a <code>ZipArchiveEntry</code> object.
        /// </summary>
        public ZipArchiveEntry GetZipArchiveEntry
        {
            get
            {
                return _zipArchiveEntry;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Opens a stream on the given zip archive entry and returns whole file's content as a string value.
        /// </summary>
        /// <param name="zipArchiveEntry"> represents a <code>ZipArchiveEntry</code> object one's want to to open.</param>
        /// <returns>A string value with the file's content.</returns>
        public string LoadEntry()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(_zipArchiveEntry.Open()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch(Exception exception)
            {
                Logger.LogIn(string.Format("[ERROR] an attempt to open a zip archive entry {0} resulted in a following exceptions being thrown: \n {1}", _zipArchiveEntry.Name, exception.ToString()));
                return string.Empty;
            }
            
        }

        /// <summary>
        /// Opens a stream on the given zip archive entry and updates its content with a passed string value.
        /// </summary>
        /// <param name="updatedContent"> represents a string value that will be used to update a zip archive entry.</param>
        public bool UpdateEntry(string updatedContent)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_zipArchiveEntry.Open()))
                {
                    writer.Write(updatedContent);
                    return true;
                }
            }
            catch(Exception exception)
            {
                Logger.LogIn(string.Format("[ERROR] an attempt to open a zip archive entry {0} resulted in a following exceptions being thrown: \n {1}", _zipArchiveEntry.Name, exception.ToString()));
                return false;
            }
        }

        /// <summary>
        /// Deletes a zip archive entry.
        /// </summary>
        public void DeleteEntry()
        {
            _zipArchiveEntry.Delete();
        }

        #endregion

        #region Constructors 

        /// <summary>
        /// An empty constructor.
        /// </summary>
        public ZipArchiveEntryFile()
        {

        }

        /// <summary>
        /// A constructor for nonempty zip archive entry object. Passed zip archive entry value is stored.
        /// </summary>
        /// <param name="zipArchiveEntry"> represents a passed <code>ZipArchiveEntry</code> object.</param>
        public ZipArchiveEntryFile(ZipArchiveEntry zipArchiveEntry)
        {   
            _zipArchiveEntry = zipArchiveEntry;
        }

        #endregion
    }
}
