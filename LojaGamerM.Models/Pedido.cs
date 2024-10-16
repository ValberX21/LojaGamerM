using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaGamerM.Models
{
    public class Pedido
    {
        public int pedido_id { get; set; }
        public List<Produto> produtos { get; set; }
    }
}
