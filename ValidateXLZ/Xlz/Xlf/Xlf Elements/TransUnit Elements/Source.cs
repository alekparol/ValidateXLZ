using System.Collections.Generic;
using System.Xml;

using static ValidateXLZ.Functions.TextFunctions;

namespace ValidateXLZ.XLZ
{
    public class Source
    {
        /* Fields */

        protected XmlNode sourceNode;

        /* Properties */

        public bool IsNull
        {
            get
            {
                if (sourceNode == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int IsEmpty
        {
            get
            {
                if (IsNull)
                {
                    return -1;
                }
                else
                {
                    if (sourceNode.InnerXml == string.Empty)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public string Value
        {
            get
            {
                if (IsNull)
                {
                    return "null";
                }
                else
                {
                    return sourceNode.InnerXml;
                }
            }
        }

        public List<string> InnerTags
        {
            get
            {
                return TagList(sourceNode.InnerXml);
            }
        }

        public List<string> InnerText
        {
            get
            {
                return TextList(sourceNode.InnerXml);
            }
        }

        /* Methods */

        /* Constructors */

        public Source()
        {

        }

        public Source(XmlNode targetNode)
        {
            this.sourceNode = targetNode;
        }
    }
}
