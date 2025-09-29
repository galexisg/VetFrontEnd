using System.Text.Json.Serialization;
namespace Veterinaria.MAUIApp.Models.Dtos;

public class PagedResult<T>
{
    [JsonPropertyName("content")]
    public List<T> Content { get; set; } = new(); // Valor inicial

    [JsonPropertyName("totalPages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("totalElements")]
    public long TotalElements { get; set; }

    [JsonPropertyName("number")]
    public int PageNumber { get; set; }
}