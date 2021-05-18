using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml;

using static ValidateXLZ.Functions.FileFunctions;
using static ValidateXLZ.Functions.XmlFunctions;
using static ValidateXLZ.Functions.ZipArchiveFunctions;

using static ValidateXLZ.Exceptions.FileExceptions;

namespace ValidateXLZ.XLZ
{
    public class Xlz
    {

        /* Fields */

        protected string xlzFilePath;

        protected XmlDocument xlfDocument;
        protected XmlDocument sklDocument;

        /* Properties */

        /// <summary>
        /// Gets and sets <code>XmlDocument</code> representing loaded content.xlf file with whitespace preservation. 
        /// </summary>
        public XmlDocument ContentXlf
        {
            get
            {
                return xlfDocument;
            }
            set
            {
                xlfDocument = value;
            }
        }

        /// <summary>
        /// Gets and sets <code>XmlDocument</code> representing loaded skeleton.skl file with whitespace preservation. 
        /// </summary>
        public XmlDocument SkeletonSkl
        {
            get
            {
                return sklDocument;
            }
            set
            {
                sklDocument = value;
            }
        }


        /* Methods */

        /// <summary>
        /// Opens Xlz file as a zip archive in a update mode and overwrites content.xlf and skeleton.skl with actual values of the class fields.
        /// </summary>
        /// <param name="newXlzFilePath"> represents a path to the copied .zip file. </param>
        public void SaveXlz(string newXlzFilePath)
        {
            File.Copy(xlzFilePath, newXlzFilePath);

            UpdateZipByFileName(xlzFilePath, "content.xlf", xlfDocument);
            UpdateZipByFileName(xlzFilePath, "skeleton.skl", sklDocument);

        }

        /// <summary>
        /// Opens Xlz file as a zip archive in a update mode and overwrites content.xlf and skeleton.skl with actual values of the class fields.
        /// </summary>
        public void SaveXlz()
        {
            SaveXlz(xlzFilePath);
        }

        /* Constructors */

        /// <summary>
        /// Creates an empty <code>Xlz</code> object.
        /// </summary>
        public Xlz()
        {

        }

        /// <summary>
        /// Creates an <code>Xlz</code> object with <code>xlzFilePath</code> as passed. Then xlz file is opened as a zip archive and content.xlf and skeleton.skl are saved to corresponding string fields. 
        /// <code>XmlDocuemnt</code> objects are initialized basing on those string values.
        /// </summary>
        /// <param name="xlzFilePath"> represents xlz file path as a string value. </param>
        public Xlz(string xlzFilePath)
        {
            this.xlzFilePath = xlzFilePath;

            IsFilePathValid(xlzFilePath);

            xlfDocument = OpenZipByFileName(xlzFilePath, "content.xlf");
            sklDocument = OpenZipByFileName(xlzFilePath, "skeleton.skl");
        }
    }
}
