using apiXml.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiXml.Persistence
{
    public class AppDbContext : DbContext
    {
        /*O construtor da classe é responsável por passar a configuração do banco de dados para a classe base através 
         da injeção de dependencia. */
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        /*No código abaixo é definido quais tabelas nossos modelos devem ser mapeados. Além disso, é definido as chaves primárias, usando o método HasKey, as
         colunas da tabela, usando o método Property e algumas restrições, como IsRequired, HasMaxLength e ValueGeneratedOnAdd, tudo usando lambda*/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Usuario>().ToTable("Usuario");
            builder.Entity<Usuario>().HasKey(u => u.Id);
            builder.Entity<Usuario>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Usuario>().Property(u => u.Nome).IsRequired().HasMaxLength(30);
            builder.Entity<Usuario>().Property(u => u.Idade).IsRequired();

            builder.Entity<Usuario>().HasData(
                new Usuario { Nome = "Mauricio Lacerda", Idade = 20 },
                new Usuario { Nome = "Fernanda Leal", Idade = 19 }
                );

        }
        
    }
}
