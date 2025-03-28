using System;
using Microsoft.EntityFrameworkCore;
using GameStoreApi.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;
namespace GameStoreApi.Data;


public class GameStoreContext(DbContextOptions<GameStoreContext> Options) : DbContext(Options)
{
    // They Are same:
    //public class GameStoreContext(DbContextOptions<GameStoreContext> Options) : DbContext(Options)
    //public GameStoreContext(DbContextOptions<GameStoreContext> options): base (options){}

    

    //public DbSet<Game> Games=>Set<Game>(); // === public DbSet<Game> Games { get; set; }
    public DbSet<Game> Games { get; set; }
    //public DbSet<Gener> Geners=>Set<Gener>();
    public DbSet<Gener> Geners {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //This code will be execute when data migration is performed successfully

        //This is static data will by inserted when the table Gener is created
        modelBuilder.Entity<Gener>().HasData(
            new{ID = 1 , Name="Fighting"},
            new{ID = 2 , Name="Roleplaying"},
            new{ID = 3 , Name="Sports"},
            new{ID = 4 , Name="Racing"},
            new{ID = 5 , Name="Kids and Family"}
        );
    }
}
