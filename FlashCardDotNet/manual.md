## DotNet
- `dotnet add package <packageName> --version <versionNumber>`, add NuGet package to dotnet project

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

Create database tables from C# models
```
add-migration "CardMigrate" // the model name
update database
```
build the migration code to generate controller with selected model and dbcontext using entity framework
