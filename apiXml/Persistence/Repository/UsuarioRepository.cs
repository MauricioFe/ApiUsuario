using apiXml.Domain.Models;
using apiXml.Persistence.Context;
using apiXml.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiXml.Persistence.Repository
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        /*O repositório herda da classe base BaseRepository e implmenta a interface IUsuarioRepository*/
        public UsuarioRepository(AppDbContext context) : base(context) { }
        /*Usando o DBSet de Usuarios para acessar a tabela Usuarios e, em seguida chamamos a extensão ToListAsync, que é responsável por transformar
         o resultado de consulta em uma coleção de usuarios. O EntityFramework traduz essa chamada em uma consulta SQL da maneira mais eficiente possivel.*/

        /*Foi implementado a intefce IUsuarioRepository assim todos os métodos da inteface são implementados e agora tem uma implementação limpa do controlador de
          usuarios, do serviço e do repositorio*/

        /*O ultimo passo é vincular as interfaces às respectivas classes usando o mecanismo de injeção de depedência de ASP.NET Core*/
        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }


        public void Remove(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }
    }
}
