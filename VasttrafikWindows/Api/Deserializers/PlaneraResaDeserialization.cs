using System.Text.Json;
using VasttrafikWindows.Api.DataModels.Responses;

namespace VasttrafikWindows.Api.Deserializers;

public class PlaneraResaDeserialization
{
    public static PlaneraResaDeparturesResponse DeparturesDeserializer(string json)
    {
        var response = JsonSerializer.Deserialize<PlaneraResaDeparturesResponse>(json);
        return response;
    }
}