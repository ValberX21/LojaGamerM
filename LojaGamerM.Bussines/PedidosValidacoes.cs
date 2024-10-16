using LojaGamerM.Models;
using LojaGamerM.Models.Dtos;

namespace LojaGamerM.Bussines
{
    public class PedidosValidacoes
    {
        protected PedidoResponseDto _pedidosResponseDto;
        public PedidosValidacoes(PedidoResponseDto pedidoResponseDto)
        {
            _pedidosResponseDto = pedidoResponseDto;
        }

        public async Task<PedidoResponseDto> validaPedido(pedidos pedidos)
        {
            List<PedidoDto> pedidosList = new List<PedidoDto>();

            if (pedidos == null || pedidos.Pedidos == null || pedidos.Pedidos.Count == 0)
            {
                _pedidosResponseDto.DisplayMessage = "O campo pedidos é necessário!";
                return _pedidosResponseDto;
            }

            foreach (var pedido in pedidos.Pedidos)
            {
                int volumeTotalPedido = 0;

                for (int i = 0; i < pedido.produtos.Count; i++)
                {
                    int alt = pedido.produtos[i].dimensoes.altura;
                    int com = pedido.produtos[i].dimensoes.comprimento;
                    int larg = pedido.produtos[i].dimensoes.largura;

                    volumeTotalPedido += alt * com * larg;
                }

                CaixaDto pedidosCaixas = CalculoCaixa.caixaProduto(volumeTotalPedido);
                List<ProdutosDto> prodDto = new List<ProdutosDto>();

                if (pedidosCaixas == null)
                {
                    prodDto.AddRange(pedido.produtos.Select(prod => new ProdutosDto { produtos = prod.produto_id }));

                    pedidosList.Add(new PedidoDto
                    {
                        pedido_id = pedido.pedido_id,
                        caixas = new List<CaixaDto>
                        {
                            new CaixaDto
                            {
                                CaixaId = "Sem caixa disponivel para esse pedido",
                                Produtos = prodDto
                            }
                        }
                    });
                    continue;
                }

                foreach (var prod in pedido.produtos)
                {
                    prodDto.Add(new ProdutosDto { produtos = prod.produto_id });
                }

                CaixaDto caixaDto = new CaixaDto
                {
                    CaixaId = pedidosCaixas.CaixaId,
                    Produtos = prodDto
                };

                pedidosList.Add(new PedidoDto
                {
                    pedido_id = pedido.pedido_id,
                    caixas = new List<CaixaDto> { caixaDto }
                });
            }

            _pedidosResponseDto.Result = new { pedidos = pedidosList };
            return _pedidosResponseDto;
        }
    }
}
