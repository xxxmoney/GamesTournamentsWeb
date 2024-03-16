# Database Access Project

# Migrations
Firstly cahnge directory to the `GamesTournamentsWeb.DataAccess` folder in the terminal by using:
- `cd .\GamesTournamentsWeb.DataAccess\`

Then run one of the following commands based on usage:

- Add-Migration
    - `dotnet ef migrations add InitialCreate --startup-project ../GamesTournamentsWeb.Web/GamesTournamentsWeb.Web.csproj`
- Update-Database
    - `dotnet ef database update --startup-project ../GamesTournamentsWeb.Web/GamesTournamentsWeb.Web.csproj`
- Remove-Migration
    - `dotnet ef migrations remove --startup-project ../GamesTournamentsWeb.Web/GamesTournamentsWeb.Web.csproj`
- Revert-Migration
    - `dotnet ef database update <MigrationName | MigrationIndex (use 0 for full reset)> --startup-project ../GamesTournamentsWeb.Web/GamesTournamentsWeb.Web.csproj`  
