using BattleShipGameBL.Errors;
using BattleShipGameBL.Middlewares;
using System.Net;
using System.Text.Json;

namespace BattleShipGameApi.Middlewares
{

    /// <summary>
    /// This class will be used as a authentication middleware which performs the API Key authentication.
    /// </summary>
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<AuthenticationMiddleware> logger;
        private readonly IHostEnvironment env;
        private readonly string? apiKey;
        private const string apiKeyName = "X-Api-Key";

        public AuthenticationMiddleware(RequestDelegate next,
            ILogger<AuthenticationMiddleware> logger,
            IHostEnvironment env, IConfiguration configuration)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
            this.apiKey = configuration["ApiKey"];

        }

        /// <summary>
        /// Async method to verify the authentication. This will be fired when initializing the pipeline, after exception middleware, before cors.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.TryGetValue(apiKeyName, out var userApiKey);

            if (string.IsNullOrEmpty(userApiKey))
            {

                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Please provide an API Key");
                logger.Log(LogLevel.Error, "UnAuthorized, No Api Key provided");
                return;
            }
            else if (!apiKey.Equals(userApiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Incorrect Api KEY provided");
                logger.Log(LogLevel.Error, "UnAuthorized, Incorrect Api Key provided");
                return;
            }
        }

    }
}
