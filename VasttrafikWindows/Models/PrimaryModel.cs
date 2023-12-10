using System.Collections.ObjectModel;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Api.DataModels;
using VasttrafikWindows.Api.DataModels.Responses;
using VasttrafikWindows.Api.Deserializers;
using VasttrafikWindows.Commands;

namespace VasttrafikWindows.Models;

public class PrimaryModel
{
    public string _geografiStopPointOutputString;
    public string _geografiStopPointEndPointString;

    public string _planeraResaDepartuesEndPointString;
    public string _planeraResaOutputString;

    public ObservableCollection<StopArea> _geografiStopAreaCollection = new();

    public async void InitializeStopAreaCollection()
    {
        var stopAreas = await GeografiGetRequests.GeografiGetRequest("/StopAreas");
        var stopAreasDeserialized = GeografiDeserializer.StopAreaDeserializer(stopAreas);

        foreach (var stopArea in stopAreasDeserialized.stopAreas)
        {
            _geografiStopAreaCollection.Add(stopArea);
        }
    }

}