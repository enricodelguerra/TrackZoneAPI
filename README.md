# TrackZone API

API RESTful desenvolvida com ASP.NET Core para gerenciamento e rastreamento de motos em pátios de filiais. O projeto utiliza Entity Framework Core com Oracle como banco de dados.

## 🚀 Tecnologias Utilizadas

- .NET 8.0
- Entity Framework Core 9.0.5
- Oracle Database
- Swagger/OpenAPI
- ASP.NET Core Web API

## 📋 Pré-requisitos

- .NET 8.0 SDK
- Oracle Database
- Visual Studio 2022 ou VS Code
- Oracle Client Tools

## 🔧 Configuração do Ambiente

1. Clone o repositório:
```bash
git clone [URL_DO_REPOSITÓRIO]
```

2. Configure a string de conexão no arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "OracleConnection": "sua_string_de_conexao_aqui"
  }
}
```

3. Restaure as dependências do projeto:
```bash
dotnet restore
```

4. Execute as migrações do banco de dados:
```bash
dotnet ef database update
```

## 🏃‍♂️ Executando o Projeto

1. Para executar em modo desenvolvimento:
```bash
dotnet run
```

2. Acesse a documentação Swagger em:
```
https://localhost:5001/swagger
```
## 📦 Exemplos de Requisições

- Criar Usuário
POST /api/Usuarios

```
{
  "nomeFilial": "Filial Centro",
  "email": "filial@empresa.com",
  "senhaHash": "senha123",
  "cnpj": "12.345.678/0001-99",
  "endereco": "Rua Exemplo, 123",
  "telefone": "(11) 91234-5678",
  "perfil": "Administrador"
}
```

- 🏍️ Cadastrar Moto
POST /api/Motos
```
{
  "placa": "ABC1234",
  "chassi": "9C2KC0850GR123456",
  "motor": "ABC12345678",
  "iotId": "iot-abc-001",
  "usuarioId": 1
}
```
- 📍 Registrar Localização
POST /api/Localizacoes
```
{
  "latitude": -23.5505,
  "longitude": -46.6333,
  "dadosIot": "Velocidade: 60km/h",
  "motoId": 1
}
```

- 📊 Registrar Operação
POST /api/Operacoes
```
{
  "tipoOperacao": "Entrada",
  "observacoes": "Moto entrou no pátio às 08h",
  "motoId": 1,
  "usuarioId": 1
}
```

- 🏷️ Registrar Status da Moto
POST /api/StatusMotos
```
{
  "status": "Estacionada",
  "area": "A1",
  "motoId": 1,
  "usuarioId": 1
}
```

##  Exemplos de Rotas

## 1. Usuários (UsuariosController)

**Prefixo:** `/api/usuarios`

- **GET /api/usuarios**  
  Descrição: Retorna uma lista de todos os usuários (incluindo suas motos, status e operações).  
  Resposta: Um array de objetos (UsuarioReadDTO) com os dados dos usuários.

- **GET /api/usuarios/{id}**  
  Descrição: Retorna os detalhes de um usuário (identificado pelo parâmetro de rota "id").  
  Resposta: Um objeto (UsuarioReadDTO) ou 404 (Not Found) se o usuário não existir.

- **POST /api/usuarios**  
  Descrição: Cria um novo usuário.  
  Resposta: Retorna o objeto criado (com o Id gerado) e o status 201 (Created).

- **PUT /api/usuarios/{id}**  
  Descrição: Atualiza os dados de um usuário (identificado pelo parâmetro de rota "id").  
  Resposta: Retorna 204 (No Content) se a atualização for bem-sucedida ou 404 (Not Found) se o usuário não existir.

- **DELETE /api/usuarios/{id}**  
  Descrição: Remove um usuário (identificado pelo parâmetro de rota "id").  
  Resposta: Retorna 204 (No Content) se a remoção for bem-sucedida ou 404 (Not Found) se o usuário não existir.

---

## 2. Operações (OperacoesController)

**Prefixo:** `/api/operacoes`

- **GET /api/operacoes**  
  Descrição: Retorna uma lista de todas as operações (incluindo dados da moto e do usuário associado).  
  Resposta: Um array de objetos (OperacaoReadDTO).

- **GET /api/operacoes/{id}**  
  Descrição: Retorna os detalhes de uma operação (identificada pelo parâmetro de rota "id").  
  Resposta: Um objeto (OperacaoReadDTO) ou 404 (Not Found) se a operação não existir.

- **POST /api/operacoes**  
  Descrição: Cria uma nova operação.  
  Resposta: Retorna o objeto criado (com o Id gerado) e o status 201 (Created).

- **PUT /api/operacoes/{id}**  
  Descrição: Atualiza os dados de uma operação (identificada pelo parâmetro de rota "id").  
  Resposta: Retorna 204 (No Content) se a atualização for bem-sucedida ou 404 (Not Found) se a operação não existir.

- **DELETE /api/operacoes/{id}**  
  Descrição: Remove uma operação (identificada pelo parâmetro de rota "id").  
  Resposta: Retorna 204 (No Content) se a remoção for bem-sucedida ou 404 (Not Found) se a operação não existir.

---

## 3. Localizações (LocalizacoesController)

**Prefixo:** `/api/localizacoes`

- **GET /api/localizacoes**  
  Descrição: Retorna uma lista de todas as localizações (incluindo dados da moto associada).  
  Resposta: Um array de objetos (LocalizacaoReadDTO).

- **GET /api/localizacoes/{id}**  
  Descrição: Retorna os detalhes de uma localização (identificada pelo parâmetro de rota "id").  
  Resposta: Um objeto (LocalizacaoReadDTO) ou 404 (Not Found) se a localização não existir.

- **POST /api/localizacoes**  
  Descrição: Cria uma nova localização.  
  Resposta: Retorna o objeto criado (com o Id gerado) e o status 201 (Created).

- **PUT /api/localizacoes/{id}**  
  Descrição: Atualiza os dados de uma localização (identificada pelo parâmetro de rota "id").  
  Resposta: Retorna 204 (No Content) se a atualização for bem-sucedida ou 404 (Not Found) se a localização não existir.

- **DELETE /api/localizacoes/{id}**  
  Descrição: Remove uma localização (identificada pelo parâmetro de rota "id").  
  Resposta: Retorna 204 (No Content) se a remoção for bem-sucedida ou 404 (Not Found) se a localização não existir.

---

## 4. Motos (MotosController)

**Prefixo:** `/api/motos`

- **GET /api/motos**  
  Descrição: Retorna uma lista de todas as motos (incluindo dados do usuário associado).  
  Resposta: Um array de objetos (MotoReadDTO).

- **GET /api/motos/{id}**  
  Descrição: Retorna os detalhes de uma moto (identificada pelo parâmetro de rota "id").  
  Resposta: Um objeto (MotoReadDTO) ou 404 (Not Found) se a moto não existir.

- **POST /api/motos**  
  Descrição: Cria uma nova moto.  
  Resposta: Retorna o objeto criado (com o Id gerado) e o status 201 (Created).

- **PUT /api/motos/{id}**  
  Descrição: Atualiza os dados de uma moto (identificada pelo parâmetro de rota "id").  
  Resposta: Retorna 204 (No Content) se a atualização for bem-sucedida ou 404 (Not Found) se a moto não existir.

- **DELETE /api/motos/{id}**  
  Descrição: Remove uma moto (identificada pelo parâmetro de rota "id").  
  Resposta: Retorna 204 (No Content) se a remoção for bem-sucedida ou 404 (Not Found) se a moto não existir.

## 5. Status das Motos (StatusMotosController)

**Prefixo:** `/api/statusmotos`

- **GET /api/statusmotos**  
  Descrição: Retorna uma lista de todos os status (incluindo dados da moto e do usuário associado).  
  Resposta: Um array de objetos (StatusMotoReadDTO).

- **GET /api/statusmotos/{id}**  
  Descrição: Retorna os detalhes de um status (identificado pelo parâmetro de rota “id”).  
  Resposta: Um objeto (StatusMotoReadDTO) ou 404 (Not Found) se o status não existir.

- **POST /api/statusmotos**  
  Descrição: Cria um novo status.  
  Resposta: Retorna o objeto criado (com o Id gerado) e o status 201 (Created).

- **PUT /api/statusmotos/{id}**  
  Descrição: Atualiza os dados de um status (identificado pelo parâmetro de rota “id”).  
  Resposta: Retorna 204 (No Content) se a atualização for bem-sucedida ou 404 (Not Found) se o status não existir.

- **DELETE /api/statusmotos/{id}**  
  Descrição: Remove um status (identificado pelo parâmetro de rota “id”).  
  Resposta: Retorna 204 (No Content) se a remoção for bem-sucedida ou 404 (Not Found) se o status não existir.

## 📁 Estrutura do Projeto

- `Controllers/` - Controllers da API
- `Models/` - Modelos de dados
- `Data/` - Contexto do banco de dados e configurações
- `Migrations/` - Migrações do Entity Framework
- `Exceptions/` - Tratamento de exceções personalizadas

## 🔐 Segurança

- A API utiliza HTTPS por padrão


## ✒️ Autores

* ***Leticia Cristina Dos Santos Passos RM: 555241***
* ***André Rogério Vieira Pavanela Altobelli Antunes RM: 554764***
* ***Enrico Figueiredo Del Guerra RM: 558604***
