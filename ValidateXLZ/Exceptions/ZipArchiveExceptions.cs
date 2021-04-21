using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace ValidateXLZ.Exceptions
{
    public static class ZipArchiveExceptions
    {

        public static void IsZipArchiveEntryNull(string zipFilePath, string zipArchiveEntryName, ZipArchiveEntry zipArchiveEntry)
        {
            if (zipArchiveEntry == null)
            {
                throw new Exception(String.Format("Please check your Zip file: {0}, file of the name: {1} is missing.", zipFilePath, zipArchiveEntryName));
            }
        }

    }
}
