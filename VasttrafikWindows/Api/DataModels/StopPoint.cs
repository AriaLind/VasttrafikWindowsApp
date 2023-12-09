using System.Windows.Media;

namespace VasttrafikWindows.Api.DataModels;

public class StopPoint
{
    public string gid { get; set; }
    public string stopAreaGid { get; set; }
    public int stopAreaNumber { get; set; }
    public int number { get; set; }
    public string name { get; set; }
    public string shortName { get; set; }
    public string abbreviation { get; set; }
    public string platform { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public string designation { get; set; }
    public int localNumber { get; set; }
    public Municipality municipality { get; set; }
    public List<TariffZone> tariffZones { get; set; }
    public TransportAuthority transportAuthority { get; set; }
}

