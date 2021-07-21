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




