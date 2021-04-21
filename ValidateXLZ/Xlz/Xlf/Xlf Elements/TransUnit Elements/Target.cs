using System.Collections.Generic;
using System.Xml;

using static ValidateXLZ.Functions.TextFunctions;

namespace ValidateXLZ.XLZ
{
    public class Target
    {

        /* Fields */

        protected XmlNode targetNode;

        /* Properties */

        public bool IsNull
        {
            get
            {
                if (targetNode == null)
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
                    if (targetNode.InnerXml == string.Empty)
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
                    return targetNode.InnerXml;
                }
            }
        }

        public List<string> InnerTags
        {
            get
            {
                return TagList(targetNode.InnerXml);
            }
        }

        public List<string> InnerText
        {
            get
            {
                return TextList(targetNode.InnerXml);
            }
        }

        /* Methods */

        /* Constructors */

        public Target()
        {

        }

        public Target(XmlNode targetNode)
        {
            this.targetNode = targetNode;
        }
    }
}
