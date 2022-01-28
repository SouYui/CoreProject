using System;
using System.Net;

namespace Application.ManejadorError
{
    public class ErrorHandler : Exception
    {
        public HttpStatusCode statusCode { get; set; }
        public object errores { get; set; }

        public ErrorHandler(HttpStatusCode statusCode, object errores = null) {
            this.statusCode = statusCode;
            this.errores = errores;
        }
    }
}