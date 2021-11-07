# Coin Jar Coding Challenge

## Architecture and layering
I went with a CQRS (Command and Query Responsibility Segregation) and Mediator pattern.
My application is split into three layers - Application, Infrastructure and WebAPI.

I used in-memory caching for persistence.

Swagger is used for API documentation ({baseURL}/swagger/index.html). Must run in Debug mode to access Swagger.

The max volume of the jar can be set in appsettings.json. Default is set to 42 as instructed.

### Application
This layer contains application logic. It defines interfaces which are implemented by the Infrastructure
layer. ICoinJar is found here but not the implementation.

### Infrastructure
Contains classes for accessing external resources such as files or database systems. Creates
implementations for interfaces found in the Application layer. ICoinJar and persistence (memory cache) is implemented here.

### WebAPI
API layer. Contains controller actions which simply sends a mediator request to the Application layer and returns
an appropriate response.

### Testing
I added some unit tests for exceptions in the Application layer.
I also created integration tests for my commands and queries in the Application layer.

## Building and running

### Prerequisites

- .NET 5 runtime or SDK must be installed on the host machine in order to run the application   
<https://dotnet.microsoft.com/download/dotnet/5.0>

### Commands

- Before attempting to build, run or test execute the following command (**in the root of the project**):     
``dotnet restore``

- To build:   
``dotnet build``

- To run tests:  
``dotnet test --verbosity normal``

- To run:  
``dotnet run --configuration Debug --project src/WebAPI/WebAPI.csproj``

- Swagger endpoint for testing API calls:
http://localhost:5000/swagger/index.html
