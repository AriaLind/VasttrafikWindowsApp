namespace VasttrafikWindows.Api.DataModels;

public class Geometry
{
    public string wkt { get; set; }
    public int srid { get; set; }
    public string coordinateSystemName { get; set; }
    public double northingCoordinate { get; set; }
    public double eastingCoordinate { get; set; }
}