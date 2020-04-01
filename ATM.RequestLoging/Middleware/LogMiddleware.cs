using System;
using System.Diagnostics;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ATM.RequestLog.Models;
using ATM.RequestLog.Services;
using Microsoft.AspNetCore.Http;

namespace ATM.RequestLog.Middleware
{
    /// <summary>
    /// LogMiddleware
    /// </summary>
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private LogService _logService;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, LogService logService)
        {
            try
            {
                _logService = logService;

                var request = httpContext.Request;
                //if (request.Path.StartsWithSegments(new PathString("/api")))
                //{

                var stopWatch = Stopwatch.StartNew();
                var requestTime = DateTime.UtcNow;
                var requestBodyContent = await ReadRequestBodyAsync(request);
                var originalBodyStream = httpContext.Response.Body;
                using (var responseBody = new MemoryStream())
                {
                    var response = httpContext.Response;
                    response.Body = responseBody;
                    await _next(httpContext);
                    stopWatch.Stop();

                    string responseBodyContent = null;
                    responseBodyContent = await ReadResponseBodyAsync(response);
                    await responseBody.CopyToAsync(originalBodyStream);

                    var currentUserId = 0;
                    var deviceId = request.Query["dId"];

                    try
                    {
                        var uid = httpContext.User.FindFirst(ClaimTypes.PrimarySid);

                        if (uid != null)
                            currentUserId = int.Parse(uid.Value);
                    }
                    catch { }

                    await SafeLogAsync(requestTime,
                        stopWatch.ElapsedMilliseconds,
                        response.StatusCode,
                        request.Method,
                        request.Path,
                        request.QueryString.ToString(),
                        requestBodyContent,
                        responseBodyContent,
                        currentUserId,
                        deviceId);
                }
                //}
                //else
                //{
                //    await _next(httpContext);
                //}
            }
            catch (Exception ex)
            {
                var e = ex;
                await _next(httpContext);
            }
        }

        private async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private async Task<string> ReadResponseBodyAsync(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private Task SafeLogAsync(DateTime requestTime,
                            long responseMillis,
                            int statusCode,
                            string method,
                            string path,
                            string queryString,
                            string requestBody,
                            string responseBody,
                            int userId,
                            string deviceId)
        {
            if (path.ToLower().StartsWith("/api/login"))
            {
                requestBody = "(Request logging disabled for /api/login)";
                responseBody = "(Response logging disabled for /api/login)";
            }

            return _logService.LogRequestAsync(new RequestResponseHistory
            {
                RequestTime = requestTime,
                ResponseMillis = responseMillis,
                StatusCode = statusCode,
                Method = method,
                Path = path,
                QueryString = queryString,
                RequestBody = requestBody,
                ResponseBody = responseBody,
                AuthorizedUser = userId,
                DeviceId = deviceId
            });
        }
    }
}
