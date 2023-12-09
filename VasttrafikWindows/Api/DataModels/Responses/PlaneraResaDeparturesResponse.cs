namespace VasttrafikWindows.Api.DataModels.Responses;

public class PlaneraResaDeparturesResponse
{
    public List<Result> results { get; set; }
    public Pagination pagination { get; set; }
    public Links links { get; set; }
}