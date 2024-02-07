# RealState Web API ??

Bem-vindo � RealState Web API, uma plataforma para gerenciar listagens de propriedades e apoiar corretores imobili�rios! ??

## Vis�o Geral

A RealState Web API � um servi�o RESTful constru�do com C# e ASP.NET Core. Ele fornece funcionalidades para gerenciar uma lista de propriedades, tornando-o um backend ideal para aplica��es imobili�rias.

## Recursos

- **Listar Propriedades**: Obter uma lista de todas as propriedades dispon�veis.
- **Obter Propriedade por ID**: Obter detalhes de uma propriedade espec�fica usando seu ID.
- **Adicionar Propriedade**: Adicionar uma nova propriedade � listagem e obter seu ID atribu�do.
- **Atualizar Propriedade**: Modificar informa��es para uma propriedade existente.
- **Remover Propriedade**: Excluir uma propriedade da listagem.

## Endpoints da API

- **GET /propriedades**: Obter todas as propriedades.
- **GET /propriedades/{id}**: Obter detalhes de uma propriedade espec�fica por ID.
- **POST /propriedades**: Adicionar uma nova propriedade � listagem.
- **PUT /propriedades/{id}**: Atualizar informa��es para uma propriedade existente.
- **DELETE /propriedades/{id}**: Remover uma propriedade da listagem.

## Como Come�ar

1. Clone o reposit�rio:

   ```bash
   git clone https://github.com/armentanoc/RealState.git
	```

## Instale as depend�ncias:

	```bash
	dotnet restore
	```

## Execute a aplica��o:

	```bash
	dotnet run
	```

Acesse a API em http://localhost:5000 por padr�o.

## Uso

Explore a API usando ferramentas como Postman ou Swagger:

Swagger UI: http://localhost:5000/swagger

## Contribui��es

Aceitamos contribui��es! Se encontrar um bug ou tiver uma solicita��o de recurso, por favor, abra uma issue.
