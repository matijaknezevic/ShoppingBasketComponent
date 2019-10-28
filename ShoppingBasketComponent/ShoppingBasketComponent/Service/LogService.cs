using System.IO;

namespace ShoppingBasketComponent.Service
{
    internal class LogService
    {
        private const string logFilename = "logfile.txt";

        /// <summary>
        /// Insert new log/message to log file
        /// <param name="message">message</param>
        internal void InsertLog(string message)
        {
            using (StreamWriter writer = File.AppendText(logFilename))
            {
                writer.WriteLine(message);
            }
        }
    }
}