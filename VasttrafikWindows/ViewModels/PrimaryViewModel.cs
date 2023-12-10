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

    public string PlaneraResaOutputString
    {
        get => _primaryModel._planeraResaOutputString;
        set => SetProperty(ref _primaryModel._planeraResaOutputString, value);
    }

    public ObservableCollection<StopArea> StopAreaCollection
    {
        get => _primaryModel.GeografiStopAreaCollection;
        set => _primaryModel.GeografiStopAreaCollection = value;
    }

    public IRelayCommand GeografiStopPointsOutputCommand { get; set; }
    public IRelayCommand PlaneraResaStopPointsOutputCommand { get; set; }
}