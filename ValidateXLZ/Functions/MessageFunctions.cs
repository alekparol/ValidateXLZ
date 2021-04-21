using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using ValidateXLZ.XLZ;

using static ValidateXLZ.Functions.ListFunctions;

namespace ValidateXLZ.Functions
{
    public static class MessageFunctions
    {
        /// <summary>
        /// Checks whether the <code>Source</code> object posses null <code>XmlNode</code>. If yes, then message is added to the validation log (list of strings). 
        /// </summary>
        /// <param name="transUnitId"> represents <code>string</code> object containing value of the xml attribute <code>id</code>.</param>
        /// <param name="source"> represents <code>Soure</code> object passed. </param>
        /// <param name="stringList">  represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        /// <returns></returns>
        public static bool IsSourceNull(string transUnitId, Source source, List<string> stringList)
        {
            if (source.IsNull)
            {
                stringList.Add(String.Format("Segment ID: {0}. Source node does not exist. ",
                                              transUnitId));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether the <code>Target</code> object posses null <code>XmlNode</code>. If yes, then message is added to the validation log (list of strings). 
        /// </summary>
        /// <param name="transUnitId"> represents <code>string</code> object containing value of the xml attribute <code>id</code>.</param>
        /// <param name="target"> represents <code>Target</code> object passed. </param>
        /// <param name="stringList">  represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static bool IsTargetNull(string transUnitId, Target target, List<string> stringList)
        {
            if (target.IsNull)
            {
                stringList.Add(String.Format("Segment ID: {0}. Target node does not exist. ",
                                              transUnitId));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether the <code>Source</code> object contains an empty <code>XmlNode</code>. If yes, then message is added to the validation log (list of strings). 
        /// </summary>
        /// <param name="transUnitId"> represents <code>string</code> object containing value of the xml attribute <code>id</code>.</param>
        /// <param name="source"> represents <code>Source</code> object passed. </param>
        /// <param name="stringList">  represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static bool IsSourceEmpty(string transUnitId, Source source, List<string> stringList)
        {
            if (source.IsEmpty == 1)
            {
                stringList.Add(String.Format("Segment ID: {0}. Source node is empty. ",
                                              transUnitId));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether the <code>Target</code> object contains an empty <code>XmlNode</code>. If yes, then message is added to the validation log (list of strings). 
        /// </summary>
        /// <param name="transUnitId"> represents <code>string</code> object containing value of the xml attribute <code>id</code>.</param>
        /// <param name="target"> represents <code>Target</code> object passed. </param>
        /// <param name="stringList">  represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static bool IsTargetEmpty(string transUnitId, Target target, List<string> stringList)
        {
            if (target.IsEmpty == 1)
            {
                stringList.Add(String.Format("Segment ID: {0}. Target node is empty. ",
                                              transUnitId));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether the <code>Target</code> object's <code>InnerText</code> property returns a list of elements the same as of <code>Source</code> objects's. If yes, then message is added to the validation log (list of strings). 
        /// </summary>
        /// <param name="transUnitId"> represents <code>string</code> object containing value of the xml attribute <code>id</code>.</param>
        /// <param name="source"> represents <code>Source</code> object passed. </param>
        /// <param name="target"> represents <code>Target</code> object passed. </param>
        /// <param name="stringList">  represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static bool IsTranslationDifferent(string transUnitId, Source source, Target target, List<string> stringList)
        {
            List<string> sameTranslation = ListIntersection(source.InnerText, target.InnerText);

            if (sameTranslation.Count == source.InnerText.Count)
            {
                stringList.Add(String.Format("Segment ID: {0}. Target node's value is the same as Source node's. ",
                                              transUnitId));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether the <code>Target</code> object's <code>InnerTags</code> property returns a list of elements the same as of <code>Source</code> objects's. If no, then message is added to the validation log (list of strings). 
        /// </summary>
        /// <param name="transUnitId"> represents <code>string</code> object containing value of the xml attribute <code>id</code>.</param>
        /// <param name="source"> represents <code>Source</code> object passed. </param>
        /// <param name="target"> represents <code>Target</code> object passed. </param>
        /// <param name="stringList">  represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static bool IsTaggingDifferent(string transUnitId, Source source, Target target, List<string> stringList)
        {
            List<string> differentTags = ListSymmetricalDifference(source.InnerText, target.InnerText);

            if (differentTags.Count > 0)
            {
                stringList.Add(String.Format("Segment ID: {0}. Target tags are different than Source tags. Different tags count: {1}.",
                              transUnitId, differentTags.Count));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether the translatable <code>TransUnit</code> object is valid according to the xliff standards. If no, then message is added to the validation log (list of strings). 
        /// </summary>
        /// <param name="transUnit"> represents <code>TransUnit</code> object.</param>
        /// <param name="stringList">  represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static void IsTranslatableTransUnitValid(TransUnit transUnit, List<string> infoList)
        {
            Source source = new Source(transUnit.Source);
            Target target = new Target(transUnit.Target);

            bool sourceNull = IsSourceNull(transUnit.Id, source, infoList);

            if (!sourceNull)
            {
                bool sourceEmpty = IsSourceEmpty(transUnit.Id, source, infoList);
                bool targetNull = IsTargetNull(transUnit.Id, target, infoList);

                if (!sourceEmpty)
                {
                    if (!targetNull)
                    {
                        bool targetEmpty = IsTargetEmpty(transUnit.Id, target, infoList);

                        if (!targetEmpty)
                        {
                            IsTranslationDifferent(transUnit.Id, source, target, infoList);
                            IsTaggingDifferent(transUnit.Id, source, target, infoList);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Throws an execption basing on the log message list. If the list is nonempty, the message is thrown joined exception.
        /// </summary>
        /// <param name="stringList">  represents <code>List</code> of <code>string</code> objects that represents a log message.</param>
        public static void ThrowExceptionsFromList(List<string> stringList)
        {
            if (stringList.Count > 0)
            {
                throw new Exception(String.Format("{0}",
                                    ListJoinWithNewline(stringList)));
            }
        }

        /// <summary>
        /// Checks whether the log message list is empty or not. If yes, it returns "false", otherwise, it returns "true".
        /// </summary>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static bool IsValid(List<string> stringList)
        {
            if (stringList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
