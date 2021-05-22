using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;

using static ValidateXLZ.Functions.FileFunctions;
using static ValidateXLZ.Functions.Utils;

namespace ValidateXLZ.Functions
{
    public static class ZipArchiveFunctions
    {
        #region Find Methods


        #endregion

        public static void UpdateZipByFileName(string zipFilePath, string zipEntryName, XmlDocument updatedEntry)
        {
            using (ZipArchive zipArchive = ZipFile.Open(zipFilePath, ZipArchiveMode.Update))
            {
                ZipArchiveEntry zipArchiveEntry = zipArchive.Entries.FirstOrDefault(x => x.Name.ToLower().Contains(zipEntryName));
                ValidateZipArchiveEntry(zipFilePath, zipEntryName, zipArchiveEntry);

                SaveZipArchiveEntry(zipArchiveEntry, updatedEntry);
            }
        }

        public static XmlDocument OpenZipByFileName(string zipFilePath, string zipEntryName)
        {
            using(ZipArchive xlzArchive = ZipFile.OpenRead(zipFilePath))
            {
                ZipArchiveEntry zipArchiveEntry = xlzArchive.Entries.FirstOrDefault(x => x.Name.ToLower().Contains(zipEntryName));
                ValidateZipArchiveEntry(zipFilePath, zipEntryName, zipArchiveEntry);

                return  LoadXmlFileContent(zipArchiveEntry);
            }
        }

        public static ZipArchiveEntry FindZipArchiveEntryByName(ZipArchive zipArchive, string zipArchiveEntry)
        {
            return zipArchive.Entries.FirstOrDefault(x => x.Name.ToLower().Contains(zipArchiveEntry));
        }

        public static void ValidateZipArchiveEntry(string zipFilePath, string zipArchiveEntryName, ZipArchiveEntry zipArchiveEntry)
        {
            if (zipArchiveEntry == null)
            {
                throw new Exception(String.Format("Please check your Zip file: {0}, file of the name: {1} is missing.", zipFilePath, zipArchiveEntryName));
            }
        }
    }
}
