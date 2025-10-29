using Microsoft.AspNetCore.Mvc;
using Nac2Estoque.Models;
using Nac2Estoque.Services;
using Nac2Estoque.Exceptions;

namespace Nac2Estoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] Produto produto)
        {
            try
            {
                var result = await _produtoService.CadastrarProdutoAsync(produto);
                return Ok(result);
            }
            catch (ValidacaoException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (RegraDeNegocioException ex)
            {
                return Conflict(new { erro = ex.Message });
            }
        }

        [HttpGet("estoque-minimo")]
        public async Task<IActionResult> ProdutosAbaixoDoMinimo()
        {
            var produtos = await _produtoService.ObterProdutosAbaixoDoMinimoAsync();
            return Ok(produtos);
        }

        [HttpGet("vencendo-em-7-dias")]
        public async Task<IActionResult> ProdutosVencendoEm7Dias()
        {
            var produtos = await _produtoService.ObterProdutosVencendoEm7DiasAsync();
            return Ok(produtos);
        }

        [HttpGet("valor-total-estoque")]
        public async Task<IActionResult> ValorTotalEstoque()
        {
            var valor = await _produtoService.CalcularValorTotalEstoqueAsync();
            return Ok(new { valorTotal = valor });
        }
    }
}
