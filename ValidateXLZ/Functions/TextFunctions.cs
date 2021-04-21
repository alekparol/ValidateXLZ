using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ValidateXLZ.Functions
{
    public static class TextFunctions
    {

        public static Regex regexTag = new Regex("<.*?>");
        public static Regex regexText = new Regex("(<.*?>)?.*?(<.*?>)?");

        /// <summary>
        /// Searches through the passed string for tags - strings that matches <code>regexTag</code> and returns a list of strings.
        /// </summary>
        /// <param name="searchedText"> represents a string value which will be searched for tags. </param>
        /// <returns> a list of strings representing each tag.</returns>
        public static List<string> TagList(string searchedText)
        {
            MatchCollection matchedTags = regexTag.Matches(searchedText);
            return ConvertMatchesToStringList(matchedTags);
        }

        /// <summary>
        /// Searches through the passed string for text (not including tags) - strings that matches <code>regexText</code> and returns a list of strings.
        /// </summary>
        /// <param name="searchedText"> represents a string value which will be searched for texts. </param>
        /// <returns> a list of strings representing each text.</returns>
        public static List<string> TextList(string searchedText)
        {
            MatchCollection matchedTexts = regexText.Matches(searchedText);
            return ConvertMatchesToStringList(matchedTexts);
        }

        /* Convert */

        /// <summary>
        /// Converts <code>MatchCollection</code> object into the list of strings.
        /// </summary>
        /// <param name="matchesCollection"> represents any match collection passed. </param>
        /// <returns> a list of strings that represents values of matches.</returns>
        public static List<string> ConvertMatchesToStringList(MatchCollection matchesCollection)
        {
            List<string> stringMatches = new List<string>();

            foreach (Match match in matchesCollection)
            {
                stringMatches.Add(match.Value);
            }

            return stringMatches;
        }
    }
}
