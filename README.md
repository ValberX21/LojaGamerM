# API de Embalagem de Pedidos

## Visão Geral

A API de Embalagem de Pedidos é um serviço web baseado em .NET 7, projetado para processar uma lista de pedidos e determinar a melhor forma de embalar produtos em tamanhos de caixas pré-definidos com base em suas dimensões. Esta API é estruturada em uma arquitetura em camadas, promovendo manutenibilidade e escalabilidade.

## Recursos

- **Processamento de Pedidos**: Aceita uma lista de pedidos, cada um contendo produtos com dimensões específicas.
- **Lógica de Embalagem**: Implementa lógica para selecionar as melhores opções de embalagem com base nas dimensões da caixa e do produto.
- **Arquitetura em Camadas**: Organizada em três camadas:
  - **API**: Expondo endpoints para receber e processar pedidos.
  - **Lógica de Negócio**: Contém os algoritmos de embalagem principais e regras de negócio.
  - **Modelos**: Define as estruturas de dados para pedidos, produtos e caixas.
- **Testes Automatizados**: Inclui um conjunto de testes automatizados para garantir a confiabilidade e correção da aplicação.
- **Suporte a Docker**: Totalmente containerizada, permitindo fácil implantação e escalabilidade.

## Tecnologias Utilizadas

- **.NET 7**: O framework para construção da API.
- **C#**: A linguagem de programação utilizada em todo o projeto.
- **Docker**: Containerização para fácil implantação e gerenciamento.

## Começando

### Pré-requisitos

- [SDK do .NET 7](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Docker](https://www.docker.com/get-started)

### Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/LojaGamerM/order-packing-api.git
   cd order-packing-api
2. Construa a imagem Docker:
    docker build -t order-packing-api .

3. Execute o contêiner Docker:

4. Uso
Uma vez que a API esteja em execução, você pode enviar uma requisição POST para o endpoint /api/orders com um payload JSON contendo a lista de pedidos a serem processados.

{
  "orders": [
    {
      "orderId": 1,
      "products": [
        {
          "productId": 101,
          "dimensions": {
            "length": 10,
            "width": 5,
            "height": 4
          },
          "quantity": 2
        }
      ]
    }
  ]
}

5. Executando Testes
Para executar os testes automatizados, certifique-se de estar no diretório do projeto e execute:
dotnet test

    
