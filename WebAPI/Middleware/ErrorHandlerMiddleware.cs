using System;
using System.Net;
using System.Threading.Tasks;
using Application.ManejadorError;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebAPI.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context) {
            try {
                await _next(context);
            }
            catch (Exception ex) {
                await AsyncExceptionHandler(context, ex, _logger);
            }
        }

        private async Task AsyncExceptionHandler(HttpContext context, Exception exception, ILogger<ErrorHandlerMiddleware> logger) {
            object errores = null;

            switch (exception) {
                case ErrorHandler exceptionHandler:
                    logger.LogError(exception, "Error Handler");
                    errores = exceptionHandler.errores;
                    context.Response.StatusCode = (int) exceptionHandler.statusCode;
                    break;
                case Exception ex:
                    logger.LogError(exception, "Error de servidor");
                    errores = string.IsNullOrWhiteSpace(ex.Message) ? "Error" : ex.Message;
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";

            if (errores != null) {
                var result = JsonConvert.SerializeObject(new { errores } );
                await context.Response.WriteAsync(result);
            }
        }
    }
}