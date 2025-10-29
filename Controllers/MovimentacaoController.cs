using Microsoft.AspNetCore.Mvc;
using Nac2Estoque.Models;
using Nac2Estoque.Services;
using Nac2Estoque.Exceptions;

namespace Nac2Estoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacaoController(IMovimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] MovimentacaoEstoque movimentacao)
        {
            try
            {
                await _movimentacaoService.RegistrarMovimentacaoAsync(movimentacao);
                return Ok(movimentacao);
            }
            catch (ValidacaoException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (EstoqueInsuficienteException ex)
            {
                return Conflict(new { erro = ex.Message });
            }
            catch (RegraDeNegocioException ex)
            {
                return Conflict(new { erro = ex.Message });
            }
        }
    }
}
