using System.Collections.ObjectModel;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Api.DataModels;
using VasttrafikWindows.Api.Deserializers;

namespace VasttrafikWindows.Models;

public class PrimaryModel
{
    public StopArea _selectedStopArea;
    public ObservableCollection<Result> _selectedStopAreaDepartures;
    public ObservableCollection<StopArea> _filteredStopAreas = new();

    public string _searchBoxText;

    public ObservableCollection<StopArea> GeografiStopAreaCollection { get; set; }

    public PrimaryModel()
    {
        GeografiStopAreaCollection = new();
    }
    public async void InitializeStopAreaCollection()
    {
        var stopAreas = await GeografiGetRequests.GeografiGetRequest("/StopAreas");
        var stopAreasDeserialized = GeografiDeserializer.StopAreaDeserializer(stopAreas);
        var distinctStopAreas = stopAreasDeserialized.stopAreas.GroupBy(s => s.gid).Select(g => g.First()).ToList();

        GeografiStopAreaCollection = new ObservableCollection<StopArea>(distinctStopAreas);
    }

    public async Task<List<StopArea>> RefreshFilteredStopAreaList()
    {
        var stopAreas = await GeografiGetRequests.GeografiGetRequest("/StopAreas");
        var stopAreasDeserialized = GeografiDeserializer.StopAreaDeserializer(stopAreas);
        var distinctStopAreas = stopAreasDeserialized.stopAreas.GroupBy(s => s.gid).Select(g => g.First()).ToList();

        return distinctStopAreas;
    }

    public ObservableCollection<StopArea> FilterStops()
    {
        if (_searchBoxText == null || _searchBoxText == string.Empty)
        {
            return _filteredStopAreas = new ObservableCollection<StopArea>(GeografiStopAreaCollection);
        }
        var filteredStopAreas = GeografiStopAreaCollection.Where(s => s.name.ToLower().Contains(_searchBoxText.ToLower())).ToList();

        // Create a new instance of _filteredStopAreas and add the filtered items
        return _filteredStopAreas = new ObservableCollection<StopArea>(filteredStopAreas);
    }

}