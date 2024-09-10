## DotNet
- `dotnet add package <packageName> --version <versionNumber>`, add NuGet package to dotnet project
- `dotnet list package`, list all nuget package
- `dotnet run`, start current application
    * swagger will be host on `$hostpath/swagger/index.html`
- `dotnet watch run`, start the swagger webpage in default browser automatically

## Database
Get datasource in string by executing sql script below in SQL server client SSMS.
```
select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name()
```

#### Create database tables from Entity Framework context in Visual Studio
go to package manager console 
```
add-migration "CardMigrate" // the model name
update-database
```
build the migration code to generate controller with selected model and dbcontext using entity framework

#### Migrate database from dotnet CLI
```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef database update
```
