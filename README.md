# Fitnees Food LC
# Backend Challenge 20220626
# This is a challenge by [Coodesh](https://coodesh.com/)

# Descrição
Nesse desafio trabalharemos no desenvolvimento de uma REST API que utilizará os dados do projeto Open Food Facts, um banco de dados aberto com informação nutricional de diversos produtos alimentícios.

O projeto tem como objetivo dar suporte a equipe de nutricionistas da empresa Fitness Foods LC para que possam comparar de maneira rápida a informação nutricional dos alimentos da base do Open Food Facts.

# Uso do projeto

Sistema operacional utilizado: Windows
Banco de dados utilizado no desenvolvimento do challenge: SQLServer

Script para criação da tabela necessária

create table Product (
	code varchar(20) primary key,
	barcode varchar(50),
	status numeric(1),
	imported datetime, 
	url varchar(500) null,
	product_name varchar(500) null,
	quantity varchar(500) null,
	categories varchar(500) null,
	packaging varchar(500) null,
	brands varchar(500) null,
	image_url varchar(500) null,
)

O tamanho dos campos foi definido como varchar(500) já que são dinâmicos e poderia gerar erro ao salvar no banco de dados.

Criado um EnumStatus para armazenar os status draft e imported.

Imported foi definido como Datetime onde armazena a data que o produto foi importado.

Para realizar o CRON e realizar a importação diaria de forma automatica foi utilizado o Hangfire

Para fazer o scraping da página foi utilizado o htmlagilitypack

# Pacotes necessários para execução do projeto:

Hangfire.AspNetCore
Hangfire.Core
Hangfire.MemoryStorage
Hangfire.SqlServer
HtmlAgilityPack
Microsoft.AspNet.Mvc
Microsoft.EntityFramewrkCore
Microsoft.EntityFramewrkCore.SqlServer
Microsoft.EntityFramewrkCore.Tools

# Creditos 

This is a challenge by [Coodesh](https://coodesh.com/)
