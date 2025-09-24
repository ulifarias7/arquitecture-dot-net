using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Behaviors;
using FluentValidation;
using Application.Common.Middleware;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Registrar MediatR para CQRS debe ir el exception , validation y authorize
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBahevior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ExceptionMiddleware<,>));
            });

            //Registrar validators de FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //Registrar behaviors de MediatR se ejecuta despues del middleware HTTP antes de ejecutar hanlder
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // AutoMapper
            services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
    