using Application.Common.Models;
using Domain.Exceptions;
using MediatR;
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
    public class ExceptionMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var req = typeof(TRequest).Name;

                var response = new ResponseObjectJson();

                switch (ex)
                {
                    case BadRequestException:
                        response.Code = (int)HttpStatusCode.BadRequest;
                        response.Message = ex.Message;
                        break;
                    case NotFoundException:
                        response.Code = (int)HttpStatusCode.NotFound;
                        response.Message = ex.Message;
                        break;
                    case ForbiddenException:
                        response.Code = (int)HttpStatusCode.Forbidden;
                        response.Message = ex.Message;
                        break;
                    case UnauthorizedException:
                        response.Code = (int)HttpStatusCode.Unauthorized;
                        response.Message = ex.Message;
                        break;
                    case ValidationException vex:
                        if (vex.Errors.ContainsKey("configuration"))
                        {
                            List<string> values = vex.Errors["configuration"].ToList();
                        }
                        response.Code = (int)HttpStatusCode.BadRequest;
                        response.Message = "ERROR";
                        response.Message = vex.Message;
                        break;
                    default:
                        response.Code = (int)HttpStatusCode.InternalServerError;
                        response.Message = ex.Message;
                        break;
                }
                return (TResponse)Convert.ChangeType(response, typeof(TResponse));
            }
        }
    }
}
//vivie en el pipeline de HTTP , cuando se ejecuta el servidor el http desde que llega al servidor hasta que devuelve la respuesta 
//sirve para logica transversal a toda la api 
//ejemplos parecidos a este 
//Authenticacion/authorizacion
//loggin de request/response
//manejo global de exceptiones(la configuracion de este archivo)
//CORS , Comprension , Routing
