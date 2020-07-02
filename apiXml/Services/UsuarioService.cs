using apiXml.Domain.Models;
using apiXml.Domain.Services;
using apiXml.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiXml.Services
{
    public class UsuarioService : IUsuarioService
    {
        /*O método de listagem deve aceessar o banco de dados e retornar os usuário, então é preciso retornar para o cliente. 
         Pensando em orientação a objetos Uma classe de serviço não é uma classe que deve manipular o acesso a dados. Existe um
        padrão chamado Padrão de repositório que é usado para gerenciar dados de banco de dados*/

        /*Ao usar o Padrão de Repositório, definimos classes de repositório que basicamente encapsulam toda a lógica para manipular o acesso a dados
         esses repositórios expõem métodos para listar, criar, editar e excluir objetos de um determinado modelo, da mesma forma que você pode manipular
        coleções. Internamente, esses métodos conversam com o banco de dados para executar operações CRUD, isolando o acesso ao banco de dados do restante 
        do aplicartivo*/

        /*Conceitualmente, um serviço pode "conversar com um ou mais repositórios ou outros serviços para realizar operações.*/

        /*Criação de um campo do tipo do repositório criado utilizando o padrão explicado acima*/
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _usuarioRepository.ListAsync();
        }
    }
}
