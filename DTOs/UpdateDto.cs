using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.DTOs;

public record class UpdateDto
(

    [Required][StringLength(50)] string Name,
    int GenerID,
    [Range(1, 100)] double Price,
    DateOnly ReleasDate
    );
