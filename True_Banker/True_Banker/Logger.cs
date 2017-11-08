using System;
using System.IO;

namespace True_Banker
{

    internal enum LogExceptionType : int { Existing = 5004, Empty = 5003, Null = 5000, Locked = 5010, Bounds = 5005, Illegal = 5050 }

    /// <summary>
    /// Logger class , for logging events to record file.
    /// </summary>
    /// <seealso cref="True_Banker.ILoggable{True_Banker.Logger}" />
    class Logger : ILoggable<Logger>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger() { }
        /// <summary>
        /// Creates the log file.
        /// </summary>
        /// <param name="message">The message.</param>
        public void createLogFile(ref string message)
        {
            string filename;
            filename = "Log Files/LOG" + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Today.Year.ToString();
            filename += ".txt";
            using (StreamWriter logger = new StreamWriter(filename, true))
            {
                logger.WriteLine(message);
            }
        }
        /// <summary>
        /// Logs the acception.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogAcception(string message)
        {
            string messager = String.Format("Log Created at");
            createLogFile(ref messager);
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="logcode">The logcode.</param>
        internal void LogException(string message, LogExceptionType logcode)
        {
            string _logMessage = null;
            try
            {
                new LoggerException(message, out _logMessage, logcode);
            }
            finally
            {
                Console.WriteLine(_logMessage);
                createLogFile(ref _logMessage);
            }
        }
    }

    /// <summary>
    /// Logger exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    class LoggerException : Exception
    {
        /// <summary>
        /// The log time
        /// </summary>
        private DateTime logTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="logMessage">The log message.</param>
        /// <param name="logCode">The log code.</param>
        public LoggerException(string message, out string logMessage, LogExceptionType logCode)
            : base(message)
        {
            logTime = DateTime.Now;
            logMessage = constructMessage(message, logCode);
        }
        /// <summary>
        /// Constructs the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        private string constructMessage(string message, LogExceptionType code)
        {
            return String.Format("_LogException error thrown @ {0} < ERROR CODE #{1} > \n_Caused by {2}_. {3}.", logTime, getLogCode(code), message, base.Data);
        }

        /// <summary>
        /// Gets the log code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        private string getLogCode(LogExceptionType code)
        {
            return ((int)code).ToString();
        }
    }
}
