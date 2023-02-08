# CustomerCare
Cadastro de contas de usuário para canais de comunicação.

## Como executar
Após clonar o repositório, siga os passos abaixo:

1. Abra uma janela do terminal na raíz da solução e execute o comando `dotnet build` para compilar a aplicação.
   - Caso tenha problemas para restaurar os pacotes, certifique-se de que existem fontes do nuget configuradas. Se precisar execute o comando `dotnet nuget add source https://api.nuget.org/v3/index.json`.
2. Ainda no terminal, execute o comando `dotnet run --project .\src\CustomerCare.Api\ -lp https` para iniciar a aplicação. O servidor estará ouvindo nas portas 5178(HTTP) e 7238(HTTPS).
3. Abra o navegador e acesse a URL *https://localhost:7238/site* para acessar a interface de cadastro de usuários.

IMPORTANTE: É necessário ter o **.NET 7** instalado para executar a aplicação.

## Limitação
Por ter sido desenvolvida somente uma feature de cadastro de contas de usuário, o único meio de confirmar se a conta foi realmente criada é inspecionar o banco de dados.
Como foi utilizado o SQLite para o BD, para inspecionar o banco será necessário ter instalado o **sqlite command shell** (https://www.sqlite.org/download.html) ou pode-se utilizar a ferramenta online sqlite-viewer (https://inloop.github.io/sqlite-viewer/).