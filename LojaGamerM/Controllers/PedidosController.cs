using LojaGamerM.Models.Dtos;
using LojaGamerM.Models;
using Microsoft.AspNetCore.Mvc;
using LojaGamerM.Bussines;
using Microsoft.AspNetCore.Authorization;

namespace LojaGamerM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly PedidosValidacoes _pedidosValidacoes;
        protected PedidoResponseDto _pedidosResponseDto;

        public PedidosController(PedidosValidacoes pedidosValidacoes, PedidoResponseDto pedidoResponseDto)
        {
            _pedidosValidacoes = pedidosValidacoes;
            _pedidosResponseDto = pedidoResponseDto;
        }

        [Authorize]
        [HttpPost("listaPedidos")]
        public async Task<IActionResult> Post([FromBody] pedidos pedidos)
        {
            try
            {
                PedidoResponseDto result = await _pedidosValidacoes.validaPedido(pedidos);

                var statusRetorned = result.GetType().GetProperty("IsSuccess")?.GetValue(result);
                bool isSuccess = statusRetorned != null && (bool)statusRetorned;

                if (isSuccess)
                {
                    return StatusCode(StatusCodes.Status201Created, result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
