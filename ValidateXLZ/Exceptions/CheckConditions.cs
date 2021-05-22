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
                Logger.LogIn(string.Format("[WARNING] zip archive file {0} contains no entries. "));
            }
        }

        public static bool DoesListContain<T>(T element)
        {
            if (element.Equals(default(T)))
            {
                Logger.LogIn(string.Format("[WARNING] the list does not contain given entry: {0}. ", element.ToString()));
                return false;
            }
            return true;
        }

        public static bool DoesListContain<T>(T element, string elementName)
        {
            if (element.Equals(default(T)))
            {
                Logger.LogIn(string.Format("[WARNING] the list does not contain given entry: {0}. ", elementName));
                return false;
            }
            return true;
        }

        public static bool DoesListContain<T>(List<T> list, T element)
        {
            if (list.Contains(element))
            {
                Logger.LogIn(string.Format("[WARNING] the list does not contain given entry: {0}. ", element.ToString()));
                return false;
            }
            return true;
        }

        public static bool DoesListContain<T>(List<T> list, T name, string entryName)
        {
            if (list.Contains(name))
            {
                Logger.LogIn(string.Format("[WARNING] the list does not contain given entry: {0}. ", entryName));
                return false;
            }
            return true;
        }

    }
}
