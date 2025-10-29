using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nac2Estoque.Data;
using Nac2Estoque.Models;

namespace Nac2Estoque.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly AppDbContext _context;

        public MovimentacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MovimentacaoEstoque movimentacao)
        {
            _context.Movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MovimentacaoEstoque>> GetAllAsync()
        {
            return await _context.Movimentacoes.Include(m => m.Produto).ToListAsync();
        }
    }
}
