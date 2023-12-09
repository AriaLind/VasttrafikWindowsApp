using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace VasttrafikAppTest.VasttrafikAPI;

public static class GenerateAcessToken
{
    public static string tokenUrl { get; set; } = "https://ext-api.vasttrafik.se/token";
    public static string clientId { get; set; } = "avalWbKcFiL5NoGh6ovHHrpsQrsa";
    public static string clientSecret { get; set; } = "YltwpQA23FUGmrc7k3E3j3TTs5ga";
    public static string scope { get; set; } = "device_1";

    public static async Task<String> GenerateToken()
    {
        using (var httpClient = new HttpClient())
        {
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
            var tokenRequestContent = new StringContent($"grant_type=client_credentials&scope={scope}", Encoding.UTF8, "application/x-www-form-urlencoded");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            var tokenResponse = await httpClient.PostAsync(tokenUrl, tokenRequestContent);

            if (!tokenResponse.IsSuccessStatusCode)
            {
                return $"Error obtaining access token: {tokenResponse.StatusCode}";
            }

            var tokenResponseContent = await tokenResponse.Content.ReadAsStringAsync();
            return tokenResponseContent.Split('"')[3]; // Extracting access_token from JSON response
        }
    }
}