using LojaGamerM.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace LojaGamerM.Testes
{
    [TestFixture]
    public class Tests
    {
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("https://localhost:44335/api/") };
        }

        [Test]
        public async Task testApiPedidos()
        {
            var usuarioTeste = new
            {
                NOME = "SO_HOJE_PODE"
            };

            var response = await _httpClient.PostAsJsonAsync("Autenticacao/autentica", usuarioTeste);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

            Assert.IsTrue(result.IsSuccess);

            Assert.IsNotNull(result.Token);

            testeEnvioPedidos(result.Token);
        }

        public async Task testeEnvioPedidos(string token)
        {
            var pedidos = new
            {
                pedidos = new[]
                {
                    new
                    {
                        pedido_id = 1,
                        produtos = new[]
                        {
                            new
                            {
                                produto_id = "PS5",
                                dimensoes = new
                                {
                                    altura = 40,
                                    largura = 10,
                                    comprimento = 25
                                }
                            },
                            new
                            {
                                produto_id = "Volante",
                                dimensoes = new
                                {
                                    altura = 40,
                                    largura = 30,
                                    comprimento = 30
                                }
                            }
                        }
                    }
                }
            };

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync("Pedidos/listaPedidos", pedidos);

            Assert.Equals(response.StatusCode, 201);          
        }
    }
}