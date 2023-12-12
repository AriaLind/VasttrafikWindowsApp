using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Api.DataModels;
using VasttrafikWindows.Api.DataModels.Responses;
using VasttrafikWindows.Api.Deserializers;
using VasttrafikWindows.Commands;
using VasttrafikWindows.Models;

namespace VasttrafikWindows.ViewModels;

public class PrimaryViewModel : ObservableObject
{
    private readonly PrimaryModel _primaryModel;

    List<GeografiStopAreaResponse> _stopAreas;

    public PrimaryViewModel()
    {
        _primaryModel = new PrimaryModel();

        _primaryModel.InitializeStopAreaCollection();

        GeografiStopPointsOutputCommand = new GeografiGetStopAreaCommand(_primaryModel, this);
        PlaneraResaStopPointsOutputCommand = new PlaneraResaGetDeparturesCommand(_primaryModel, this);
        
    }

    public string GeografiEndPointInputString
    {
        get => _primaryModel._geografiStopPointEndPointString;
        set => SetProperty(ref _primaryModel._geografiStopPointEndPointString, value);
    }

    public string GeografiOutputString
    {
        get => _primaryModel._geografiStopPointOutputString;
        set => SetProperty(ref _primaryModel._geografiStopPointOutputString, value);
    }

    public string PlaneraResaEndPointInputString
    {
        get => _primaryModel._planeraResaDepartuesEndPointString;
        set => SetProperty(ref _primaryModel._planeraResaDepartuesEndPointString, value);
    }

    public string DeparturesString
    {
        get => _primaryModel._planeraResaOutputString;
        set => SetProperty(ref _primaryModel._planeraResaOutputString, value);
    }

    public ObservableCollection<StopArea> StopAreaCollection
    {
        get => _primaryModel.GeografiStopAreaCollection;
        set => _primaryModel.GeografiStopAreaCollection = value;
    }

    public StopArea SelectedStopArea
    {
        get => _primaryModel._selectedStopArea;
        set
        {
            SetProperty(ref _primaryModel._selectedStopArea, value);
            ShowDepartures();
        } 
    }

    public List<Result> SelectedStopAreaDepartures
    {
        get => _primaryModel._selectedStopAreaDepartures;
        set => SetProperty(ref _primaryModel._selectedStopAreaDepartures, value);
    }

    public async void ShowDepartures()
    {
        var jsonResponse = await PlaneraResaGetRequest.GetStopAreaDepartures(SelectedStopArea.gid);
        var departuresResponse = PlaneraResaDeserialization.DeparturesDeserializer(jsonResponse);

        SelectedStopAreaDepartures = new List<Result>();
        foreach (var departure in departuresResponse.results)
        {
            SelectedStopAreaDepartures.Add(departure);
        }
    }

    public IRelayCommand ShowDepartureCommand { get; set; }
    public IRelayCommand GeografiStopPointsOutputCommand { get; set; }
    public IRelayCommand PlaneraResaStopPointsOutputCommand { get; set; }
}