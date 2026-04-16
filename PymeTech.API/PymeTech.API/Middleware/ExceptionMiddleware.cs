using PymeTech.API.Common;
using PymeTech.Application.Common.Exceptions;
using FluentValidation;                      
using System.Net;
using System.Text.Json;

namespace PymeTech.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ManejarExcepcionAsync(context, ex);
            }
        }

        private async Task ManejarExcepcionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            ApiResponse<object> response;

            switch (ex)
            {
                case ValidationException validationEx:
                    // errores de validación — 400
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = ApiResponse<object>.Fail(
                        "Errores de validación",
                        validationEx.Errors.Select(e => e.ErrorMessage).ToList()
                    );
                    break;

                // no encontrado — 404
                case NotFoundException notFoundEx:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response = ApiResponse<object>.Fail(notFoundEx.Message);
                    break;

                //exepcion de autorizacion — 401
                case UnauthorizedException unauthorizedEx:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response = ApiResponse<object>.Fail(unauthorizedEx.Message);
                    break;
                // cualquier otro error — 500
                default:
                    _logger.LogError(ex, "Error no controlado");
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = ApiResponse<object>.Fail("Ocurrió un error interno");
                    break;
            }

            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }
    }
}