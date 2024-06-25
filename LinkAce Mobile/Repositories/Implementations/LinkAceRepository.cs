using LinkAce_Mobile.Models;
using LinkAce_Mobile.Repositories.ResponseModels;
using LinkAce_Mobile.Services;
using Serilog.Core;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LinkAce_Mobile.Repositories.Implementations
{
    internal sealed class LinkAceRepository : ILinkRepository
    {

        public LinkAceRepository(IPreferenceService p_PreferenceService)
        {
            preferenceService = p_PreferenceService;
            baseUrl = preferenceService.GetPreferenceStringSync(preferenceService.UrlKey) ?? string.Empty;
            token = preferenceService.GetPreferenceStringSync(preferenceService.TokenKey) ?? string.Empty;

            if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(token))
            {
                logger.Error("BaseUrl or Token is empty, cannot create repository");
                throw new Exception("BaseUrl or Token is empty, cannot create repository");
            }

            // strip trailing slash if any
            if (baseUrl.EndsWith('/'))
            {
                baseUrl = baseUrl[..^1];
            }

            httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<IEnumerable<LinkAceLink>> GetAllLinks()
        {
            var response = await httpClient.GetAsync(linksEndpoint);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<LinkResponse>(content, jsonSerializerOptions);

            if (responseData == null)
            {
                logger.Error("Failed to deserialize response from server");
                throw new Exception("Failed to deserialize response from server");
            }

            return responseData.Data;
        }


        


        readonly string baseUrl;
        readonly HttpClient httpClient;
        readonly IPreferenceService preferenceService;
        readonly string token;
        readonly Logger logger = App.Current.Logger;
        readonly JsonSerializerOptions jsonSerializerOptions = new()
        {

            UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
        };

        const string linksEndpoint = "/api/v1/links";
    }
}
