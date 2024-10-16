using LojaGamerM.Models;
using LojaGamerM.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LojaGamerM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : Controller
    {
        private readonly IConfiguration _configuration;
        protected PedidoResponseDto _responseDto;

        public AutenticacaoController(IConfiguration configuration)
        {
            _configuration = configuration;
            this._responseDto = new PedidoResponseDto();
        }

        [HttpPost("autentica")]
        public async Task<IActionResult> Post([FromBody] Usuario usu)
        {
            try
            {                
                if(usu.Nome == "SO_HOJE_PODE")
                {
                    var theToken = geraToken(usu);
                    _responseDto.Token = theToken;

                    return StatusCode(StatusCodes.Status200OK, _responseDto);

                }
                else
                {
                    _responseDto.DisplayMessage = "Usuario não encontrado";
                    _responseDto.Token = "";

                    return StatusCode(StatusCodes.Status406NotAcceptable, _responseDto);
                } 
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, _responseDto);
            }
        }

        private string geraToken(Usuario usuDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret").ToString());
            var tokenDescription = new SecurityTokenDescriptor();

            try
            {
                tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                           {
                new Claim(ClaimTypes.Name,usuDto.Nome.ToString()
                         )
                           }),
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials =
                           new SigningCredentials(
                               new SymmetricSecurityKey(key),
                               SecurityAlgorithms.HmacSha256Signature)

                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            var finalToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(finalToken);
        }
    }
}
