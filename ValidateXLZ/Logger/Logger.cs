using System;
using System.Collections.Generic;
using System.Text;

namespace ValidateXLZ
{
    public class LogHandler
    {
        private static List<string> logs = new List<string>();
        private static LogHandler _logHandlerInstance = new LogHandler();
        private LogHandler()
        {

        }

        public static LogHandler Logger
        {
            get
            {
                return _logHandlerInstance;
            }
        }

        public List<string> GetLogs
        {
            get
            {
                return logs;
            }       
        }
        public void LogIn(string message)
        {
            logs.Add(message);
        }

        public void Flush()
        {
            logs = new List<string>();
        }
    }
}
