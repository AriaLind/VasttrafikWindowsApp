namespace VasttrafikWindows.Api.DataModels.PlaneraResaDepartures;

public class PlaneraResaResponse
{
    public List<Result> results { get; set; }
    public Pagination pagination { get; set; }
    public Links links { get; set; }
}