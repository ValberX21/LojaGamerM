using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaGamerM.Models.Dtos
{
    public class PedidoResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
