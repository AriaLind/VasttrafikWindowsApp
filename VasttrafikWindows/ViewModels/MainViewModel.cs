using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Api.DataModels.Responses;
using VasttrafikWindows.Api.Deserializers;
using VasttrafikWindows.Commands;
using VasttrafikWindows.Models;

namespace VasttrafikWindows.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly MainModel _mainModel;

    List<GeografiStopAreaResponse> _stopAreas;

    public MainViewModel()
    {
        _mainModel = new MainModel();


        GeografiStopPointsOutputCommand = new GeografiGetStopAreaCommand(_mainModel, this);
        PlaneraResaStopPointsOutputCommand = new PlaneraResaGetDeparturesCommand(_mainModel, this);
        
    }

    public string GeografiEndPointInputString
    {
        get => _mainModel._geografiStopPointEndPointString;
        set => SetProperty(ref _mainModel._geografiStopPointEndPointString, value);
    }

    public string GeografiOutputString
    {
        get => _mainModel._geografiStopPointOutputString;
        set => SetProperty(ref _mainModel._geografiStopPointOutputString, value);
    }

    public string PlaneraResaEndPointInputString
    {
        get => _mainModel._planeraResaDepartuesEndPointString;
        set => SetProperty(ref _mainModel._planeraResaDepartuesEndPointString, value);
    }

    public string PlaneraResaOutputString
    {
        get => _mainModel._planeraResaOutputString;
        set => SetProperty(ref _mainModel._planeraResaOutputString, value);
    }

    public ObservableCollection<GeografiStopAreaResponse> StopAreaResponseCollection
    {
        get => _mainModel._geografiStopAreaResponseCollection;
        set => _mainModel._geografiStopAreaResponseCollection = value;
    }

    public IRelayCommand GeografiStopPointsOutputCommand { get; set; }
    public IRelayCommand PlaneraResaStopPointsOutputCommand { get; set; }
}