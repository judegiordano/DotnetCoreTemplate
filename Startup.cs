using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApiTemplate.Database;
using WebApiTemplate.Database.Settings;
using WebApiTemplate.Repositories;
using WebApiTemplate.Repositories.Abstract;
using Newtonsoft.Json.Serialization;
using WebApiTemplate.Middleware;
using WebApiTemplate.Middleware.Abstract;

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

            // Di app tokens
            RequestValidation tokens = Configuration.GetSection("WebApiTemplate").Get<RequestValidation>();
            services.AddSingleton<IRequestValidation>(tokens);

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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Custom middleware
            app.UseMiddleware<SecurityHeaders>();
            app.UseMiddleware<Authentication>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
