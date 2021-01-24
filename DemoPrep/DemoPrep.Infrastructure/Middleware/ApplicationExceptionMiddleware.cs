using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DemoPrep.Infrastructure.Middleware {
    public class ApplicationExceptionMiddleware {
        private readonly RequestDelegate _next;

        public ApplicationExceptionMiddleware(RequestDelegate next) {
            _next = next;
        }


        public async Task Invoke(HttpContext context) {
            try {
                await _next(context);
            } catch (Exception exception) {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex) {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            //LogError(ex.Message);

            var result = JsonConvert.SerializeObject(new { StatusCode = (int)code, ErrorMessage = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
