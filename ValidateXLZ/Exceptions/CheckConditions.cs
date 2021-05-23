using System.Collections.Generic;
using System.IO.Compression;

using static ValidateXLZ.LogHandler;

namespace ValidateXLZ.Exceptions
{
    public static class CheckConditions
    {

        public static bool IsElementNull<T>(T element)
        {
            if (element.Equals(default(T)))
            {
                Logger.LogIn(string.Format("[WARNING] the list does not contain given entry: {0}. ", element.ToString()));
                return false;
            }
            return true;
        }

        public static bool DoesListContain<T>(List<T> list, T name, string entryName)
        {
            if (list.Contains(name))
            {
                Logger.LogIn(string.Format("[WARNING] the list does not contain given entry: {0}. ", entryName));
                return false;
            }
            return true;
        }

        /* USED */

        public static bool DoesListContain<T>(List<T> list, T element)
        {
            if (list.Contains(element))
            {
                Logger.LogIn(string.Format("[WARNING] the list does not contain given entry: {0}. ", element.ToString()));
                return false;
            }
            return true;
        }

    }
}
