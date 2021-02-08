
# TODO Application API

>**Pre-Requisites:**
  SQL Server

## Environment File
Update the database connection string in appsettings.json

    "ConnectionString": {
    "TaskDB": "Server=localhost;
    Database=TaskDb;
    Trusted_Connection=True;
    Encrypt=True;
    TrustServerCertificate=True;"}

## Setup Database

Open API project in Visual Studio 2019.
Run `update-database –verbose`  by pointing to TODO.DAL project.
It will create the database along with seed data in the server mentioned in appsettings.json.

> To Execute SQL script manually create a database run the InitialTaskDB.sql script under TODO.DAL --> SqlScripts folder

Run the API.

## API Endpoints:
GET API
 - https://host:port/api/tasks
 `It will provide all the available tasks.`
 
POST API
  - https://host:port/api/tasks
  body : `{"name":"New Task","priority":"Low","dueDate":"2021-02-11"}`
`This will insert a new Task.`

PUT API
   - https://host:port/api/tasks/{id}
  body : ` {"name":"Updated New Task","priority":"Low","dueDate":"2021-02-11"}`
`This will update the task details for the respective task id.`

DELETE API
   - https://host:port/api/tasks/{id}
`This will delete the task record for the respective task id.`

>**Out of Scope:
Unit Test.
Authentication.**
