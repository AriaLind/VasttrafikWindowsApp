using System.Net.Http;
using System.Net.Http.Headers;

namespace VasttrafikAppTest.VasttrafikAPI;

public class GeografiGetRequests
{
    private static string Url => "https://ext-api.vasttrafik.se/geo/v2";

    private static string AccessToken { get; set; }

    public static async Task<string> GetStopPoints(string endPoint)
    {
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
                return $"Error making API request: {apiResponse.StatusCode}";
            }
        }
    }
}