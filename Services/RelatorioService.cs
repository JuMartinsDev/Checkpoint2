using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nac2Estoque.Models;
using Nac2Estoque.Repositories;

namespace Nac2Estoque.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IProdutoRepository _produtoRepository;

        public RelatorioService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<decimal> CalcularValorTotalEstoqueAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return produtos.Sum(p => p.PrecoUnitario * p.QuantidadeAtual);
        }

        public async Task<List<Produto>> ListarProdutosAbaixoDoMinimoAsync()
        {
            return await _produtoRepository.GetAbaixoDoMinimoAsync();
        }

        public async Task<List<Produto>> ListarProdutosVencendoEm7DiasAsync()
        {
            return await _produtoRepository.GetVencendoEmBreveAsync();
        }
    }
}
