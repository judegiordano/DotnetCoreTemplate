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
using WebApiTemplate.Services.AppInformation;

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
			// initialize swagger ui
			services.AddSwaggerGen(c => c.EnableAnnotations());

			// Di generic app info
			AppInformation appInfo = Configuration.GetSection(nameof(AppInformation)).Get<AppInformation>();
			services.AddSingleton<IAppInformation>(appInfo);
			// inject random options
			RouterAttribute.baseUrl = appInfo.BaseUrl;

			// Di User Secret WebApiTemplate:ConnectionString Into Db ConnectionString
			DatabaseConnection _database = Configuration.GetSection("WebApiTemplate").Get<DatabaseConnection>();
			services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(_database.ConnectionString));

			// Di appcode
			AppCodeValidation appcode = Configuration.GetSection("WebApiTemplate").Get<AppCodeValidation>();
			services.AddSingleton<IAppCodeValidation>(appcode);

			// Di app tokens
			AuthorizationTokens tokens = Configuration.GetSection("WebApiTemplate").Get<AuthorizationTokens>();
			services.AddSingleton<IAuthorizationTokens>(tokens);
			AuthConsumers.Consumers.Add(AuthConsumers.Consumer.Developer, tokens.DeveloperToken);
			AuthConsumers.Consumers.Add(AuthConsumers.Consumer.ExampleClientA, tokens.ExampleClientAToken);

			// Di JSON Serializer
			services.AddControllers().AddNewtonsoftJson(s =>
				s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

			// Di automapper for DTO
			// services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// Di repositories
			services.AddScoped<IUserRepository, UserRepository>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(appInfo.AppVersion, new OpenApiInfo
				{
					Version = appInfo.AppVersion,
					Title = appInfo.AppTitle,
					Description = appInfo.AppDescription,
					TermsOfService = new Uri("https://example.com/terms"),
					Contact = new OpenApiContact
					{
						Name = "Jude Giordano",
						Email = "judegiordano@gmail.com",
						Url = new Uri("https://github.com/judegiordano?tab=repositories"),
					},
					License = new OpenApiLicense
					{
						Name = "Use under LICX",
						Url = new Uri("https://example.com/license"),
					}
				}
				);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			AppInformation appInfo = Configuration.GetSection(nameof(AppInformation)).Get<AppInformation>();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint($"/swagger/{appInfo.AppVersion}/swagger.json", $"{appInfo.AppTitle} {appInfo.AppVersion}");
				c.RoutePrefix = String.Empty;
			});

			// Custom middleware
			app.UseMiddleware<ExceptionHandler>();
			app.UseMiddleware<SecurityHeaders>();
			app.UseMiddleware<Authentication>();

			app.UseHsts();

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
