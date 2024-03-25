Due to time considerations, I haven't been able to complete this as fully as I have wished.

With the refactor, I managed to 
- Create a DDD structure that separated the data, domain and contract concerns
- Implement a repository pattern
- Add dependency injection for scalability and maintainability
- Refactor to use entity framework
- Add logging
- Update to C# 9 where I could (use of primary constructors)

If I had managed to spend more time on this application I would have added:

- Implemented a unit of work pattern for the repository
- Unit testing
- Integration testing
- Angular material UI
- Angular data tables
- A separate auth service with user name / password authentication (a stretch goal)

# BrainWare Order List

This is a very small sample web application written in a very simplistic manner.

Grab the code and refactor it so that it meets your standard for production ready code.

There is no need to add additional functionality and you do not need to keep the existing code or project structure.

The only requirement is that it returns the list of orders and that it meets your standards!

Fork this project to your personal repo and commit all your changes to that branch. 

## Changes for Running Locally

Update the connection string in the class <project root>\Api\Infrastructure\Database.cs.

Change the AttachDbFile name to the full path of the BrainWare.mdf file (located under <project root>\Api\Data\).


## Original Output Example
![page image](output.GIF?raw=true)


## Setup

### Database Setup
- Start SQL Server Management Studio as Administrator
- Once connected to your local SQL Server instance
- Right click on the Database node and select Attach
- Select the file BrainWare\Api\Data\BrainWare.mdf

- You can also deploy the project ProjectDB to your local SQL Server instance
- Then execute in SQL Server Management Studio the file BrainWare\ProjectDB\PopulateDB.sql

### API - Visual Studio
- Open solution BrainWare\BrainWare.sln
- Update the database connection string in file Api\Infrastructure\Database.cs
- Set the project Web, as the start up project
- Press F5

### API - VS Code or Command Line
- Open Brainware folder
- dotnet run --project=./Api

### Web App - VS Code or Command Line
- Open Brainware folder
- cd .\web-app\
- npm install
- npm start
