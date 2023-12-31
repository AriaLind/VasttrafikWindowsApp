﻿using System.Text.Json;
using VasttrafikWindows.Api.DataModels.Responses;

namespace VasttrafikWindows.Api.Deserializers;

public class GeografiDeserializer
{
    public static GeografiStopPointsResponse StopPointDeserializer(string json)
    {
        var response = JsonSerializer.Deserialize<GeografiStopPointsResponse>(json);
        return response;
    }

    public static GeografiStopAreaResponse StopAreaDeserializer(string json)
    {
        var response = JsonSerializer.Deserialize<GeografiStopAreaResponse>(json);
        return response;
    }
}