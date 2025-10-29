using System.Collections.Generic;
using System.Threading.Tasks;
using Nac2Estoque.Models;

namespace Nac2Estoque.Services
{
    public interface IRelatorioService
    {
        Task<decimal> CalcularValorTotalEstoqueAsync();
        Task<List<Produto>> ListarProdutosAbaixoDoMinimoAsync();
        Task<List<Produto>> ListarProdutosVencendoEm7DiasAsync();
    }
}
