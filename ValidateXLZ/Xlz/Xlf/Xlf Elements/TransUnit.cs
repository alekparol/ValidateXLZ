using System.Xml;

using static ValidateXLZ.Functions.XmlFunctions;

namespace ValidateXLZ.XLZ
{
    public class TransUnit
    {

        /* Fields */

        protected XmlNode transUnitNode;

        /* Properties */

        public bool IsNull
        {
            get
            {
                if (transUnitNode == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string Id
        {
            get
            {
                return transUnitNode.Attributes.GetNamedItem("id").Value;
            }
        }

        public int IsTranslatable
        {
            get
            {

                string translateValue = transUnitNode.Attributes.GetNamedItem("translate").Value;

                if (IsNull)
                {
                    return -1;
                }
                else
                {
                    if (translateValue == "yes")
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        public XmlNode Source
        {
            get
            {
                return transUnitNode.SelectSingleNode(".//source");
            }
        }

        public XmlNode Target
        {
            get
            {
                return transUnitNode.SelectSingleNode(".//target");
            }
        }

        /* Methods */

        /* Constructors */

        public TransUnit()
        {

        }

        public TransUnit(XmlNode transUnitNode)
        {
            this.transUnitNode = transUnitNode;
        }
    }
}
