# CQRS---CadProfissao-Api-Server


================================
CQRS - CadProfissao Api Server

Manifesto - Arquitetura ambrião em CQRS

Projeto desenvolvendo para análise de estrutra e avaliação de padrões adotodas 
na arquitetura DDD.

Estrutura:

	└───src
    ├───CadProfissao.Application
    │   ├───bin
    │   │   └───Debug
    │   │       └───netcoreapp2.1
    │   ├───Commands
    │   ├───DTO
    │   ├───Entities
    │   ├───Extensions
    │   ├───Handlers
    │   ├───Interfaces
    │   ├───Notifications
    │   ├───obj
    │   │   └───Debug
    │   │       └───netcoreapp2.1
    │   ├───Querys
    │   └───Validations
    ├───CadProfissao.Infra.Data
    │   ├───bin
    │   │   └───Debug
    │   │       └───netcoreapp2.1
    │   ├───obj
    │   │   └───Debug
    │   │       └───netcoreapp2.1
    │   └───Repositories
    └───CadProfissao.WebApi
        ├───bin
        │   └───Debug
        │       └───netcoreapp2.1
        ├───Controllers
        ├───obj
        │   └───Debug
        │       └───netcoreapp2.1
        ├───Properties
        └───wwwroot

Etapas para execução do programa:
	
	1 -	Ajustar string de conexão na seção "ConnectionStrings"
	Arquivo: \src\CadProfissao.WebApi\appsettings.json
 
	2 - Executar script de banco SQL SERVER
	Arquivo: \scripts\scriptdatabase.sql
	
	Obs: É importante que seja realizada esta configuração antes da execução do programa
