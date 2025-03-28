using System.ComponentModel.DataAnnotations;


namespace GameStoreApp.Dtos
{
    public record class UpdateGameDto(
        [Required] string Name,
         [Required] int GenerId,
         [Range(18, 100)] decimal Price,
         [Required] DateOnly ReleasDate);
}
