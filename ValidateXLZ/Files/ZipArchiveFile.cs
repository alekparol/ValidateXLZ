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

namespace ValidateXLZ.Files
{
    public class ZipArchiveFile
    {

        /* Fields */

        private string _path;

        private List<string> _entriesNameList = new List<string>();

        /* Properties */

        /* Methods */

        public string SOpen(string zipEntryName)
        {
            DoesListContain(_entriesNameList, zipEntryName);

            using (ZipArchive zipArchive = ZipFile.OpenRead(_path))
            {
                ZipArchiveEntry zipArchiveEntry = zipArchive.Entries.FirstOrDefault(x => x.Name.ToLower().Contains(zipEntryName));
                return LoadFileContent(zipArchiveEntry);
            }
        }

        public XmlDocument XOpen(string zipEntryName)
        {
            return LoadXmlDocument(SOpen(zipEntryName));
        }

        /* Constructors */

        public ZipArchiveFile()
        {

        }

        public ZipArchiveFile(string path)
        {
            _path = path;

            DoesExists(path);

            using (ZipArchive zipArchive = ZipFile.OpenRead(path))
            {

                IsZipArchiveEmpty(zipArchive);

                foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                {
                    _entriesNameList.Add(zipArchiveEntry.Name); 
                }
            }
        }

    }
}
