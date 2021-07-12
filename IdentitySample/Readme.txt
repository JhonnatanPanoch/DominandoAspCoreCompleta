Instalação identity
-Instalar Microsoft.AspNetCore.Identity.UI
-Instalar Microsoft.EntityFrameworkCore.Design
-Adicionar scaffolded item -> identity
-Selecionar os layouts desejados (login e register)
-Remover classe ihosting
-Adcionar o Context e gerar
-Adicionar o context na startup
-Adicionar o .AddRoles<IdentityRole>() em services.AddDefaultIdentity
-Adicionar o comando app.UseAuthentication(), antes do UseAuthorization(), na startup

Rodar comandos para gerar tabelas
- add-migration Identity
- update-database

