﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace JudoPayDotNet.Http
{
    using System.Reflection;

    /// <summary>
    /// The JudoPay API supports multiple api versions, this handler adds the "API-Version" header to requests
    /// </summary>
    internal class VersioningHandler : DelegatingHandler
    {
        public const string API_VERSION_HEADER = "api-version";

        internal const string DEFAULT_API_VERSION = "5.5.0.0";

        private readonly string _apiVersionValue;

        public VersioningHandler(string apiVersionValue)
        {
            _apiVersionValue = apiVersionValue;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add(API_VERSION_HEADER, _apiVersionValue);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
