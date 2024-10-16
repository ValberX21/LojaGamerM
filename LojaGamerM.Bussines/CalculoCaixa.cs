using LojaGamerM.Models;
using LojaGamerM.Models.Dtos;

namespace LojaGamerM.Bussines
{
    public class CalculoCaixa
    {
        public static List<Caixa> modelosCaixa = new List<Caixa>
            {
                new Caixa { caixa_id = "Caixa 1", altura = 30, largura = 40, comprimento = 80 },
                new Caixa { caixa_id = "Caixa 2", altura = 80, largura = 50, comprimento = 40 },
                new Caixa { caixa_id = "Caixa 3", altura = 50, largura = 80, comprimento = 60 }
            };

        public static Dictionary<string, double> volumeCaixas()
        {
            Dictionary<string, double> volumeCaixas = new Dictionary<string, double>();

            foreach (var item in modelosCaixa)
            {
                double volumeCaixa = item.largura * item.comprimento * item.altura;

                volumeCaixas.Add(item.caixa_id, volumeCaixa);
            }

            return volumeCaixas;
        }

        public static CaixaDto caixaProduto(int volumeProduto)
        {
            Dictionary<string, double> caixas = volumeCaixas();
            CaixaDto caixaDto = new CaixaDto();

            foreach (var caixa in caixas)
            {
                if (caixa.Value >= volumeProduto)
                {
                    caixaDto.CaixaId = caixa.Key;
                    break;
                }
            }

            if (caixaDto.CaixaId == null)
            {

            }
            return caixaDto;
        }
    }
}
