using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ValidateXLZ.XLZ;

using static ValidateXLZ.Functions.MessageFunctions;

namespace ValidateXLZ.Functions
{
    public static class ValidationFunctions
    {

        /// <summary>
        /// Validate non-null and translatable trans unit node. 
        /// </summary>
        /// <param name="transUnit"> represents <code>TransUnit</code> object.</param>
        /// <param name="listString"> represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static void ValidateTranslatableTransUnit(TransUnit transUnit, List<string> listString)
        {
            if (!transUnit.IsNull)
            {
                if (transUnit.IsTranslatable == 1)
                {
                    IsTranslatableTransUnitValid(transUnit, listString);
                }
            }
        }

        /// <summary>
        /// Validate non-null and untranslatable trans unit node. 
        /// </summary>
        /// <param name="transUnit"> represents <code>TransUnit</code> object.</param>
        /// <param name="listString"> represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static void ValidateUntranslatableTransUnit(TransUnit transUnit, List<string> listString)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validate list of translatable <code>TransUnit</code> objects.
        /// </summary>
        /// <param name="transUnitList"> represents <code>List</code> of <code>XmlNode</code> objects.</param>
        /// <param name="listString"> represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static void ValidateTransUnitList(List<XmlNode> transUnitList, List<string> listString)
        {
            TransUnit transUnit = new TransUnit();

            foreach (XmlNode transUnitNode in transUnitList)
            {
                transUnit = new TransUnit(transUnitNode);
                ValidateTranslatableTransUnit(transUnit, listString);
            }
        }

        /// <summary>
        /// Validate xliff file. 
        /// </summary>
        /// <param name="xlfFile"> represents <code>Xlf</code> object.</param>
        /// <param name="listString"> represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static void ValidateXlfFile(Xlf xlfFile, List<string> listString)
        {
            ValidateTransUnitList(xlfFile.TransUnitNodes, listString);
        }

        /// <summary>
        /// Validate xlz file. 
        /// </summary>
        /// <param name="xlzFile"> represents <code>Xlz</code> object.</param>
        /// <param name="listString"> represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static void ValidateXlzFile(Xlz xlzFile, List<string> listString)
        {
            Xlf xlfFile = new Xlf(xlzFile.ContentXlf);
            ValidateXlfFile(xlfFile, listString);
        }

        /// <summary>
        /// Validate an xlz file under the passed file path. 
        /// </summary>
        /// <param name="xlzFilePath"> represents xlz file path.</param>
        /// <param name="listString"> represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static void ValidateXlz(string xlzFilePath, List<string> listString)
        {
            Xlz xlzFile = new Xlz(xlzFilePath);
            ValidateXlzFile(xlzFile, listString);
        }
    }
}
