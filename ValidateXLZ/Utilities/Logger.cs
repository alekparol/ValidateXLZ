using System;
using System.Collections.Generic;
using System.Text;

namespace ValidateXLZ.Utilities
{
    public class LogHandler
    {

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

        public void LogIn(string message)
        {

        }

    }
}
