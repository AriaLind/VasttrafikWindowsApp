using System.Collections.ObjectModel;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Api.DataModels;
using VasttrafikWindows.Api.DataModels.Responses;
using VasttrafikWindows.Api.Deserializers;
using VasttrafikWindows.Commands;
using VasttrafikWindows.ViewModels;

namespace VasttrafikWindows.Models;

public class PrimaryModel
{
    public string _geografiStopPointOutputString;
    public string _geografiStopPointEndPointString;

    public string _planeraResaDepartuesEndPointString;
    public string _planeraResaOutputString;

    public StopArea _selectedStopArea;
    public List<Result> _selectedStopAreaDepartures;

    public ObservableCollection<StopArea> GeografiStopAreaCollection = new();

    public async void InitializeStopAreaCollection()
    {
        var stopAreas = await GeografiGetRequests.GeografiGetRequest("/StopAreas");
        var stopAreasDeserialized = GeografiDeserializer.StopAreaDeserializer(stopAreas);
        var distinctStopAreas = stopAreasDeserialized.stopAreas.GroupBy(s => s.gid).Select(g => g.First());

        foreach (var stopArea in distinctStopAreas)
        {
            GeografiStopAreaCollection.Add(stopArea);
        }
    }

    

}