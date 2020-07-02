using apiXml.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiXml.Domain.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ListAsync();
    }
}
