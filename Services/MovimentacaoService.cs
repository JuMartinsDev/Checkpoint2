using System;
using System.Threading.Tasks;
using Nac2Estoque.Exceptions;
using Nac2Estoque.Models;
using Nac2Estoque.Repositories;

namespace Nac2Estoque.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoService(IProdutoRepository produtoRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _produtoRepository = produtoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task RegistrarMovimentacaoAsync(MovimentacaoEstoque movimentacao)
        {
            if (movimentacao.Quantidade <= 0)
                throw new ValidacaoException("Quantidade deve ser positiva.");

            var produto = await _produtoRepository.GetByIdAsync(movimentacao.ProdutoId);
            if (produto == null)
                throw new RegraDeNegocioException("Produto não encontrado.");

            if (produto.Categoria == Categoria.PERECIVEL && movimentacao.DataValidade < DateTime.Today)
                throw new ValidacaoException("Não é possível movimentar produto perecível vencido.");

            if (movimentacao.Tipo == TipoMovimentacao.SAIDA && produto.QuantidadeAtual < movimentacao.Quantidade)
                throw new EstoqueInsuficienteException("Estoque insuficiente para a saída.");

            if (movimentacao.Tipo == TipoMovimentacao.ENTRADA)
                produto.QuantidadeAtual += movimentacao.Quantidade;
            else
                produto.QuantidadeAtual -= movimentacao.Quantidade;

            await _movimentacaoRepository.AddAsync(movimentacao);
            await _produtoRepository.UpdateAsync(produto);
        }
    }
}
