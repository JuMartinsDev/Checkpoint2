using System.Collections.Generic;
using System.Threading.Tasks;
using Nac2Estoque.Models;

namespace Nac2Estoque.Repositories
{
    public interface IMovimentacaoRepository
    {
        Task AddAsync(MovimentacaoEstoque movimentacao);
        Task<List<MovimentacaoEstoque>> GetAllAsync();
    }
}
