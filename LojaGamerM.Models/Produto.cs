using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaGamerM.Models
{
    public class Produto
    {
        public string produto_id { get; set; }
        public Dimensoes dimensoes { get; set; }
    }
}
