#HR MANAGER

A simple API project written for demonstration purposes only.
Stack: C# + NET Core + EntityFramework Core + SQL

What and why i use:
C# -> I feel most confident in this language
NET -> I mainly focus on writing applications/APIs that work with frontend frameworks/libraries.
Microsoft SQL Server -> It's very popular database solution for Windows applications. I usually work with MongoDB.

Onion Architecture -> It facilitates the process of creating applications that will grow over time.   In this application it is not needed, but for demonstration purposes I decided to prepare an example.

MediatR -> Make it easy you to create small controllers
FluentValidation -> Make it easy to validate data in app.
Entity Framework Core -> Most popular ORM for SQL.

To use this project you should
Install Visual Studio 2022
Install SQL server and fill your connection string to appsetting json.
Type `update-database` inside nuget console
Run the project

To use the api, the browser will ask you for a password:
login: "login" 
password: "password"  
Of course, you shouldn't hardcode your login and password, but it's a simplification for the purposes of this demonstration.



TODO: 
* Make tests for app.
* Save users inside databse.
* Some awesome features.