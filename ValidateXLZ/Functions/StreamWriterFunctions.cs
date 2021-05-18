using System.IO;
using System.IO.Compression;
using System.Xml;

namespace ValidateXLZ.Functions
{
    public static class StreamWriterFunctions
    {
        /* Write */
        
        public static void Write(string path, string updatedContent)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(updatedContent);
            }
        }

        public static void Write(ZipArchiveEntry zipArchiveEntry, string updatedContent)
        {
            using (StreamWriter writer = new StreamWriter(zipArchiveEntry.Open()))
            {
                writer.Write(updatedContent);
            }
        }

        /* Read */

        public static string Read(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static string Read(ZipArchiveEntry zipArchiveEntry)
        {
            using (StreamReader streamReader = new StreamReader(zipArchiveEntry.Open()))
            {
                return streamReader.ReadToEnd();
            }
        }

    }
}
