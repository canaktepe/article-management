using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoreNative.ArticleManagement.Api
{
    public class ResponseMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path.ToString().ToLower().IndexOf("api") < 0)
            {
                await next.Invoke(context);
                return;
            }

            var originalBody = context.Response.Body;
            try
            {
                string responseBody = null;
                using (var ms = new MemoryStream())
                {
                    context.Response.Body = ms;
                    await next.Invoke(context);

                    ms.Position = 0;
                    responseBody = new StreamReader(ms).ReadToEnd();
                }

                var baseResponse = new BaseResponse()
                {
                    StatusCode = context.Response.StatusCode,
                    Data = JsonConvert.DeserializeObject(responseBody)
                };

                var buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(baseResponse));
                using (var output = new MemoryStream(buffer))
                {
                    await output.CopyToAsync(originalBody);
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result;
            var httpStatusCode = HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                error = exception.Message,
                stack = exception.StackTrace,
                innerException = exception.InnerException
            };

            result = JsonConvert.SerializeObject(errorResponse);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;
            return context.Response.WriteAsync(result);
        }
    }
    public static class ResponseMiddlewareExtension
    {
        public static IApplicationBuilder UseResponseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseMiddleware>();
        }
    }
}
