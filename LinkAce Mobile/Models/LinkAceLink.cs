using System.Text.Json.Serialization;

namespace LinkAce_Mobile.Models;

internal sealed record LinkAceLink(
    [property: JsonPropertyName("id")]
    string Id,
    [property: JsonPropertyName("user_id")]
    string UserId,
    [property: JsonPropertyName("title")]
    string Title,
    [property: JsonPropertyName("url")]
    string Url,
    [property: JsonPropertyName("description")]
    string Description,
    [property: JsonPropertyName("icon")]
    string Icon,
    [property: JsonPropertyName("created_at")]
    DateTime CreatedAt,
    [property: JsonPropertyName("updated_at")]
    DateTime UpdatedAt,
    [property: JsonPropertyName("deleted_at")]
    DateTime? DeletedAt,
    [property: JsonPropertyName("is_private")]
    bool IsPrivate,
    [property: JsonPropertyName("status")]
    byte Status,
    [property: JsonPropertyName("check_disabled")]
    bool CheckDisabled,
    [property: JsonPropertyName("lists")]
    List<LinkAceList> Lists,
    [property: JsonPropertyName("tags")]
    List<LinkAceTag> Tags
    );
