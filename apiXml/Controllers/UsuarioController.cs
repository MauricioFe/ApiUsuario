using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiXml.Domain.Models;
using apiXml.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiXml.Controllers
{
    [Route("/api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        /*O construtor recebe uma intância de ICategoriaService. Isso significa que a instância pode ser qualquer coisa que inplemente a inteface de serviço
         Foi armazenado a instância em um campo privado somente leitura. O campo será usado para acessar os métodos de implementação do serviço de usuário.
         */
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        /*O tipo IEnumerable<Usuario> informa à estrutura que queremos retornar uma enumeração de usuarios, e o tipo Task, precedido pela palavra async, informa
         ao pipeline que esse método deve ser executado de forma assíncrona. FInalmente definimos um método assincrono, precisamnos usar a palavra-chave await
        para tarefas que podem demorar um pouco*/
        [HttpGet]
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var usuarios = await _usuarioService.ListAsync();
            return usuarios;
        }
    }
}
