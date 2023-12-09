namespace VasttrafikWindows.Api.DataModels.Responses;

public class GeografiStopPointsResponse
{
    public Links links { get; set; }
    public Properties properties { get; set; }
    public List<StopPoint> stopPoints { get; set; }
}