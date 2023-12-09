namespace VasttrafikWindows.Api.DataModels;

public class ServiceJourney
{
    public string gid { get; set; }
    public string origin { get; set; }
    public string direction { get; set; }
    public Line line { get; set; }
}