using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaGamerM.Models.Dtos
{
    public class PedidoDto
    {
        public int pedido_id { get; set; }
        public List<CaixaDto> caixas { get; set; }
    }
}
