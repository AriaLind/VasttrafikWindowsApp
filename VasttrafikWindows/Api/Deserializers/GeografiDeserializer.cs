using System.Text.Json;
using VasttrafikWindows.Api.DataModels.GeografiStopPoints;

namespace VasttrafikWindows.Api.Deserializers;

public class GeografiDeserializer
{
    public static StopPointsResponse StopPointDeserializer(string json)
    {
        var response = JsonSerializer.Deserialize<StopPointsResponse>(json);
        return response;
    }
}