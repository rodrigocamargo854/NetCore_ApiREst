using Api.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Api.Domain.Security;
using Microsoft.Extensions.Options;

namespace application
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


            //? injeção de dependencia do repository e do user service

            ConfigureService.ConfigureDependencyService(services);
            ConfigureRepository.ConfigureDependencyRepository(services);
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfiguratios();
            new ConfigureFromConfigurationOptions<TokenConfiguratios>(
                Configuration.GetSection("TokenConfigurations"))
                     .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);





            services.AddControllers();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api",
                    Version = "v1",
                    Description = "Api para treino",
                    TermsOfService = new Uri("http://www.google.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Rodrigo Camargo",
                        Email = "rodrigocamarg@gmail.com",
                        Url = new Uri("http://www.google.com.br"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termos de Licensa de uso",
                        Url = new Uri("http://www.google.com.br")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api teste");
                c.RoutePrefix = string.Empty;
            });



            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
