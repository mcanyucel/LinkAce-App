using System.Text.Json.Serialization;

namespace LinkAce_Mobile.Models;

internal sealed record LinkAceList(
    [property: JsonPropertyName("id")] 
    int Id,
    [property: JsonPropertyName("user_id")]
    int UserId,
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("description")]
    string Description,
    [property: JsonPropertyName("created_at")]
    DateTime CreatedAt,
    [property: JsonPropertyName("updated_at")]
    DateTime UpdatedAt,
    [property: JsonPropertyName("deleted_at")]
    DateTime? DeletedAt,
    [property: JsonPropertyName("links")]
    string Links
    );
