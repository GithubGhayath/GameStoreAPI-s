
using GameStoreApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApp.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> Options) :DbContext(Options)
    {
       public DbSet<Game> Games { get; set; }
       public DbSet<Gener> Geners { get; set; }
    }
}
