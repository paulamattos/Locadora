using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Filmes;
using Aplication.Generos;
using Aplication.Locacoes;
using Domain.Base;
using Domain.Filmes;
using Domain.Generos;
using Domain.Locacoes;
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
using Repository;
using Repository.Base;
using Repository.Filmes;
using Repository.Generos;
using Repository.Locacaos;

namespace WebApi
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
            services.AddDbContext<Contexto>(p => 
            {
                p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));                                
            });            
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAplicFilme, AplicFilme>();
            services.AddScoped<IAplicGenero, AplicGenero>();
            services.AddScoped<IAplicLocacao, AplicLocacao>();
            services.AddScoped<IRepFilme, RepFilme>();
            services.AddScoped<IRepGenero, RepGenero>();
            services.AddScoped<IRepLocacao, RepLocacao>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Contexto contexto)
        {
            if (env.IsDevelopment())
            {
                contexto.Database.EnsureCreated();            
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

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
