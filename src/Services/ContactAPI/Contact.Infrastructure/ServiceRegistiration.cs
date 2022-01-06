﻿using Contact.Application.Interfaces.Common;
using Contact.Application.Interfaces.Repositories;
using Contact.Infrastructure.Persistence;
using Contact.Infrastructure.Repositories;
using Core.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Contact.Application
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var asm = Assembly.GetExecutingAssembly();

            //automapper
            services.AddAutoMapper(asm);
            //fluent validation
            services.AddValidatorsFromAssembly(asm);
            //CQRS
            services.AddMediatR(asm);
            //Posgre context
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ContactDbContext>(
                    opt => opt.UseNpgsql("User ID=posgres;Password=password;Server=localhost;Port=5432;Database=ContactDB;Integrated Security=true;Pooling=true")
                );

            //repositories
            services.AddTransient<IKisiRepository, KisiRepository>();
            services.AddTransient<IIletisimRepository, IletisimRepository>();            
        }

    }
}