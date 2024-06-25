using LinkAce_Mobile.Models;
using System.Text.Json.Serialization;


namespace LinkAce_Mobile.Repositories.ResponseModels;

internal sealed record LinkResponse(

    [property: JsonPropertyName("current_page")]
    int CurrentPage,

    [property: JsonPropertyName("data")]
    List<LinkAceLink> Data,

    [property: JsonPropertyName("from")]
    int From,

    [property: JsonPropertyName("to")]
    int To,

    [property: JsonPropertyName("total")]
    int Total
    );