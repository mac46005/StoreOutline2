using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOutline2
{
    public class LoggingHelper<T> : ILoggingHelper<T>
    {
        private readonly string _address;
        private readonly ILogger<T> _logger;
        public string CurrentAddress { get; set; }

        /// <summary>
        /// Creates a Logger Helper class. Must have an address and a logger instance
        /// </summary>
        /// <param name="address">Enter a valid address to log. e.g. Admin/ManageProducts/ </param>
        /// <param name="logger">The logger instance being used.</param>
        public LoggingHelper(string address, ILogger<T> logger)
        {
            _address = address;
            _logger = logger;
        }
        private StringBuilder message = new StringBuilder();

        public void Address()
        {
            _logger.LogInformation("CURRENT ADDRESS: " + CurrentAddress);
        }
        public void InformationLog(params string[] messages)
        {
            Address();
            message = new StringBuilder().Append("  INFO LIST:" + Environment.NewLine);
            for (int i = 0; i < messages.Length; i++)
            {
                message.Append($"{i}. {messages[i]}");
            }
            _logger.LogInformation(message.ToString());
        }
        public void ErrorList(params string[] listMessages) 
        {
            Address();
            message = new StringBuilder().Append("   ERROR LIST:" + Environment.NewLine);
            foreach (var m in listMessages)
            {
                message.Append(m + Environment.NewLine);
            }

            _logger.LogError(message.ToString());

        }
    }
}
