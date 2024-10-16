using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaGamerM.Models
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public object Result { get; set; } // Use 'object' since it is null in the current response
        public string DisplayMessage { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
