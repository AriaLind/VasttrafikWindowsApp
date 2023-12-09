namespace VasttrafikAppTest.Models.DepartureModels;

public class Line
{
    public string gid { get; set; }
    public string name { get; set; }
    public string shortName { get; set; }
    public string designation { get; set; }
    public string backgroundColor { get; set; }
    public string foregroundColor { get; set; }
    public string borderColor { get; set; }
    public string transportMode { get; set; }
    public string transportSubMode { get; set; }
    public bool isWheelchairAccessible { get; set; }
}