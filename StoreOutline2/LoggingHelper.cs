using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOutline2
{
    public class LoggingHelper<T> : ILoggingHelper<T>
    {
        private readonly string _address;
        private readonly ILogger<T> _logger;

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
        public void Address(string currentAddress)
        {
            _logger.LogInformation(_address + currentAddress);
        }


    }
}
