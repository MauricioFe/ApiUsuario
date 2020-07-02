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
        /*Foi necess�rio alterar o m�todo Main para garantir que nosso banco de dados seja "criado" quando o aplicativo for iniciado, 
         * j� que estamos usando um provedor de mem�ria. Sem essa altera��o, os usuarios que forem incluido n�o ser�o criados.*/
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
