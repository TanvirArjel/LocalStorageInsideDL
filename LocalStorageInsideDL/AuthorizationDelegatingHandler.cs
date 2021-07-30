using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace LocalStorageInsideDL
{
    public class AuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;

        public AuthorizationDelegatingHandler(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string jwtKey = "UserJwt";

            // This line thrown exception in Blazor Server and MAUI Blazor
            // Exception is: JavaScript interop calls cannot be issued at this time. This is because the component is being statically rendered.
            // When prerendering is enabled, JavaScript interop calls can only be performed during the 
            string jwt = await _localStorage.GetItemAsync<string>(jwtKey);

            if (!string.IsNullOrWhiteSpace(jwt))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            }

            HttpResponseMessage httpResponseMessage = await base.SendAsync(request, cancellationToken);

            return httpResponseMessage;
        }
    }
}
