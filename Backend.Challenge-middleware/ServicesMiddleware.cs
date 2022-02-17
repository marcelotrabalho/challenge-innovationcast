using System;
using System.Collections.Generic;
using System.Text;
using Backend.Challenge_application.Application;
using Backend.Challenge_application.Interfaces;
using Backend.Challenge_repository.Model;
using Backend.Challenge_repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Challenge_ioc
{
    public class ServicesMiddleware
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure Entity Framework in Memory
            services.AddDbContext<InnovationCastContext>(
                options => options.UseInMemoryDatabase("InnovationCast")
                );
            
            // Configure the Dependency Injection
            services.AddScoped<ICommentApplication, CommentApplication>();
            services.AddTransient<ICommentRepository, CommentRepository>();
        }
    }
}
