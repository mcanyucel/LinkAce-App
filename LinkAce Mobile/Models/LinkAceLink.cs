using System.Text.Json.Serialization;

namespace LinkAce_Mobile.Models;

internal sealed record LinkAceLink(
    [property: JsonPropertyName("id")]
    int Id,
    [property: JsonPropertyName("user_id")]
    int UserId,
    [property: JsonPropertyName("title")]
    string Title,
    [property: JsonPropertyName("url")]
    string Url,
    [property: JsonPropertyName("description")]
    string Description,
    [property: JsonPropertyName("icon")]
    string Icon,
    [property: JsonPropertyName("thumbnail")]
    string Thumbnail,
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
