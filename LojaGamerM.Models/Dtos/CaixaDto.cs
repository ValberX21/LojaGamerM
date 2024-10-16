using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaGamerM.Models.Dtos
{
    public class CaixaDto
    {
        public string CaixaId { get; set; }
        public List<ProdutosDto> Produtos { get; set; }
    }
}
