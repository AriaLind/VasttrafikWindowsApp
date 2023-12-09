namespace VasttrafikAppTest.Models.Geografi.StopPoints;

public class StopPointsResponse
{
    public Links links { get; set; }
    public Properties properties { get; set; }
    public List<StopPoint> stopPoints { get; set; }
}