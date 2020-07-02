using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiXml.Persistence.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace apiXml
{
    public class Program
    {
        /*Foi necessário alterar o método Main para garantir que nosso banco de dados seja "criado" quando o aplicativo for iniciado, 
         * já que estamos usando um provedor de memória. Sem essa alteração, os usuarios que forem incluido não serão criados.*/
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                context.Database.EnsureCreated();
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
              WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
              .Build();
    }
}
