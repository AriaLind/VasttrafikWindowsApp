using System.Text.Json;
using VasttrafikWindows.Api.DataModels.Responses;

namespace VasttrafikWindows.Api.Deserializers;

public class PlaneraResaDeserialization
{
    public static PlaneraResaDeparturesResponse DeparturesDeserializer(string json)
    {
        if (!json.StartsWith("{"))
        {
            return null;
        }
        var response = JsonSerializer.Deserialize<PlaneraResaDeparturesResponse>(json);
        return response;
    }
}