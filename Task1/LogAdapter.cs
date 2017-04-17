using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Task1
{ 
    public class LogAdapter : ILogging
    {
        private readonly Logger logger;

        public LogAdapter(Logger logger)
        {

            this.logger = logger;
        }

        void ILogging.Trace(string message) => logger.Trace(message);

        void ILogging.Debug(string message) => logger.Debug(message);

        void ILogging.Info(string message) => logger.Info(message);

        void ILogging.Warn(string message) => logger.Warn(message);

        void ILogging.Error(string message) => logger.Error(message);

        void ILogging.Fatal(string message) => logger.Fatal(message);

    }
}