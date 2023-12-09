namespace VasttrafikWindows.Api.DataModels;

public class Result
{
    public string detailsReference { get; set; }
    public ServiceJourney serviceJourney { get; set; }
    public StopPoint stopPoint { get; set; }
    public string plannedTime { get; set; }
    public string estimatedTime { get; set; }
    public string estimatedOtherwisePlannedTime { get; set; }
    public bool isCancelled { get; set; }
    public bool isPartCancelled { get; set; }
    public Occupancy occupancy { get; set; }
}