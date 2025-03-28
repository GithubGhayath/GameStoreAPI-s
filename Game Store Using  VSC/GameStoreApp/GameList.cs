using GameStoreApp.Dtos;

namespace GameStoreApp
{
    public class GameList
    {
        public static readonly List<GameSummaryDto> Games = new List<GameSummaryDto>
        {
            new GameSummaryDto(1, "The Legend of Zelda: Breath of the Wild", "Adventure", 59.99m, new DateOnly(2017, 3, 3)),
            new GameSummaryDto(2, "Minecraft", "Kids and Family", 99.99m, new DateOnly(2002, 2, 2)),
            new GameSummaryDto(3, "Elden Ring", "Action RPG", 69.99m, new DateOnly(2022, 2, 25)),
            new GameSummaryDto(4, "God of War: Ragnarok", "Action", 79.99m, new DateOnly(2022, 11, 9)),
            new GameSummaryDto(5, "Super Mario Odyssey", "Platformer", 49.99m, new DateOnly(2017, 10, 27)),
            new GameSummaryDto(6, "Cyberpunk 2077", "RPG", 39.99m, new DateOnly(2020, 12, 10)),
            new GameSummaryDto(7, "Grand Theft Auto V", "Open World", 29.99m, new DateOnly(2013, 9, 17)),
            new GameSummaryDto(8, "Red Dead Redemption 2", "Open World", 59.99m, new DateOnly(2018, 10, 26)),
            new GameSummaryDto(9, "Hollow Knight", "Metroidvania", 14.99m, new DateOnly(2017, 2, 24)),
            new GameSummaryDto(10, "Stardew Valley", "Simulation", 14.99m, new DateOnly(2016, 2, 26))
        };

     
    }
}
