using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApiTemplate.Repositories;
using WebApiTemplate.Repositories.Abstract;
using Newtonsoft.Json.Serialization;
using WebApiTemplate.Middleware;
using WebApiTemplate.Middleware.Abstract;
using WebApiTemplate.Services.Apptokens;
using WebApiTemplate.Services.AuthConsumer;
using WebApiTemplate.Services.Database.Settings;
using WebApiTemplate.Services.Database;

namespace WebApiTemplate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Di User Secret WebApiTemplate:ConnectionString Into Db ConnectionString
            DatabaseConnection _database = Configuration.GetSection("WebApiTemplate").Get<DatabaseConnection>();
            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(_database.ConnectionString));

            // Di appcode
            RequestValidation appcode = Configuration.GetSection("WebApiTemplate").Get<RequestValidation>();
            services.AddSingleton<IRequestValidation>(appcode);

            // Di app tokens
            AuthorizationTokens tokens = Configuration.GetSection("WebApiTemplate").Get<AuthorizationTokens>();
            services.AddSingleton<IAuthorizationTokens>(tokens);
            AuthConsumers.Consumers.Add(AuthConsumers.Consumer.Developer, tokens.DeveloperToken);

            // Di JSON Serializer
            services.AddControllers().AddNewtonsoftJson(s =>
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            // Di automapper for DTO
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Di repositories
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiTemplate", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiTemplate v1"));
            }

            // Custom middleware
            app.UseMiddleware<ExceptionHandler>();
            app.UseMiddleware<SecurityHeaders>();
            app.UseMiddleware<Authentication>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
