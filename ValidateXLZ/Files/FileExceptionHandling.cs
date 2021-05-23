using System.IO;
using static ValidateXLZ.LogHandler;

namespace ValidateXLZ.Files
{
    public static class FileExceptionHandling
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool DoesFileExists(string path)
        {
            if (!File.Exists(path))
            {
                Logger.LogIn(string.Format("[ERROR] file {0} is not accessible!", path));
                return false;
            }
            return true;
        }
    }
}
