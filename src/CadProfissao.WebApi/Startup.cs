using System;
using CadProfissao.Application.Interfaces;
using CadProfissao.Application.Notifications;
using CadProfissao.Infra.Data;
using CadProfissao.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CadProfissao.WebApi
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
            var assembly = AppDomain.CurrentDomain.Load("CadProfissao.Application");

            services
                .Configure<ConnectionDataBase>(Configuration)
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<ITipoProfissaoRepository, TipoProfissaoRepository>()
                .AddScoped<IProfissionalRepository, ProfissionalRepository>()
                .AddScoped<IHandleNotification, ProfissionalCommandNotification>()
                .AddMediatR(assembly);

            services.AddCors(options =>
            {
                string[] param = Configuration.GetSection("ClientUrls").Get<string[]>();

                options.AddPolicy("diretivas",
                builder => builder.WithOrigins(param)
                    .AllowAnyHeader()
                    .WithHeaders()
                    .AllowAnyMethod()
                    .WithMethods()
                );
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors("diretivas");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder => builder.WithOrigins("http://example.com"));


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
