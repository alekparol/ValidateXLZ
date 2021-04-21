using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace ValidateXLZ.Functions
{
    public static class XmlFunctions
    {

        /* Load */

        /// <summary>
        /// Parses a string with xml content to XmlDocument with special predefined settings [Preserve Whitespace: On].
        /// </summary>
        /// <param name="xmlContent"> represents a string with xml content. </param>
        /// <returns></returns>
        public static XmlDocument LoadXmlDocument(string xmlContent)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlContent);

            xmlDocument.PreserveWhitespace = true;
            return xmlDocument;
        }

        /* Save */

        /// <summary>
        /// Sames an XmlDocument object into a string with xml formatting (indent).
        /// </summary>
        /// <param name="xmlDocument"> represents XmlDocument object one wants to save as string. </param>
        /// <returns></returns>
        public static string SaveXmlDocument(XmlDocument xmlDocument)
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);

            xmlWriter.Formatting = Formatting.Indented;

            xmlDocument.WriteTo(xmlWriter);
            return stringWriter.ToString();
        }

        /* Convert */

        /// <summary>
        /// Converts XmlNodeList into generics List<XmlNode>. 
        /// </summary>
        /// <param name="xmlNodeList"> represents XmlNodeList that one wants to convert into List of objects. </param>
        /// <returns></returns>
        public static List<XmlNode> ConvertXmlNodeList(XmlNodeList xmlNodeList)
        {
            return new List<XmlNode>(xmlNodeList.Cast<XmlNode>());
        }
    }
}
