Adicionar migration:
	Add-Migration Initial -Verbose -Context CustomDbContext
	Para adicionar as tabelas do sistema usar o contexto 'ApplicationDbContext'. Adicionar e atualizar


Atualizar banco:
	Update-database -Verbose -Context CustomDbContext


Gerar SQL:
	Script-Migration -Context CustomDbContext



------ Deploy ------
Rodar o visual studio em administrador

Ambiente
	-Baixar .net runtime & hosting bundle for windows da versão do .net da aplicação
	-Instalar executavel.

IIS
	- Add website
	- site name: curso.mvc
	- path: caminho do publish
	- porta: 80
	- ok

	- bindings (suporte a 443)
	- adicionar
	- tipo: https
	- porta: 443
	- certificado: iis express development certificate
	- ok

	-http strict transport security

Publish
	- Projeto web > publish
	- Web Server (IIS) > Web deploy
	- server: localhost
	- site name: curso.mvc
	- destination url: localhost
	- user e senha n precisa em localhost



------ Deploy SELF-HOSTING ------

	- acessar a pasta em que o csproj está, via cmd
	- rodar comando: dotnet run --project DevIO.App.csproj





------ Deploy AZURE ------
conn string: Data Source=tcp:cursomvc-deviodbserver.database.windows.net,1433;Initial Catalog=cursomvc_devio;User Id=jpanoch@cursomvc-deviodbserver;Password=aA@91943840

db: cursomvc-deviodbserver
user: jpanoch ou jpanoch@cursomvc-deviodbserver
pwd: aA@91943840


