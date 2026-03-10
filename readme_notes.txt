
.NET 8 Microservices: DDD, CQRS, Vertical/Clean Architecture
https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet/learn/lecture/42551648#overview

Mehmet Ozkaya
https://github.com/mehmetozkaya

Source Code:
https://github.com/aspnetrun/run-aspnetcore-microservices

https://github.com/dotnet/eshop
https://github.com/dotnet/eShop.git


Getting Started
This version of eShop is based on .NET 9.

Previous eShop versions:

.NET 8
Prerequisites
Clone the eShop repository: https://github.com/dotnet/eshop
Install & start Docker Desktop



Running the solution
***Remember to ensure that Docker is started

(Windows only) Run the application from Visual Studio:
Open the eShop.Web.slnf file in Visual Studio
Ensure that eShop.AppHost.csproj is your startup project
Hit Ctrl-F5 to launch Aspire


run-aspnetcore-microservices
https://github.com/aspnetrun
https://github.com/aspnetrun/run-aspnetcore-microservices.git



function pointer


what is new in c#12?
-Primary Constructor
public classPerson(string name, int age)
{
	// Name and Age are in scope for the entire class body
	public string Name => name;
	public int Age => age;
}

-Collection Expressions
More concise syntax to create common collection values. Simplifies the way collections are initialized and manipulated
var numbers = new List<int>{1,2,3,...};   //old
var numbers = [1,2,3,...]; //new way

-Inline Arrays
create fixed-size arrays in struct types
useful for optimizing memory layout and improving runtime performance
public struct Buffer
{
	public Span<int> InlineArray => MemoryMarshal.CreateSpan(ref _array[0], 10);
	private int[] _array;
}
-Optional Parameters in Lambda ExpressionsDefault values for parameters in lambda expressons.
Func<int, int, int> add=(x,y=1) => x+y;
Console.WrietLine(add(5)); //Outputs 6

-ref readonly parametersEnhances the way readonly references are passedn C#
Optimizing memory usage and performance in scenarios involving large data structures
public void ProcessLargeData(int LargeData data)
{
	//Processing data without the risk of modifications
}

-Alias Any Type
Using alais dorective to include any type, not kust namedtypes
Creation of semantic aliases for complex types like tuples, arrays, and pointer types
using Coordinate = System.ValueTuple<int, int>;
Coordinate location = (10,20);

Top-level statements
no main method

Global using
make namespaces available across entire project, declare themglobally in one plac
global using System;
global using System.Collections.Generic;


Pattern Matching
public class Person
{
	publoc string Name {get set;}
	public string Title {get; set;}
}
Person person = new Person {Name=John", Title="Manager"};
if(person is {Title:Manager"})
{
	Console.WriteLine($"{person.Name} is a manager!.");
}


Minimal API

var app = WebApplication.Create(args);
app.MapGet("/", () => "Hello World!");
app.Run();


Dynamic Routin


C:\CodeUdemy\MehmetOzkaya\ExampleMinimal
container OS: Linux
Contain build type Dockerfile



Docker Cotainers, Images and Registries
	Docker Hub/Azure Container Registry

Developer download existing image from registry and create cintainer from image n local environment.

1.write Dockerfile for application
2.Build application with this dockerfile and craetes the docker images
3.Run this image on any machine and creates running docker container from docker image
Orchestrating whole microservices application with Docker-Compose from running multi-container Docker images.single command, create and start all the services.

<docker compose>

right click project > add > Docker Support > 


Vertical Slice Architecture with Feature folders
CQRS implementation using MediatR library
Marten library for .NET Transactional Document DB on PostgreSQL

Vertical Slices:
New Feature:
	||UI
	||Application
	||Domain
	||Infrastructure

Carter implementing minimal API endpoint definition into catalog microservices
Mapster maps DTO classes
FluentValidation
dockerfile and docker compose Yaml file


Domain Analysis of Catalog Microservices
1.Domain Models
	Product, Category
2.Applocation Use Cases
	Listing Products and Categories,search products
3.Rest API Endpoints
	GET/POST/PUT/DELETE
4.Underlying Data Structures
	Document Database with Store Catalog JSON data
	MongoDB No-SQL database, PosegreSQL DB JSON Columns
		Chosen - PostgreSQL with the Marten library - transforms PostgreSQL into a .NET Transactional Diocument DB
													- PostgreSQL's jSON column features, allowing us to store and query our data as JSON documents
													- Combones the flexibility of a document database with the reliability of relational PostgreSQL database

1. Application Architecture Style of Catalog Microsevices
Vertical Slice Architecture-Organizes code into geature folders,each feature encapsulated in a single.cs file

2. Patterns & Principles of Catalog Microservices
-CQRS Pattern: Command Query Responsibility Segregation divides operations into commands(write) and queries(read).
-Mediator Patter: Facilitates object interaction through a 'mediator', reduing direct dependencies and simplifying communications.
-DI in ASP.NET COre:
-Minimal APIs and Routing in ASP.NET 8
-ORM pattern:Object-Relational Mapping abstracts database interactions, work with database object using high-level codes.

3. Libraries Nuget packages ofCatalog Microservices
-MediatR for CQRS: MediatR library simplifies the implementation of the CQRS pattern.
-Carter for API Endppints: Routing and handling HTTP requests, easier to define PAI endpoints with clean and concise code.
-Marten for PostgreSQL interaction:Use PostgreSQL as a document DB. It leverages PostgreqSQL's JSON capabilities for storing, querying, and managing documents.
-Mapster for object mapping:Mapster is a fast, configurable object mapper that simplifies the task of mapping objects.
-FlientValidation for input validation:for building string-typed validation rules, ensure input are correct before processed.

4.Project Folder structure of catalog microervices
The project is organized into
Model
Features (Products)- like CreateProduct, GetProduct have dedicated handlers and endpoint definitions
Data - Context object manages database interactions
Abstractions


Vertical Slice Architecture
-Introduces by Jimmy Bogard offers this archotecture against to traditional layered/onion/clean architecture approaches.
-Aims to organize code around specific features or ise cases, rather than technical concerns.
-Feature is implemented across all layers of the software, from the user interface to the database.
-Often used in the development of complex, feature-ricj apps
-Divide application into distinct features or functionalities, each of which suts through all the layers of the application.
-Contrast to traditional n-tier or layered architectures, where the application is divided horixontally (e.g., presentation, business logic, data access layers).


sigle database for services can cause bottlenecks
uses both CQRS and Event Sourcing patterns to improve application performance.


MediatR
-IRequest interface
-Handler, inherits from IQuestHandler<TRequest, TResponse>
	public interface ICommand<TResult> : IRequest<TResult>{}
	public interface IQuery<TResult> : IRequest<TResult>{}
	

43.
EShop Microservices Pipeline Behaviors
-LogBehavior
-ValidatorBehavior
	
46. 
install MeditR package 14.1.0
C:\CodeUdemy\MehmetOzkaya\EShopMicroservices\src\BuildingBlocks\BuildingBlocks\BuildingBlocks.csproj

47.Eshop Microservices uses BuildingBlocks Library
	Solution > Add Solutio Folder "BuildingBlocks",
	Add Class library
  
<ItemGroup>
    <PackageReference Include="MediatR" Version="14.1.0" />
</ItemGroup>

50.Carter Lbrary for Minimal Api Endpoint Definition	
	https://github.com/CarterCommunity/Carter
	install Carter package 8.2.1
	C:\CodeUdemy\MehmetOzkaya\EShopMicroservices\src\BuildingBlocks\BuildingBlocks\BuildingBlocks.csproj
51.Post Endpoint with Carter implements ICarterModue for Minimal Apis
	C:\CodeUdemy\MehmetOzkaya\EShopMicroservices\src\Services\Catalog\Catalog.API\Products\CreateProduct\CreateProductEndpoint.cs

	https://github.com/MapsterMapper/Mapster
	install Mapster package 7.4.0
	C:\CodeUdemy\MehmetOzkaya\EShopMicroservices\src\BuildingBlocks\BuildingBlocks\BuildingBlocks.csproj

52.
	C:\CodeUdemy\MehmetOzkaya\EShopMicroservices\src\Services\Catalog\Catalog.API\GlobalUsing.cs
	global using Carter;
	global using Mapster;
	global using MediatR;

53.
	C:\CodeUdemy\MehmetOzkaya\EShopMicroservices\src\Services\Catalog\Catalog.API\Program.cs
	
54.
Got 404 error from Postman
remove Carter from Building Blocks and install for Catalog microservices

----------------------------------------------------------------------------------------------
Sectio 6.Develop Catalog.API Infrastructure, Handler and Endpoint
55. Introduction - Develop Catalog.API Infrastructure, Handler and Endpoint Classes