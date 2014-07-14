using log4net;
using log4net.Config;
using Obfuscar;

namespace DevelopmentTools
{
    [Obfuscate]
    class LogForNetExample
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog logger =
          LogManager.GetLogger(typeof(LogForNetExample));

        /// <summary>
        /// Test log4net
        /// </summary>
        /// <param name="args">starting parameters</param>
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();

            logger.Debug("Here is a debug log.");
            logger.Info("... and an Info log.");
            logger.Warn("... and a warning.");
            logger.Error("... and an error.");
            logger.Fatal("... and a fatal error.");
        }
    }
}
