using System;

namespace GameStoreApi.Entities;

public class Game
{
    public int GameID { get; set; }
    public required string Name { get; set; }
    public int GenerID { get; set; }
    public Gener? Gener { get; set; }
    public double Price { get; set; }
    public DateOnly ReleasDate { get; set; }
}
