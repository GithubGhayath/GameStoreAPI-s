﻿namespace GameStoreApp.Dtos
{
    public record class GameSummaryDto(int Id,string Name,string Gener,decimal Price,DateOnly ReleasDate);
   
}
