using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;

namespace ValidateXLZ.Functions
{
    public static class Utils
    {

        public static List<T> ConvertToList<T>(IReadOnlyCollection<T> collection)
        {
            List<T> converted = new List<T>();
            foreach(T collectionItem in collection)
            {
                converted.Add(collectionItem);
            }
            return converted;
        }
        

    }
}
