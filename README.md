# MVCAssignment

Add secrets.json and change the password to match the sql server password instead of <secret_key>. 

## EF Migrations

For first time migration, cd to the ``Infrastructure`` directory and do
```bash 
dotnet ef migrations add InitialCreate -o Migrations --startup-project ../MovieApp/MovieApp.csproj
```

where ``InitialCreate`` is the name of the migration. 

For each further migration do 
```bash
dotnet ef migrations add <MigrationName> -o Migrations --startup-project ../MovieApp/MovieApp.csproj
```
where you replace ``<MigrationName>`` with the name.

After each migration add do:
``` bash
dotnet ef database update --startup-project ../MovieApp/MovieApp.csproj 
```
to update the migrations

After updating, make sure to look at the ``.cs`` file created in ``/Migrations`` to see if it looks decently full of stuff. If not, there might be errors or other things that needs to be fixed in the code like I experienced before.


