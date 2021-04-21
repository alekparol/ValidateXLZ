using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ValidateXLZ.Exceptions
{
    public static class FileExceptions
    {
        public static void IsFilePathEmpty(string filePath)
        {
            if (filePath.Length == 0)
            {
                throw new Exception(String.Format("Provided file path is empty."));
            }
        }

        public static void IsFilePathAccessible(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception(String.Format("{0} file does not exists or access is denied.", filePath));
            }
        }

    }
}
