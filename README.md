# Gerenciador de Pessoas e Produtos API

## Descrição

Este é um projeto de uma API Web desenvolvida com .NET que fornece funcionalidades de CRUD (Criar, Ler, Atualizar, Deletar) para gerenciamento de pessoas e produtos. A API também integra uma funcionalidade de busca de endereços utilizando o serviço de API de correios via CEP.

## Recursos

- **CRUD de Pessoas**
  - Criar uma nova pessoa.
  - Buscar todas as pessoas.
  - Buscar pessoa por ID.
  - Atualizar informações de uma pessoa.
  - Deletar uma pessoa.

- **CRUD de Produtos**
  - Criar um novo produto.
  - Buscar todos os produtos.
  - Buscar produto por ID.
  - Atualizar informações de um produto.
  - Deletar um produto.

- **Integração com API de Correios**
  - Busca de endereço utilizando o CEP.
 
  - ## Tecnologias Utilizadas

- **.NET 8**: Framework para desenvolvimento da API.
- **Entity Framework Core**: ORM para acesso ao banco de dados.
- **Refit**: Biblioteca para facilitar a integração com APIs externas.
- **SQL Server**: Banco de dados utilizado.
- **ASP.NET Core**: Framework para criação de APIs web.

- ## Instalação e Configuração

### Pré-requisitos

- .NET 6 ou superior instalado.
- SQL Server ou um servidor de banco de dados de sua escolha.
- Um editor de código como Visual Studio ou Visual Studio Code.

### Passos para Configuração

1. Clone o repositório:
https://github.com/Haverd23/Gerenciador-de-Pessoas-e-Produtos-API.git

2.Restaure as dependências:
dotnet restore

3.Configure a string de conexão no arquivo appsettings.json:
"ConnectionStrings": {
    "DefaultConnection": "Server=seu_servidor;Database=seu_banco_de_dados;User Id=seu_usuario;Password=sua_senha;"
}

4.Crie o banco de dados e aplique as migrações:
dotnet ef database update

5.Execute a aplicação:
dotnet run

6.Acesse a API em https://localhost:7167/swagger/ para visualizar a documentação da API e testar os endpoints.

## Exemplos de Uso

### Criar uma Pessoa

**Requisição POST:**

```http
POST https://localhost:7167/api/Pessoa
Content-Type: application/json

{
    "nome": "João Silva",
    "idade": 30,
    "cep": "01001-000"
}
```

**Resposta**:
```http

{
    "id": 1,
    "nome": "João Silva",
    "idade": 30,
    "cep": "01001-000",
    "bairro": "Sé",
    "localidade": "São Paulo",
    "uf": "SP"
}
```
### Buscar Todas as Pessoas
**Requisição GET:**
```http
GET https://localhost:7167/api/Pessoa
```
**Resposta:**
```http
[
    {
        "id": 1,
        "nome": "João Silva",
        "idade": 30,
        "cep": "01001-000",
        "bairro": "Sé",
        "localidade": "São Paulo",
        "uf": "SP"
    }
]
```
### Atualizar uma Pessoa
**Requisição PUT:**
```http
PUT https://localhost:7167/api/Pessoa/{id da Pessoa, no exemplo 1}
{
    "nome": "João Silva",
    "idade": 31,
    "cep": "01001-000"
}
```
**Resposta:**
```http
{
    "id": 1,
    "nome": "João Silva",
    "idade": 31,
    "cep": "01001-000",
    "bairro": "Sé",
    "localidade": "São Paulo",
    "uf": "SP"
}
```
### Deletar uma Pessoa
**Requisição DELETE:**
```http
DELETE https://localhost:7167/api/Pessoa/{id da Pessoa, no exemplo 1}
```
**Resposta:**
```http
true
```
### Descrição das Pastas

- **Controllers**: Contém os controladores da API que gerenciam as requisições HTTP.
- **Models**: Define os modelos de dados utilizados na aplicação.
- **Repositorio**: Implementa a lógica de acesso a dados e interações com o banco.
- **Integracao**: Contém classes para integração com APIs externas, como a API de correios.
- **Data**: Configurações do contexto do banco de dados.
- **Program.cs**: Ponto de entrada da aplicação.
