using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nac2Estoque.Data;
using Nac2Estoque.Models;

namespace Nac2Estoque.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id) ?? throw new KeyNotFoundException("Produto não encontrado");
        }

        public async Task<List<Produto>> GetAbaixoDoMinimoAsync()
        {
            return await _context.Produtos
                .Where(p => p.QuantidadeAtual < p.QuantidadeMinima)
                .ToListAsync();
        }

        public async Task<List<Produto>> GetVencendoEmBreveAsync()
        {
            var limite = DateTime.Today.AddDays(7);
            return await _context.Produtos
                .Include(p => p.Movimentacoes)
                .Where(p => p.Categoria == Categoria.PERECIVEL &&
                            p.Movimentacoes.Any(m => m.DataValidade <= limite && m.DataValidade >= DateTime.Today))
                .ToListAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
    