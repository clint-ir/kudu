﻿using System;

namespace Kudu.Core.Deployment
{
    public static class LoggerExtensions
    {
        public static ILogger Log(this ILogger logger, string value, params object[] args)
        {
            return logger.Log(String.Format(value, args), LogEntryType.Message);
        }

        public static ILogger Log(this ILogger logger, Exception exception)
        {
            var returnLog = logger.Log(exception.Message, LogEntryType.Error);
#if DEBUG
            logger.Log(exception.StackTrace, LogEntryType.Error);
#endif
            return returnLog;
        }
    }
}
