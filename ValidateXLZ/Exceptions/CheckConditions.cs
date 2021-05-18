using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using ValidateXLZ.Utilities;

using static ValidateXLZ.Utilities.LogHandler;

namespace ValidateXLZ.Exceptions
{
    public static class CheckConditions
    {

        public static void DoesExists(string path)
        {
            if (!File.Exists(path))
            {
                Logger.LogIn(string.Format("[ERROR] zip archive file {0} is not accessible!", path));
            }
        }

        public static void IsZipArchiveEmpty(ZipArchive zipArchive)
        {
            if (zipArchive.Entries.Count == 0)
            {
                Logger.LogIn(string.Format("[WARNING] zip archive file {0} contains no entries. ", path));
            }
        }

    }
}
