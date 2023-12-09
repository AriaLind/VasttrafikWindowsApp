using System.Windows.Media;

namespace VasttrafikWindows.Api.DataModels;

public class TariffZone
{
    public string gid { get; set; }
    public string name { get; set; }
    public string shortName { get; set; }
    public int number { get; set; }
    public string code { get; set; }
    public System.Windows.Media.Geometry geometry { get; set; }
    public DateTime validFromDate { get; set; }
    public DateTime validUpToDate { get; set; }
}