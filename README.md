# RealState Web API ??

Bem-vindo à RealState Web API, uma plataforma para gerenciar listagens de propriedades e apoiar corretores imobiliários! ??

## Visão Geral

A RealState Web API é um serviço RESTful construído com C# e ASP.NET Core. Ele fornece funcionalidades para gerenciar uma lista de propriedades, tornando-o um backend ideal para aplicações imobiliárias.

## Recursos

- **Listar Propriedades**: Obter uma lista de todas as propriedades disponíveis.
- **Obter Propriedade por ID**: Obter detalhes de uma propriedade específica usando seu ID.
- **Adicionar Propriedade**: Adicionar uma nova propriedade à listagem e obter seu ID atribuído.
- **Atualizar Propriedade**: Modificar informações para uma propriedade existente.
- **Remover Propriedade**: Excluir uma propriedade da listagem.

## Endpoints da API

- **GET /propriedades**: Obter todas as propriedades.
- **GET /propriedades/{id}**: Obter detalhes de uma propriedade específica por ID.
- **POST /propriedades**: Adicionar uma nova propriedade à listagem.
- **PUT /propriedades/{id}**: Atualizar informações para uma propriedade existente.
- **DELETE /propriedades/{id}**: Remover uma propriedade da listagem.

## Como Começar

1. Clone o repositório:

   ```bash
   git clone https://github.com/armentanoc/RealState.git
	```

## Instale as dependências:

	```bash
	dotnet restore
	```

## Execute a aplicação:

	```bash
	dotnet run
	```

Acesse a API em http://localhost:5000 por padrão.

## Uso

Explore a API usando ferramentas como Postman ou Swagger:

Swagger UI: http://localhost:5000/swagger

## Contribuições

Aceitamos contribuições! Se encontrar um bug ou tiver uma solicitação de recurso, por favor, abra uma issue.
