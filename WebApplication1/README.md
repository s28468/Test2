```
git clone 
```
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
download .net

connect to db
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
