using GraphQL;
using GraphQL.Types;
using GraphQLSample.Api.Models;
using GraphQLSample.Api.Mutations;
using GraphQLSample.Api.Queries;
using GraphQLSample.Core;
using GraphQLSample.Core.Domains;
using GraphQLSample.Storage.SqlServer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Reflection;

namespace GraphQLSample.Api.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            ValueConverter.Register(
            typeof(double),
            typeof(Single),
            value => Convert.ToSingle(value));

            return services
            .AddSingleton<IDocumentExecuter, DocumentExecuter>()
            .AddScoped<GraphQueries>()
            .AddScoped<UserQuery>()
            .AddScoped<UserType>()
            .AddScoped<BookType>()
            .AddScoped<BookInputType>()
            .AddScoped<UserInputType>()
            .AddScoped<UserMutation>()
            .AddInfrastructureServices()
            .AddStorageServices(configuration);
        }

        private static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();

            services
                .AddMediatR(thisAssembly, typeof(User).GetTypeInfo().Assembly)
                .AddScoped<IDependencyResolver>(x =>
                            new FuncDependencyResolver(x.GetRequiredService));
            return services.AddScoped<ISchema, MySchema>();
        }

        private static IServiceCollection AddStorageServices(this IServiceCollection services,
    IConfiguration configuration)
        {
            services.AddDbContext<BoundaryDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("BoundaryDatabase"));
            });

            return services
                .AddTransient<IUnitOfWork, UnitOfWork<BoundaryDbContext>>()
                .AddTransient<IRepository, Repository<BoundaryDbContext>>()
                .AddTransient<IMigrationsRunner, MigrationsRunner<BoundaryDbContext>>();
        }

    }
}
