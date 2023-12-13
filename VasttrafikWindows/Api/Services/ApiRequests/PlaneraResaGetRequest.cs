using System.Net.Http.Headers;
using System.Net.Http;

namespace VasttrafikAppTest.VasttrafikAPI;

public class PlaneraResaGetRequest
{
    private static string Url => "https://ext-api.vasttrafik.se/pr/v4";

    private static string AccessToken { get; set; }

    public static async Task<string> GetStopAreaDepartures(string stopAreaGid)
    {
        string currentDateTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        var endPoint = $"/stop-areas/{stopAreaGid}/departures?startDateTime={currentDateTime}";
        AccessToken = await GenerateAcessToken.GenerateToken();
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            var apiResponse = await httpClient.GetAsync(Url + endPoint);

            if (apiResponse.IsSuccessStatusCode)
            {
                var apiResponseContent = await apiResponse.Content.ReadAsStringAsync();
                return apiResponseContent;
            }
            else
            {
                return apiResponse.StatusCode.ToString();
            }
        }
    }
}