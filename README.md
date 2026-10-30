# Sistema Produto & Cliente (C#)

Sistema de gerenciamento de **Produtos** e **Clientes** desenvolvido em **C# (.NET 10)**, com CRUD completo para as duas entidades e organização em camadas inspirada na **arquitetura hexagonal** (ports and adapters). Projeto acadêmico desenvolvido no curso de Engenharia de Software da FIAP.

---

## Sumário

- [Funcionalidades](#funcionalidades)
- [Tecnologias](#tecnologias)
- [Arquitetura](#arquitetura)
- [Estrutura de pastas](#estrutura-de-pastas)
- [Modelos de dados](#modelos-de-dados)
- [Endpoints da API](#endpoints-da-api)
- [Validações](#validações)
- [Como executar](#como-executar)
- [Estado atual e limitações](#estado-atual-e-limitações)
- [Próximos passos](#próximos-passos)
- [Autor](#autor)
- [Licença](#licença)

---

## Funcionalidades

**Produto**
- Adicionar produto
- Atualizar produto por ID
- Deletar produto por ID
- Consultar produto por ID
- Listar todos os produtos

**Cliente**
- Adicionar cliente
- Atualizar cliente por ID
- Deletar cliente por ID
- Consultar cliente por ID
- Listar todos os clientes

A interação atual acontece por **menu no console** (`Program.cs`). Os **controllers REST** já estão implementados na camada de adapters (veja [Estado atual e limitações](#estado-atual-e-limitações)).

---

## Tecnologias

| Tecnologia | Uso |
|---|---|
| C# / .NET 10 (`net10.0`) | Linguagem e plataforma |
| ASP.NET Core (`Microsoft.NET.Sdk.Web`) | Controllers REST |
| Data Annotations | Validação dos DTOs e mapeamento dos modelos |
| Coleções em memória (`List<T>`) | Persistência temporária dos dados |

---

## Arquitetura

O projeto separa responsabilidades em camadas:

```
Adapter de entrada (Controller / Console)
        │
        ▼
      DTO (Request)  ──►  Service  ──►  Repository  ──►  Model
                          (domain)       (domain)         (domain)
```

- **adapters/in/controller**: porta de entrada HTTP. Recebe o DTO, converte para o modelo e chama o service.
- **dto/in**: objetos de requisição, com as regras de validação da entrada.
- **domain/service**: regras de aplicação; orquestra o repository.
- **domain/repository**: acesso aos dados (atualmente em memória).
- **domain/model**: entidades `Produto` e `Cliente`.

---

## Estrutura de pastas

```
Sistema-Produto-Cliente-csharp/
├── Program.cs                      # Menu de console (ponto de entrada)
├── Produtos.csproj
├── Produtos.slnx
├── adapters/
│   └── in/
│       └── controller/
│           ├── ClienteController.cs
│           └── ProdutoController.cs
├── domain/
│   ├── model/
│   │   ├── Cliente.cs
│   │   └── Produto.cs
│   ├── repository/
│   │   ├── ClienteRepository.cs
│   │   └── ProdutoRepository.cs
│   └── service/
│       ├── ClienteService.cs
│       └── ProdutoService.cs
├── dto/
│   └── in/
│       ├── ClienteRequest.cs       # ClienteRequestDTO
│       └── ProdutoRequest.cs       # ProdutoRequestDTO
├── LICENSE.txt
└── README.md
```

---

## Modelos de dados

### Produto (`produtos`)

| Campo | Tipo | Descrição |
|---|---|---|
| `id` | `long` | Identificador |
| `nome` | `string` | Nome do produto |
| `descricao` | `string` | Descrição do produto |
| `preco` | `decimal` | Preço unitário |
| `quantidade` | `int` | Quantidade em estoque |

### Cliente (`clientes`)

| Campo | Tipo | Descrição |
|---|---|---|
| `id` | `long` | Identificador |
| `Nome` | `string` | Nome do cliente |
| `Email` | `string` | E-mail |
| `Telefone` | `string` | Telefone |
| `Endereco` | `string` | Endereço |
| `Cpf` | `string` | CPF formatado (`000.000.000-00`) |

---

## Endpoints da API

Rota base: `api/[controller]` → `api/Produto` e `api/Cliente`.

| Método | Rota | Descrição | Resposta |
|---|---|---|---|
| `POST` | `/api/Produto` | Cria um produto | `201 Created` |
| `GET` | `/api/Produto` | Lista todos | `200 OK` |
| `GET` | `/api/Produto/{id}` | Busca por ID | `200 OK` / `404 Not Found` |
| `PUT` | `/api/Produto/{id}` | Atualiza por ID | `204 No Content` |
| `DELETE` | `/api/Produto/{id}` | Remove por ID | `204 No Content` |
| `POST` | `/api/Cliente` | Cria um cliente | `201 Created` |
| `GET` | `/api/Cliente` | Lista todos | `200 OK` |
| `GET` | `/api/Cliente/{id}` | Busca por ID | `200 OK` / `404 Not Found` |
| `PUT` | `/api/Cliente/{id}` | Atualiza por ID | `204 No Content` |
| `DELETE` | `/api/Cliente/{id}` | Remove por ID | `204 No Content` |

### Exemplo de corpo (`POST /api/Produto`)

```json
{
  "nome": "Teclado Mecânico",
  "descricao": "Teclado mecânico switch azul ABNT2",
  "preco": 299.90,
  "quantidade": 15
}
```

### Exemplo de corpo (`POST /api/Cliente`)

```json
{
  "nome": "Maria Silva",
  "email": "maria@email.com",
  "telefone": "11999999999",
  "endereco": "Rua das Flores, 123 - São Paulo",
  "cpf": "123.456.789-00"
}
```

---

## Validações

### ProdutoRequestDTO

| Campo | Regra |
|---|---|
| `Nome` | Obrigatório, 2 a 100 caracteres |
| `Descricao` | Obrigatório, 10 a 200 caracteres |
| `Preco` | Obrigatório, maior que 0,01 |
| `Quantidade` | Obrigatório, maior ou igual a 0 |

### ClienteRequestDTO

| Campo | Regra |
|---|---|
| `Nome` | Obrigatório, 2 a 100 caracteres |
| `Email` | Obrigatório, formato de e-mail, 5 a 100 caracteres |
| `Telefone` | Obrigatório, formato de telefone, 10 a 20 caracteres |
| `Endereco` | Obrigatório, 10 a 200 caracteres |
| `Cpf` | Obrigatório, exatamente 14 caracteres (com pontos e traço) |

---

## Como executar

### Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- IDE de sua preferência (Visual Studio, Rider ou VS Code)

### Passo a passo

```bash
# 1. Clonar o repositório
git clone https://github.com/<seu-usuario>/Sistema-Produto-Cliente-csharp.git

# 2. Entrar na pasta do projeto
cd Sistema-Produto-Cliente-csharp

# 3. Restaurar dependências
dotnet restore

# 4. Executar
dotnet run
```

Ao executar, o menu principal é exibido no console:

```
===== Menu principal =====
1. Menu Produto
2. Menu Cliente
0. Sair
```

---

## Estado atual e limitações

Pontos conhecidos que fazem parte da evolução do projeto:

- **Persistência em memória**: os dados ficam em `List<T>` dentro dos repositories e são perdidos ao encerrar a aplicação. Os atributos `[Table]` e `[Column]` nos modelos já preparam o mapeamento para um banco relacional.
- **Controllers ainda não hospedados**: o ponto de entrada atual é o `Main` com menu de console. Os controllers existem, mas ainda não há `WebApplication` configurado (registro de services, `MapControllers`) para expor os endpoints HTTP.
- **Geração de ID**: o ID é informado manualmente no console; no fluxo REST o `POST` não gera ID, então o valor fica em `0` até existir uma estratégia de geração.
- **Sem tratamento de erros de domínio**: atualizar ou deletar um ID inexistente não retorna erro; a pasta `domain/exceptions` está referenciada no `.csproj`, mas ainda sem exceções implementadas.
- **Sem testes automatizados**.

---

## Próximos passos

- [ ] Configurar o host ASP.NET Core e registrar os services por injeção de dependência
- [ ] Persistir em banco de dados com **Entity Framework Core** (equivalente do JPA/Hibernate no ecossistema .NET)
- [ ] Gerar IDs automaticamente
- [ ] Criar exceções de domínio (`domain/exceptions`) e tratamento global de erros
- [ ] Criar DTOs de resposta (`dto/out`)
- [ ] Adicionar Swagger/OpenAPI
- [ ] Adicionar testes unitários

---

## Autor

**Christian Schunck de Almeida**

---

## Licença

Distribuído sob a licença MIT. Consulte o arquivo [LICENSE.txt](LICENSE.txt) para mais detalhes.
