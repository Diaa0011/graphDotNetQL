# GraphDotNetQL
This project is built upon Les Jackson's tutorial on GraphQL API with .NET 5 and Hot Chocolate. You can watch the tutorial video [here](https://www.youtube.com/watch?v=HuN94qNwQmM)
<div align="center">
<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Microsoft_.NET_logo.svg/640px-Microsoft_.NET_logo.svg.png" alt=".Net" width="100"/>
<img src="https://github.com/ChilliCream/hotchocolate-logo/blob/master/img/hotchocolate-banner.svg" alt="HotChocolate" width="200"/>
<img src="https://cdn.icon-icons.com/icons2/2699/PNG/512/graphql_logo_icon_171045.png" alt="GraphQL" width="200"/>
<img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTY5mmZmMEmf6eimSHMx2WI_9Yx631cZEpG1w&s" alt="WebSockets" width="150"/>

</div>

## Overview
GraphDotNetQL is a sample project demonstrating how to build a GraphQL API with .NET, featuring CRUD operations, filtering, sorting, and subscriptions.
The project showcases various GraphQL capabilities using .NET technologies, including:
* GraphQL Voyager integration
* Entity relationships and projections
* WebSocket-based subscriptions for real-time updates
* Command and Platform models with corresponding mutations and queries

## Application Architecture
![image](https://github.com/user-attachments/assets/5b648b65-818f-4bf4-8706-bf01395e81b9)


## Features

### Initial Commit to GraphQL Voyager
* Initial project setup and integration with GraphQL Voyager.
  
### Enhancements and Relations
* Command Model: Added command model with relations to platforms.
* Platform-Command Relations: Applied relationships between the platform and command models.
* Projections & Multi-Requests: Enabled projections and multiple requests using AddPooledDbContextFactory in Program.cs.
* Get All Commands: Added a query method in Query.cs to fetch all commands.
  
### Documentation and Code-First Projections
* Documentation: Added documentation for attributes.
* Command & Platform Types: Initial creation of Command & Platform types.
* Resolvers: Added resolvers for documentation, data retrieval, and ignored the LicenseKey field.
* Code-First Projections: Transitioned from annotation-based projections to code-first in the Types folder.
* Program.cs: Integrated types into Program.cs.

### Filtering, Sorting, and Mutations
* Filtering & Sorting: Applied filtering and sorting annotations in Query.cs for GetCommand and GetPlatform.
* Mutations: Started implementing mutations for Create, Update, and Delete (CRUD) operations.
* Record Types: Created input and payload classes for mutations using record types.

### Subscriptions
* Subscription Support: Implemented GraphQL subscriptions using subscribe and topic annotations in Subscription.cs.
* Event Messaging: Added event messaging to Query.cs to support real-time notifications.
* WebSocket Support: Integrated WebSocket to allow subscription-based real-time updates.

### Finalizing CRUD & Subscriptions
* CRUD Operations: Completed the CRUD operations for platforms and commands, including payloads.
* Subscriptions for CRUD: Added subscriptions for each CRUD operation to monitor real-time updates during runtime.

## Get Started
### Prerequisites
* .NET 6.0 or later
* Entity Framework Core
* GraphQL & HotChocolate
* WebSocket for real-time updates

### Installation
1. Clone the repository:
```
   git clone https://github.com/Diaa0011/graphDotNetQL/
   cd graphDotNetQL
```
2. Install the necessary packages:
```
   dotnet restore
```
4. Run the Project:
```
   dotnet run
```
5. adding migrations and create database
```
   dotnet ef migrations add "database setup" 
```
```
   dotnet ef database update
```
5. Access GraphQL Voyager to explore the API:

GraphQL API:
``` 
   http://localhost:<port>/graphql
```
Voyager API: 
```
   http://localhost:<port>/voyager
```

## Try this Queries: 
*don't forget to put graphql api then make your request POST lastly put the previous code in the body of your request*!
### Mutations
```
//Create a platform
mutation{
	addPlatform(input: {
		name: "FORTRAN"
	})
	{
		platform
		{
			id
			name
		}
	}
}

//Create a command
mutation{
	addCommand(input: {
		howTo: "mkdir"
		commandLine: "creating new file"
		platformId: 13
	})
	{
		command{
			id
			howTo
			commandLine
			platform{
				name
			}
		}
	}
	
}
//Edit a command
mutation{
	editCommand(input:{id:6,commandLine:"add migrations in vs"})
	{
		command{
			id
			howTo
			commandLine
			platform{
				name
			}
		}
	}
}
```
### Queries 
```
//getting all the platforms
query{
	platform{
		id 
		name
	}
}
//getting all the platforms and its commands
query{
	platform
	{
		id
		name
		commands
		{
			id 
			howTo
			commandLine
		}
	}
}

```

## License
This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for more details.





