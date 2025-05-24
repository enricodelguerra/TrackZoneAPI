# TrackZone

TrackZone é uma API REST desenvolvida em .NET 8.0 para gerenciamento e rastreamento de motos em pátios. O projeto utiliza Entity Framework Core com Oracle como banco de dados.

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
