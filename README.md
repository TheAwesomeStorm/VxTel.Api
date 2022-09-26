# VxTel.API

Esta é uma API REST exemplo, com o objetivo  de testar os conhecimentos do desenvolvedor.

## Sobre a arquitetura

Este projeto utiliza do *framework* `ASP.NET Core` para a construção da API e do *framework* `Entity Framework Core` para gerar as entidades e um banco de dados `MySQL`, assim como para gerir as requisições ao banco.

## Requisitos

- .NET 6
- MySQL v5.7

## Instalação

A *string* de conexão ao banco foi configurada no arquivo `appsettings.json`, no mesmo é possível configurar o usuário, senha e *schema* de conexão. O `Entity Framework Core` se responsabiliza pela criação das entidades e seus relacionamentos, conforme configurado na aplicação, para atualizar o banco será necessário criar as `Migrations`, se não já existentes, e então atualizar o banco.

### Migrations

Instale as ferramentas locais do .NET.

`dotnet new tool-manifest`

Após, instale o `Entity Framework CLI` através do comando abaixo.

`dotnet tool install dotnet-ef --version "6.0.9"`

E por fim, atualize o banco de dados com as `Migrations`

`dotnet ef database update`

Caso uma pasta com as Migrations não esteja disponível no projeto, realizei um passo intermediário para criação das mesmas, conforme abaixo, e então atualize o banco.

`dotnet ef migrations add "InitialSetup"`

## Sobre a nomenclatura dos objetos

A nomenclatura dos objetos foi mantida em inglês, para não haver discordância com classes e objetos já estabelecidos em inglês, como `Controllers`, `Services` e `DTOs`, entretanto, a documentação da API será construída em português, visando maior abrangência.

