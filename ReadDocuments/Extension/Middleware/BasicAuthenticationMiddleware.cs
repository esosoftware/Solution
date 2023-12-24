using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Esoft.Documents.DocumentsWebApi.Extension.Middleware
{


    public class BasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Basic "))
            {
                string base64Credentials = authHeader.Substring("Basic ".Length).Trim();
                string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64Credentials));
                string[] parts = credentials.Split(':', 2);

                string username = parts[0];
                string password = parts.Length > 1 ? parts[1] : string.Empty;

                if (IsAuthenticated(username, password))
                {
                    await _next.Invoke(context);
                    return;
                }
            }

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"My Application\"";
        }

        private bool IsAuthenticated(string username, string password)
        {
            // Umieść logikę weryfikacji autentykacji
            return username == "vs" && password == "rekrutacja";
        }
    }

    public static class BasicAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}