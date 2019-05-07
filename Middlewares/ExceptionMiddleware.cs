using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Accounts.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            if (exception is ValidationException)
            {
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            }

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }));
        }
    }

    internal class ErrorDetails
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}