using System;
using System.Collections.Generic;
using System.Text;

namespace ValidateXLZ.Functions
{
    public static class ListFunctions
    {
        /// <summary>
        /// Returns an interection of two lists of strings. 
        /// </summary>
        /// <param name="stringListOne"> represents a list of strings.</param>
        /// <param name="stringListTwo"> represents a list of strings.</param>
        /// <returns>List of strings that is an intersection of passed arguments.</returns>
        public static List<string> ListIntersection(List<string> stringListOne, List<string> stringListTwo)
        {
            List<string> operationResult = new List<string>();

            foreach (string elementOne in stringListOne)
            {
                if (stringListTwo.Contains(elementOne))
                {
                    operationResult.Add(elementOne);
                }
            }

            return operationResult;
        }

        /// <summary>
        /// Returns a relative complement of first list argument with the other.
        /// </summary>
        /// <param name="stringListOne"> represents a list of strings.</param>
        /// <param name="stringListTwo"> represents a list of strings.</param>
        /// <returns>List of strings that is a relative complement of passed arguments.</returns>
        public static List<string> ListRelativeComplement(List<string> stringListOne, List<string> stringListTwo)
        {
            List<string> relativeComplement = new List<string>();

            foreach (string elementOne in stringListOne)
            {
                if (!stringListTwo.Contains(elementOne))
                {
                    relativeComplement.Add(elementOne);
                }
            }

            return relativeComplement;
        }

        /// <summary>
        /// Returns a symmetrical difference of two lists of strings. 
        /// </summary>
        /// <param name="stringListOne"> represents a list of strings.</param>
        /// <param name="stringListTwo"> represents a list of strings.</param>
        /// <returns>List of strings that is an symmetrical difference of passed arguments.</returns>
        public static List<string> ListSymmetricalDifference(List<string> stringListOne, List<string> stringListTwo)
        {
            List<string> symmetricalDifference = ListRelativeComplement(stringListOne, stringListTwo);
            symmetricalDifference.AddRange(ListRelativeComplement(stringListTwo, stringListOne));

            return symmetricalDifference;
        }

        /// <summary>
        /// Joins a list of strings with "\n" into one string.
        /// </summary>
        /// <param name="stringList"> represents a list of strings.</param>
        /// <returns>A string containing all lists's elements joined togather.</returns>
        public static string ListJoinWithNewline(List<string> stringList)
        {
            return string.Join(",\n", stringList);
        }
    }
}
