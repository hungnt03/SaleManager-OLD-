using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SaleManager.WebApi.Infrastructures
{
    public class NoContentResult : IHttpActionResult
    {
        private readonly HttpStatusCode code;
        private readonly string reason;

        public NoContentResult(HttpStatusCode code, string reason)
        {
            this.code = code;
            this.reason = reason;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(code)
            {
                ReasonPhrase = reason,
                Content = new StringContent(reason),
            };

            return Task.FromResult(response);
        }

        public static IHttpActionResult NotFound(string reason)
        {
            return new NoContentResult(HttpStatusCode.NotFound, reason);
        }

        public static IHttpActionResult Conflict(string reason)
        {
            return new NoContentResult(HttpStatusCode.Conflict, reason);
        }

        public static IHttpActionResult Unauthorized(string reason)
        {
            return new NoContentResult(HttpStatusCode.Unauthorized, reason);
        }
    }
}