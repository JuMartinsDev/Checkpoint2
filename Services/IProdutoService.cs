using System.Collections.Generic;
using System.Threading.Tasks;
using Nac2Estoque.Models;

namespace Nac2Estoque.Services
{
    public interface IProdutoService
    {
        Task<Produto> CadastrarProdutoAsync(Produto produto);
        Task<List<Produto>> ObterProdutosAbaixoDoMinimoAsync();
        Task<List<Produto>> ObterProdutosVencendoEm7DiasAsync();
    }
}
