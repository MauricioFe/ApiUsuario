using apiXml.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiXml.Repositories
{
    public interface IUsuarioRepository
    {

        Task<IEnumerable<Usuario>> ListAsync();
        Task AddAsync(Usuario usuario);
        Task<Usuario> FindByIdAsync(int id);
        void Update(Usuario usuario);
        void Remove(Usuario usuario);
    }
}
