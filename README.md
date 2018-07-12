"# DotNet.Core.Banking.API" 

Using <TargetFramework>netcoreapp2.1</TargetFramework>

NetCoreBankingWebAPI project using NetCore 2.0 failed deploying to Pivotal

TestAPI project using NetCore 2.1 deployed to Pivotal at: https://netcore-banking-api.cfapps.io/
Using Travis for CI

Folder structure: Screaming Architecture
http://www.matthewrenze.com/articles/clean-architecture-in-asp-net-mvc-5/

Accounts

	api
	
		controller
		
	application
	
		dto
		
	domain
	
		entity
		
		repository
		
	infraestructure
	
		nhibernate
		
Common

	api
	
		controller
		
	application
	
		dto
		
		enumeration
		
	infraestructure
	
		nhibernate
		
			repository
			
Customers

	api
	
		controller
		
	application
	
		dto
		
	domain
	
		entity
		
		repository
		
	infraestructure
	
		nhibernate
		
Transactions

	api
	
		controller
		
	application
	
		dto
		
			deserializer
			
	domain
	
		service# ADS_DotNet.Core.Banking.API
