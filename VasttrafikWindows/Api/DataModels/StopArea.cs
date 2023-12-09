namespace VasttrafikWindows.Api.DataModels;

public class StopArea
{
    public string gid { get; set; }
    public int number { get; set; }
    public string name { get; set; }
    public string shortName { get; set; }
    public string abbreviation { get; set; }
    public Municipality municipality { get; set; }
    public List<TariffZone> tariffZones { get; set; }
    public int interchangePriorityLevel { get; set; }
    public TransportAuthority transportAuthority { get; set; }
    public string interchangePriorityMessage { get; set; }
    public int defaultInterchangeDurationSeconds { get; set; }
    public Geometry geometry { get; set; }
    public DateTime validFromDate { get; set; }
    public DateTime validUpToDate { get; set; }
    public List<StopPoint> stopPoints { get; set; }
}