using System.Collections.Generic;
using System.Xml;

using static ValidateXLZ.Functions.XmlFunctions;

namespace ValidateXLZ.XLZ
{
    public class Xlf
    {
        /* Fields */

        protected XmlDocument xlfDocument;

        /* Properties */

        public List<XmlNode> TransUnitNodes
        {
            get
            {
                XmlNodeList transUnitNodeList = xlfDocument.SelectNodes("//trans-unit");
                return ConvertXmlNodeList(transUnitNodeList);
            }
        }

        /* Methods */

        /* Constructors */

        public Xlf()
        {

        }

        public Xlf(XmlDocument xlfDocument)
        {
            this.xlfDocument = xlfDocument;
        }
    }
}
