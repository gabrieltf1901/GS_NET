# Sustainable Energy Project

Este é um projeto de API RESTful desenvolvido em C# com o framework .NET, com o objetivo de gerenciar usuários, dispositivos, consumo de energia, configurações e recomendações para promover práticas sustentáveis e monitorar o consumo energético. A aplicação utiliza o Entity Framework Core para acesso a dados e o banco de dados Oracle para persistência.


## Índice

1. Objetivos
2. Tecnologias Utilizadas
3. Requisitos
4. Estrutura do Projeto
5. Instalação e Configuração
6. Endpoints
7. Contribuição
8. Licença


## Objetivos
O objetivo do projeto é criar uma API robusta para gerenciar os seguintes elementos:

- Usuários: Administradores e usuários comuns.
- Dispositivos: Gerenciamento de dispositivos reais e simulados.
- Consumo: Monitoramento do consumo energético.
- Configurações: Configurações personalizadas para usuários.
- Recomendações: Sugestões gerais ou personalizadas baseadas em dados de consumo.


## Tecnologias Utilizadas
- Linguagem: C# 11 .
- Framework: .NET 7.0 .
- Banco de Dados: Oracle Database.
- ORM: Entity Framework Core.
- Swagger: Para documentação e testes de APIs.


- Ferramentas de Desenvolvimento:
- Visual Studio / Rider.
- Postman / Insomnia (para testes).
- Git e GitHub (controle de versão).


## Requisitos
- .NET SDK: Versão 7.0 ou superior.
- Oracle Database: Acesso a um banco Oracle configurado.
- Git: Para clonar e gerenciar o projeto.
- Ferramenta de IDE: Visual Studio, Rider ou similar.


## Estrutura do Projeto
O projeto segue uma arquitetura limpa com separação de responsabilidades:

SustainableEnergyProject:

- ├── Controllers/         # Controladores para as APIs
- ├── Models/              # Entidades do domínio
- ├── Repositories/        # Implementações de repositórios
- ├── Data/                # Configuração do DbContext e Migrations
- ├── Properties/          # Configurações gerais do projeto
- ├── appsettings.json     # Configuração de conexão com o banco de dados
- └── Program.cs           # Configuração inicial do projeto


## Instalação e Configuração
1. Clone o Repositório:
   - git clone https://github.com/gabrieltf1901/GS_NET.git
2. Configure o Banco de Dados
   Certifique-se de que seu banco Oracle está configurado e crie as tabelas necessárias.
3. Configure a Conexão no appsettings.json
   - Edite o arquivo appsettings.json para adicionar as credenciais do banco de dados Oracle:
    - {
      "ConnectionStrings": {
      "DefaultConnection": "User Id=<seu_usuario>;Password=<sua_senha>;Data Source=oracle.fiap.com.br:1521/orcl"
      }
      }
4. Execute as Migrations
   No terminal, dentro do diretório do projeto:
    - dotnet ef database update
5. Rode o Projeto
    - dotnet run
    - A aplicação estará disponível em: http://localhost:5000


## Endpoints
1. Usuário
   - GET /api/Usuario: Retorna todos os usuários.
   - GET /api/Usuario/{id}: Retorna um usuário pelo ID.
   - POST /api/Usuario: Cria um novo usuário.
   - PUT /api/Usuario/{id}: Atualiza um usuário existente.
   - DELETE /api/Usuario/{id}: Exclui um usuário.
   - GET /api/Usuario/email/{email}: Busca usuário por e-mail.
   - GET /api/Usuario/is-admin/{id}: Verifica se o usuário é administrador.
2. Dispositivo
   - GET /api/Dispositivo: Retorna todos os dispositivos.
   - GET /api/Dispositivo/{id}: Retorna um dispositivo pelo ID.
   - POST /api/Dispositivo: Cria um novo dispositivo.
   - PUT /api/Dispositivo/{id}: Atualiza um dispositivo.
   - DELETE /api/Dispositivo/{id}: Exclui um dispositivo.
   - GET /api/Dispositivo/status/{status}: Retorna dispositivos pelo status.
   - GET /api/Dispositivo/tipo/{tipo}: Retorna dispositivos pelo tipo.
3. Consumo
   - GET /api/Consumo: Retorna todos os consumos.
   - GET /api/Consumo/{id}: Retorna um consumo pelo ID.
   - POST /api/Consumo: Cria um novo registro de consumo.
   - PUT /api/Consumo/{id}: Atualiza um registro de consumo.
   - DELETE /api/Consumo/{id}: Exclui um registro de consumo.
   - GET /api/Consumo/date-range?startDate=&endDate=: Busca consumo por intervalo de datas.
4. Configuração
   - GET /api/Configuracao/{userId}: Retorna as configurações de um usuário.
   - POST /api/Configuracao: Cria novas configurações.
5. Recomendação
   - GET /api/Recomendacao/tipo/{tipo}: Busca recomendações por tipo.
   - GET /api/Recomendacao/usuario/{userId}: Busca recomendações de um usuário.
   - POST /api/Recomendacao: Cria uma nova recomendação.
   
    
## Licença
Este projeto está licenciado sob a MIT License. Consulte o arquivo LICENSE para mais detalhes.



