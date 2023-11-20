# VOYAGES APP: REACT+APOLLO, GRAPHQL, API REST


## DESCRIPTION:

This project is a web application for a travel agency that shows information about its clients' trips. It is a demo to show the operation of a complex architecture, composed of a React website with Bootstrap and Apollo, a GraphQL server (.Net Core) and several REST API services (.Net Core). The website, through a GraphQL Apollo client, obtains the data from the GraphQL server, which in turn makes several queries to the REST API services, which internally have a layer structure (Presentation, Domain, Data Access) and which obtain the data from an SQLite database. It includes Unit Tests.



## QUICK START (DOCKER):

* 1º Download project from Github.
* 2º Open Terminal in the project root path.
* 3º Run the following commands in the Terminal to create the Docker images and run the containers of the 3 parts that compose the project (replace <root_directory> with the root directory):

  ` docker-compose build `
 
  ` docker run --rm -d -p 1000:1000/tcp <root_directory>-server.webapi:latest `
 
  ` docker run --rm -d -p 2000:2000/tcp <root_directory>-server.graphqlapi:latest `
 
  ` docker run --rm -d -p 3000:3000/tcp <root_directory>-client.react:latest `


* 4º Open the React Web Application from the web browser at the following URL: ` http://localhost:3000 ` 

  Enter the following test data and press Search/Rechercher:

  * Name/Prénom: Jean, Last Name/Nom: Monet

  * Name/Prénom: Pierre, Last Name/Nom: Moulin


* 5º Make requests to the GraphQL Server from the web browser at the following URL: ` http://localhost:2000/graphql `

  Example query:
  
  >     query Client($name: String, $lastname: String){
  > 
  >     client(name:$name, lastname:$lastname){
  > 
  >     name,
  > 
  >     lastName,
  > 
  >     id,
  > 
  >     file 
  >
  >     { 
  >
  >       id, 
  >
  >       type, 
  >
  >       product 
  >
  >       { 
  >
  >         id, 
  >
  >         description, 
  >
  >         photoLink
  > 
  >       }
  > 
  >     }
  > 
  >     }
  > 
  >     }
  > 
  

  Example query variables:
  
  >     {
  > 
  >     "name": "Jean",
  > 
  >     "lastname": "Monet"
  > 
  >     }
  > 

* 6º Make requests to the REST API Services from the web browser to the following example URLs:

  ` http://localhost:1000/Voyage/GetClientByName/Jean/Monet `
  
  ` http://localhost:1000/Voyage/GetClient/2 `
  
  ` http://localhost:1000/Voyage/GetFile/1 `
  
  ` http://localhost:1000/Voyage/GetProduct/2 ` 



## ARCHITECTURE:

The architecture consists of 3 main parts:

* API REST Services (Server):

  * Set of several REST API services that return information about a client, a trip dossier or a product.
  * This application is developed with .Net Core and written in C#.
  * The path where the project that implements the REST API services is located is "/Server/Voyages.WebApi". 
  * The internal architecture is based on the principle of dependency inversion. It makes use of the "/Server/Voyages.Domain" project, which implements the domain layer and includes the different Entities and interfaces of the services and repositories, and also the "/Server/Voyages.SqlDataAccess" project, which implements the data access layer and accesses the database.
  * The database used is SQLite and is located in the path "/Server/Voyages.WebApi/sqlite.db". This database does not need a database manager, but consists only of a file where the data is stored, which is accessed directly from the application. It can be opened with DB Browser for SQLite if you want to edit the data. It contains 3 tables: Clients, Files and Products.
  * The tests associated with the REST API services are located in the project at the path "/Server/Voyages.WebApi.Tests.Unit". There are also Tests associated with the Voyages.Domain project in the project at the path "/Server/Voyages.Domain.Tests.Unit".

* GraphQL Server (Server):

  * GraphQL server that receives joint requests for data from clients, travel dossiers or products, and that internally makes separate requests to the different REST API services, and then returns them in a single response, abstracting the client from the different data sources.
  * This application is developed with .Net Core and written in C#.
  * The path where the project that implements the GraphQL server is located is "/Server/Voyages.GraphQL.Api". 
  * It uses the "/Server/Voyages.Domain" project to have the different Entities, which it receives from the REST API services.

* React Web Application (Client):

  * This web application simulates the operation of a travel agency's website, where the client's name and last name is entered in a form and the application displays the client's information, their trip dossier and the contracted product.
  * This app is developed with React, which uses the Node.js runtime. At the design level, it uses Bootstrap.
  * To obtain the data it uses Apollo, a GraphQL client. With this client makes a single request with the fields it needs to the GraphQL server, and with the data received it renders the form with the client information.
  * The path where it is located is "/Client/Voyages.React".



## OPEN PROJECTS:

* Visual Studio Code

  After downloading the code from Github, open a Terminal and run the following command from the root path of the project to open the 3 parts:

  ` code . `


* Visual Studio (2022)

  After downloading the code from Github, open the solution file "/Server/Voyages.sln" to open all the projects that compose the REST API Services and GraphQL Server parts. The 2 Test projects are also included. The React Web Application part must be opened from Visual Studio Code.



## EXECUTE:

* Using Docker from Terminal (System Terminal or Visual Studio Code Terminal):

  The project includes a docker-compose.yml file in the root directory, which when executed creates the 3 docker images of each of the 3 parts: REST API Services, GraphQL Server and React Web Application. This file refers to the dockerfile files located in "/Server/Voyages.WebApi/", "/Server/Voyages.GraphQL.Api/" and "/Client/Voyages.React/".
  
  The name of the images created will be: <root_directory>-server.webapi, <root_directory>-server.graphqlapi and <root_directory>-client.react
  
  To run this file and create the images, you must use the following command in a Terminal, from the system or from Visual Studio Code (it is essential to have the Docker extension installed), from the root path of the project:

  ` docker-compose build `


  To run the images, created with the previous command, in 3 separate Docker containers, a command must be used for each image, using the image names. Each container will be accessible on a localhost port, and will make requests to the others on the specified ports.

  The commands to execute in a Terminal from the root path are:

  ` docker run --rm -d -p 1000:1000/tcp <root_directory>-server.webapi:latest `
  ` docker run --rm -d -p 2000:2000/tcp <root_directory>-server.graphqlapi:latest `
  ` docker run --rm -d -p 3000:3000/tcp <root_directory>-client.react:latest `

  For example, if the root directory is "Voyages-main" the commands will be:

  ` docker run --rm -d -p 1000:1000/tcp voyages-main-server.webapi:latest `
  ` docker run --rm -d -p 2000:2000/tcp voyages-main-server.graphqlapi:latest `
  ` docker run --rm -d -p 3000:3000/tcp voyages-main-client.react:latest `


* From Visual Studio Code:

  If Docker is installed in Visual Studio Code, from the Visual Studio Code Terminal you can execute the same commands described in the previous section, from the root path of the project.

  Another option is to run each part separately:
  
  * To launch the REST API Services you must run, from the Run And Debug section, the ".NET Core Launch (webapi)" configuration.
  
  * To launch the GraphQL Server you must run, from the Run And Debug section, the ".NET Core Launch (graphQL)" configuration.
  
  * To launch the React Web Application, the following two commands must be executed in the Visual Studio Code Terminal (it is essential to have node.js installed) from the path "/Client/Voyages.React/":
    ` npm install
    ` npm start


* From Visual Studio:

  Once the Solution is opened, the REST API Services or the GraphQL Server can be run with the Debug option on the "Voyages.WebApi" or "Voyages.GraphQL.Api" projects respectively. 



## USE APPLICATION

Once the 3 parts are running, tests can be performed on each of the parts from a web browser.

* React Application Web:

  Open the following URL: ` http://localhost:3000 ` 

  Enter the following test data and press Search/Rechercher:

  * Name/Prénom: Jean, Last Name/Nom: Monet

  * Name/Prénom: Pierre, Last Name/Nom: Moulin


* GraphQL Server:
  Open the following URL: `http://localhost:2000/graphql `
  
  Enter a query and some values for the variables. You can use the following as an example:

  Example query:

  >     query Client($name: String, $lastname: String){
  > 
  >     client(name:$name, lastname:$lastname){
  > 
  >     name,
  > 
  >     lastName,
  > 
  >     id,
  > 
  >     file 
  >
  >     { 
  >
  >       id, 
  >
  >       type, 
  >
  >       product 
  >
  >       { 
  >
  >         id, 
  >
  >         description, 
  >
  >         photoLink
  > 
  >       }
  > 
  >     }
  > 
  >     }
  > 
  >     }
  > 
  

  Example query variables:
  
  >     {
  > 
  >     "name": "Jean",
  > 
  >     "lastname": "Monet"
  > 
  >     }
  > 


* API REST Services:
  
  Open the following example URLs:
  
  ` http://localhost:1000/Voyage/GetClientByName/Jean/Monet `
  
  ` http://localhost:1000/Voyage/GetClient/2 `
  
  ` http://localhost:1000/Voyage/GetFile/1 `
  
  ` http://localhost:1000/Voyage/GetProduct/2 ` 



## UNIT TESTS:

* Visual Studio:

  Once the Solution is opened, the Unit Tests of the REST API Services can be executed with the "Execute Tests" option on the "Voyages.WebApi.Test" or "Voyages.Domain.Test" projects.
  
  
