using System.Collections.Generic;
using System.IO.Compression;

using static ValidateXLZ.LogHandler;

namespace ValidateXLZ.Files
{
    public static class ZipArchiveExceptionHandling
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipArchive"></param>
        /// <param name="path"></param>
        public static void IsZipArchiveEmpty(ZipArchive zipArchive, string path)
        {
            if (zipArchive.Entries.Count == 0)
            {
                Logger.LogIn(string.Format("[WARNING] zip archive file {0} contains no entries.", path));
            }
        }
    }
}
