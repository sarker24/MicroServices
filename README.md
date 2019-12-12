# MicroServices Mini Project
## Introduction:
This is a .Net Core application how to build and implementation a microservices for simple airline ticket booking feedback system in ASP.NET Core WEB API with C#.Net, Entity Framework, RabbitMQ Server and SQL Server.

## Application Architecture:
The sample application is built based on microservices architecture. There are several benefits of building an application using microservice architecture. Services can be develop, deploy independently. The diagram shows the architecture of my application

<img width="676" alt="Untitled" src="https://user-images.githubusercontent.com/31739314/70749047-a0651600-1d2b-11ea-840d-b22b37c0e96c.png">
 
This diagram shows the internal design of the transaction microservices. The business logic and datalogic related to traction service is written in a separate transaction processing framework. The transaction data is stored in sQL server.

Development Environment:


* NET Core 2.2 SKD
* Visual studio Web API core
* RabbitMQ server

