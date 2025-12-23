using FluentValidation;
using Gs_Contability.Common.Dto;
using Gs_Contability.Excepitons;
using System.Net;
using System.Text.Json;

namespace Gs_Contability.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ModelNotFoundException e)
            {
                await handleModelNotFoundExceptionAsync(context, e);
            }
            catch (GernericException e)
            {
                await handleGernericException(context, e);
            }
            catch (ValidationException e)
            {
                await handleValidationException(context, e);
            }
        }

        private Task handleValidationException(HttpContext context, ValidationException e)
        {
            var body = new ValidationErrorResponse
            {
                Status = (int)HttpStatusCode.BadRequest,
                Error = "Bad Request",
                Cause = e.GetType().Name,
                Message = "Validation Error",
                Timestamp = DateTime.Now,
                Errors = e.Errors.GroupBy(vf => vf.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(vf => vf.ErrorMessage).ToArray())
            };

            context.Response.StatusCode = body.Status;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
        }

        private Task handleGernericException(HttpContext context, GernericException e)
        {
            var body = new ErrorResponse
            {
                Status = (int)HttpStatusCode.BadRequest,
                Error = "Bad Request",
                Cause = e.GetType().Name,
                Message = e.Message,
                Timestamp = DateTime.Now
            };
            context.Response.StatusCode = body.Status;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
        }
        private Task handleModelNotFoundExceptionAsync(HttpContext context, ModelNotFoundException e)
        {
            var body = new ErrorResponse
            {
                Status = (int)HttpStatusCode.NotFound,
                Error = "Not Found",
                Cause = e.GetType().Name,
                Message = e.Message,
                Timestamp = DateTime.Now
            };
            context.Response.StatusCode = body.Status;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
        }
    }

}

