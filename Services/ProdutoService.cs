using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nac2Estoque.Exceptions;
using Nac2Estoque.Models;
using Nac2Estoque.Repositories;

namespace Nac2Estoque.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> CadastrarProdutoAsync(Produto produto)
        {
            if (produto.Categoria == Categoria.PERECIVEL && (produto.DataValidade == null || string.IsNullOrEmpty(produto.Lote)))
                throw new ValidacaoException("Produtos perecíveis devem ter lote e data de validade.");

            produto.DataCriacao = DateTime.Now;
            produto.QuantidadeAtual = 0;

            await _produtoRepository.AddAsync(produto);
            return produto;
        }

        public async Task<List<Produto>> ObterProdutosAbaixoDoMinimoAsync()
        {
            var produtos = await _produtoRepository.GetAbaixoDoMinimoAsync();
            return produtos;
        }

        public async Task<decimal> CalcularValorTotalEstoqueAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return produtos.Sum(p => p.PrecoUnitario * p.QuantidadeAtual);
        }

        public async Task<List<Produto>> ObterProdutosVencendoEm7DiasAsync()
        {
            var produtos = await _produtoRepository.GetVencendoEmBreveAsync();
            return produtos;
        }
    }
}
