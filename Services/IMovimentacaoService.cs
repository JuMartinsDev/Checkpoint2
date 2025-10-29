using System.Threading.Tasks;
using Nac2Estoque.Models;

namespace Nac2Estoque.Services
{
    public interface IMovimentacaoService
    {
        Task RegistrarMovimentacaoAsync(MovimentacaoEstoque movimentacao);
    }
}
