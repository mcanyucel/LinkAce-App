using System.Text.Json.Serialization;

namespace LinkAce_Mobile.Models;

internal sealed record LinkAceTag(
    [property: JsonPropertyName("id")]
    int Id, 
    [property: JsonPropertyName("user_id")]
    int UserId,
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("is_private")]
    bool IsPrivate,
    [property: JsonPropertyName("created_at")]
    DateTime CreatedAt,
    [property: JsonPropertyName("updated_at")]
    DateTime UpdatedAt,
    [property: JsonPropertyName("deleted_at")]
    DateTime? DeletedAt
    );