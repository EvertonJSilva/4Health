using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Logs
{
  /// <summary>
  ///   A simplistic logger.
  /// </summary>
  public static class Logger
  {
    private static int indentLevel;

    public static void Init()
    {
    // Configure NLog.
        var nlogConfig = new LoggingConfiguration();

        var fileTarget = new FileTarget("logfile")
        {
            FileName = "c:\temp\nlog.log",
            KeepFileOpen = true,
            ConcurrentWrites = false
        };

        nlogConfig.AddTarget(fileTarget);
        nlogConfig.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, fileTarget));

        //var consoleTarget = new ConsoleTarget("console");
        //nlogConfig.AddTarget(consoleTarget);
        //    nlogConfig.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));

            
            // Configure PostSharp Logging to use NLog.
            //LoggingServices.DefaultBackend = new NLogLoggingBackend(new LogFactory(nlogConfig));

            LogManager.EnableLogging();
         
        
    }
    public static void Indent()
    {
      indentLevel++;
    }

    public static void Unindent()
    {
      indentLevel--;
    }

    public static void WriteLine(string message)
    {
        var logger = NLog.LogManager.GetCurrentClassLogger();
        logger.Debug(new string(' ', 3 * indentLevel));
        logger.Debug(message);
    }
  }
}