Adicionar migration:
	Add-Migration Initial -Verbose -Context CustomDbContext
	Para adicionar as tabelas do sistema usar o contexto 'ApplicationDbContext'. Adicionar e atualizar


Atualizar banco:
	Update-database -Verbose -Context CustomDbContext


Gerar SQL:
	Script-Migration -Context CustomDbContext