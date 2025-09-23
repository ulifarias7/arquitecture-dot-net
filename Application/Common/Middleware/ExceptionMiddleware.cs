using Application.Common.Models;
using Domain.Exception;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Common.Middleware
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
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error capturado en el middleware: {Message}", ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var response = new ResponseObjectJson
            {
                Code = (int)HttpStatusCode.InternalServerError,
                Message = "Ha ocurrido un error inesperado.",
                Responses = null
            };

            switch (ex)
            {


                case BaseException baseEx:
                    response.Code = baseEx.StatusCode;
                    response.Message = baseEx.Message;
                    response.Responses = new { ErrorCode = baseEx.ErrorCode };
                    break;

                case FluentValidation.ValidationException fluentValidationEx:
                    response.Code = 422;
                    response.Message = "Errores de validación.";
                    response.Responses = new
                    {
                        Errors = fluentValidationEx.Errors
                            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                            .ToDictionary(g => g.Key, g => g.ToArray())
                    };
                    break;

                case UnauthorizedAccessException:
                    response.Code = 401;
                    response.Message = "No autorizado.";
                    break;

                case ArgumentException argEx:
                    response.Code = 400;
                    response.Message = argEx.Message;
                    break;

                case KeyNotFoundException:
                    response.Code = 404;
                    response.Message = "Recurso no encontrado.";
                    break;

                case TimeoutException:
                    response.Code = 408;
                    response.Message = "La operación ha expirado.";
                    break;

                default:
                    _logger.LogError(ex, "Error no controlado: {Message}", ex.Message);
                    response.Code = 500;
                    response.Message = "Ha ocurrido un error interno del servidor.";
                    break;
            }

            context.Response.StatusCode = response.Code;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var jsonResponse = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
} 
    

