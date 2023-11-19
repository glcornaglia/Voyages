using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Voyages.GraphQL.API
{
    public class Logging
    {
        private readonly ILogger logger;

        public Logging(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context, Func<Task> next)
        {
            this.logger.LogInformation("Start");
            await next();
            this.logger.LogInformation("End");
        }
    }
}