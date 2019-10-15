using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace FoodLovers.Infrastructure
{
    [GeneratedCode("NSwag", "12.0.14.0 (NJsonSchema v9.13.18.0 (Newtonsoft.Json v9.0.0.0))")]
    public class SwaggerException : Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public Dictionary<string, IEnumerable<string>> Headers { get; private set; }

        public SwaggerException(
            string message,
            int statusCode,
            string response,
            Dictionary<string, IEnumerable<string>> headers,
            Exception innerException)
            : base(message + "\n\nStatus: " + (object)statusCode + "\nResponse: \n" + response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
        {
            this.StatusCode = statusCode;
            this.Response = response;
            this.Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", (object)this.Response, (object)base.ToString());
        }
    }
}
