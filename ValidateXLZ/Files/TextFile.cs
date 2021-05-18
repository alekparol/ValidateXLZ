using System.IO;
using System.IO.Compression;
using System.Xml;

using static ValidateXLZ.Functions.XmlFunctions;
using static ValidateXLZ.Functions.StreamWriterFunctions;

namespace ValidateXLZ.Files
{
    public class TextFile
    {
        /* Fields */

        private string _path, _content;

        /* Properties */

        public string Path
        {
            get
            {
                return _path;
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }
        }

        /* Methods */

        public void Save(string path, string updatedContent)
        {
            Write(path, updatedContent);
        }

        public void Save(string path, XmlDocument updatedContent)
        {
            Write(path, SaveXmlDocument(updatedContent));
        }

        public void Save(ZipArchiveEntry zipArchiveEntry, string updatedContent)
        {
            Write(zipArchiveEntry, updatedContent);
        }

        /* Constructors */

        public TextFile()
        {

        }

        public TextFile(string path)
        {
            _path = path;
            _content = Read(path);
        }

        public TextFile(ZipArchiveEntry zipArchiveEntry)
        {
            _content = Read(zipArchiveEntry);
        }
    }
}
