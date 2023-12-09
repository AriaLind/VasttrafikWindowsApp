namespace VasttrafikWindows.Api.DataModels.Responses;

public class GeografiStopAreaResponse
{
    public Links links { get; set; }
    public Properties properties { get; set; }
    public List<StopArea> stopAreas { get; set; }
}