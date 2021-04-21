using System.IO;
using System.IO.Compression;
using System.Xml;

using static ValidateXLZ.Functions.XmlFunctions;

namespace ValidateXLZ.Functions
{
    public static class FileFunctions
    {
        /* Load */

        /// <summary>
        /// Opens a stream on the given full file path and returns whole file's content as a string value.
        /// </summary>
        /// <param name="fullPath"> represents a full path to the file one's want to to open.</param>
        /// <returns>A string value with the file's content.</returns>
        public static string LoadFileContent(string fullPath)
        {
            using (StreamReader streamReader = new StreamReader(fullPath))
            {
                return streamReader.ReadToEnd();
            }
        }

        /// <summary>
        /// Opens a stream on the given zip archive entry and returns whole file's content as a string value.
        /// </summary>
        /// <param name="zipArchiveEntry"> represents a <code>ZipArchiveEntry</code> object one's want to to open.</param>
        /// <returns>A string value with the file's content.</returns>
        public static string LoadFileContent(ZipArchiveEntry zipArchiveEntry)
        {
            using (StreamReader streamReader = new StreamReader(zipArchiveEntry.Open()))
            {
                return streamReader.ReadToEnd();
            }
        }

        /// <summary>
        /// Opens a stream on the given zip archive entry and returns whole file's content as a <code>XmlDocument</code> object.
        /// </summary>
        /// <param name="zipArchiveEntry"> represents a <code>ZipArchiveEntry</code> object one's want to to open.</param>
        /// <returns>A XmlDocument object with the file's content.</returns>
        public static XmlDocument LoadXmlFileContent(ZipArchiveEntry zipArchiveEntry)
        {
            string fileContent = LoadFileContent(zipArchiveEntry);
            return LoadXmlDocument(fileContent);
        }

        /* Save */

        /// <summary>
        /// Opens a stream on the given full file path and saves a file with a content provided in a argument.
        /// </summary>
        /// <param name="fullPath"> represents a full path to the file one's want to to open.</param>
        /// <param name="updatedContent"> represents a file content that one's want to update the file with.</param>
        public static void SaveFileContent(string fullPath, string updatedContent)
        {
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.Write(updatedContent);
            }
        }

        /// <summary>
        /// Opens a stream on the given full file path and saves a file with a content provided in a argument.
        /// </summary>
        /// <param name="fullPath"> represents a full path to the file one's want to to open.</param>
        /// <param name="updatedContent"> represents a xml document that one's want to update the file with.</param>
        public static void SaveFileContent(string fullPath, XmlDocument updatedContent)
        {
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.Write(SaveXmlDocument(updatedContent));
            }
        }

        /// <summary>
        /// Opens a stream on the given zip archive entry and saves a file with a content provided in a argument.
        /// </summary>
        /// <param name="fullPath"> represents a full path to the file one's want to to open.</param>
        /// <param name="updatedContent"> represents a file content that one's want to update the file with.</param>
        public static void SaveZipArchiveEntry(ZipArchiveEntry zipArchiveEntry, string updatedContent)
        {
            using (StreamWriter writer = new StreamWriter(zipArchiveEntry.Open()))
            {
                writer.Write(updatedContent);
            }
        }

        /// <summary>
        /// Opens a stream on the given zip archive entry and saves a file with a content provided in a argument.
        /// </summary>
        /// <param name="fullPath"> represents a full path to the file one's want to to open.</param>
        /// <param name="updatedContent"> represents a xml document that one's want to update the file with.</param>
        public static void SaveZipArchiveEntry(ZipArchiveEntry zipArchiveEntry, XmlDocument updatedContent)
        {
            using (StreamWriter writer = new StreamWriter(zipArchiveEntry.Open()))
            {
                writer.Write(SaveXmlDocument(updatedContent));
            }
        }
    }
}
