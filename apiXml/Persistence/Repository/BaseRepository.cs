using apiXml.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiXml.Persistence.Repository
{
    public class BaseRepository
    {

        /*Essa classe é uma classe abstrata que todos os nossos repositórios herdarão. Uma classe abstrata é uma classe que não tem instância direta.
         É preciso criar classes diretas para criar instâncias.
         A Classe BaseRepository recebe uma instância do nosso AppDbContext através da injeção de dependência e expõe uma propriedade protegida(uma propriedade 
         que só pode ser acessada pelas classes filhas) chamada de _context, que dá acesso a todos os métodos que precisamos para manipular as operações de banco de dados
         Agora é preciso adicionar uma nova classe na mesma pasta chamada de UsuarioRepository. Onde toda lógica vai ser implementada*/
        protected readonly AppDbContext _context;
     
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
