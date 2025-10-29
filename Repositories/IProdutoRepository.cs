using System.Collections.Generic;
using System.Threading.Tasks;
using Nac2Estoque.Models;

namespace Nac2Estoque.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(int id);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task<List<Produto>> GetAbaixoDoMinimoAsync();
        Task<List<Produto>> GetVencendoEmBreveAsync();
    }
}
