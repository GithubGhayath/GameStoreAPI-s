using GameStoreApi.Data;
using GameStoreApi.GameEndPoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//This line for get connections string from appsettings.json
var ConectionString=builder.Configuration.GetConnectionString("GameStore");

//This line for add create service and pass conections string to appContext class
// They Are same:

builder.Services.AddSqlite<GameStoreContext>(ConectionString);
//builder.Services.AddDbContext<GameStoreContext>(options => options.UseSqlite(ConectionString));


//To do migration we need to install "detnet ef" package and this package "Microsoft.EntityFrameworkCore.Design "
//Migration is the process of converting C# model classes into a relational database structure 
// that includes tables representing these models and the relationships between them.
/*
     Common Commands
                                            Command                         	                    Description
                dotnet ef migrations add MigrationName --output-dir MigrationsPath	            Creates a new migration
                                    dotnet ef database update	                                Applies migrations to the database
                                    dotnet ef migrations remove	                                Removes the last migration
                                    dotnet ef migrations list	                                Lists all migrations
                                    dotnet ef database update LastGoodMigration	                Rolls back to a specific migration
*/
var app = builder.Build();
app.MapGamesEndpoints();
app.MigrateDb();
app.Run();

