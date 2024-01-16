using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;

namespace WriteErrorLog.Service
{
    public class ErrorLogService
    {
        private readonly IConfiguration _configuration;
        public ErrorLogService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Method to write error log to file with timestamp and message in a thread-safe manner
        public bool WriteErrorLog(string LogMessage)
        {
            bool Status = false;
            string LogDirectory = _configuration["ErrorLog:ErrorLogFilePath"];
            DateTime CurrentDateTime = DateTime.UtcNow;

            CheckCreateLogDirectory(LogDirectory);
            string logLine = BuildLogLine(CurrentDateTime, LogMessage);
            LogDirectory = (LogDirectory + LogFileName(DateTime.UtcNow) + ".txt");

            lock (typeof(ErrorLogService))
            {
                StreamWriter oStreamWriter = null;
                try
                {
                    oStreamWriter = new StreamWriter(LogDirectory, true);
                    oStreamWriter.WriteLine(logLine);
                    Status = true;
                }
                catch (Exception ex)
                {
                    Status = false;
                }
                finally
                {
                    if (oStreamWriter != null)
                    {
                        oStreamWriter.Close();
                    }
                }
            }
            return Status;
        }

        // Create log directory if it does not exist  
        private bool CheckCreateLogDirectory(string LogPath)
        {
            bool loggingDirectoryExists = false;
            DirectoryInfo oDirectoryInfo = new DirectoryInfo(LogPath);
            if (oDirectoryInfo.Exists)
            {
                loggingDirectoryExists = true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(LogPath);
                    loggingDirectoryExists = true;
                }
                catch (Exception)
                {
                    loggingDirectoryExists = false;
                }
            }
            return loggingDirectoryExists;
        }

    // Build log line with timestamp and message 
        private string BuildLogLine(DateTime CurrentDateTime, string LogMessage)
        {
            StringBuilder loglineStringBuilder = new StringBuilder();
            loglineStringBuilder.Append(LogFileEntryDateTime(CurrentDateTime));
            loglineStringBuilder.Append(" \t");
            loglineStringBuilder.Append(LogMessage);
            return loglineStringBuilder.ToString();
        }

        public string LogFileEntryDateTime(DateTime CurrentDateTime)
        {
            return CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private string LogFileName(DateTime CurrentDateTime)
        {
            return CurrentDateTime.ToString("yyyy-MM-dd");
        }
    }
}
