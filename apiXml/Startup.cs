using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiXml.Domain.Services;
using apiXml.Persistence.Context;
using apiXml.Persistence.Repository;
using apiXml.Repositories;
using apiXml.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace apiXml
{
    public class Startup
    {
        /*� a classe reposns�vel por configurar tofos os tipos de configura��o quando o aplicativo � iniciado.*/
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            /*Foi configurado o contexto de banco de dados usando a classe AppDbContext com uma implementa��o de banco de dados na mem�ria, que � identificada
             pela string passada como argumento. Dessa forma n�o precisamos conectar a um banco de dados real para testar o aplicativo*/
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("apiXml-api-in-memory"));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
