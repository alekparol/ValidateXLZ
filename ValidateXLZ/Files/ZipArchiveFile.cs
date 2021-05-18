using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using ValidateXLZ.Utilities;

using static ValidateXLZ.Utilities.LogHandler;

namespace ValidateXLZ.Files
{
    public class ZipArchiveFile
    {

        /* Fields */

        private string _path;

        private List<string> _entriesNameList = new List<string>();

        /* Properties */

        /* Methods */

        /* Constructors */

        public ZipArchiveFile(string path)
        {
            _path = path;

            if (!File.Exists(path))
            {
                Logger.LogIn("dsadasd");
            }

            using (ZipArchive zipArchive = ZipFile.OpenRead(path))
            {
                foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                {
                    _entriesNameList.Add(zipArchiveEntry.Name); 
                }
            }
        }

    }
}
