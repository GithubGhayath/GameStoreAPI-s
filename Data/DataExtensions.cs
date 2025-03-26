using System;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Data;

public static class DataExtensions
{
    //This method is a custom extension that runs database migrations automatically when the application starts.
    public static void MigrateDb(this WebApplication app)
    {
        using var Scop = app.Services.CreateAsyncScope();

        var dbContext = Scop.ServiceProvider.GetRequiredService<GameStoreContext>();

        /*
        ✅ .Migrate() will create the database if it doesn’t exist.
        ✅ It will apply all migrations that haven’t been applied yet.
        ✅ It follows the order of migrations based on __EFMigrationsHistory.
        */
        dbContext.Database.Migrate();
    }
}
