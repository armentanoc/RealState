# RealState Web API 🏡

Bem-vindo à RealState Web API, uma plataforma para gerenciar listagens de propriedades e apoiar corretores imobiliários! 

## Visão Geral

A RealState Web API é um serviço RESTful construído com C# e ASP.NET Core. Ele fornece funcionalidades para gerenciar uma lista de propriedades, tornando-o um backend ideal para aplicações imobiliárias, utilizando conceitos como Arquitetura Limpa, Solid e DDD (Domain Driven Design). 

## Recursos

- **Listar Propriedades**: Obter uma lista de todas as propriedades disponíveis.
- **Obter Propriedade por ID**: Obter detalhes de uma propriedade específica usando seu ID.
- **Adicionar Propriedade**:
  - Adicionar uma nova propriedade à listagem através do CEP e preço, coletando o endereço no Backend através da API CEP Brasil.
  - Adicionar uma nova propriedade à listagem através do preenchimento de todos os campos.
- **Atualizar Propriedade**: Modificar informações para uma propriedade existente.
- **Remover Propriedade**: Excluir uma propriedade da listagem.

## Como Começar

1. Clone o repositório:

```
git clone https://github.com/armentanoc/RealState.git
```

## Instale as dependências:

```
dotnet restore
```

## Execute a aplicação:

```
dotnet run
```

Acesse a API em http://localhost:5000 por padrão. 

## Uso

Explore a API usando ferramentas como Postman ou Swagger:

Swagger UI: http://localhost:5000/swagger

![image](https://github.com/armentanoc/RealState/assets/88147887/75aac7f7-c73b-439d-8df8-2c5586a21b5e)

## Contribuições

Aceitamos contribuições! Se encontrar um bug ou tiver uma solicitação de recurso, por favor, abra uma issue.
