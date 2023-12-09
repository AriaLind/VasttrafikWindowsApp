using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VasttrafikWindows.Commands;
using VasttrafikWindows.Models;

namespace VasttrafikWindows.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly MainModel _mainModel;

    public MainViewModel()
    {
        _mainModel = new MainModel();
        GeografiStopPointsOutputCommand = new GeografiGetStopPointsCommand(_mainModel, this);
        PlaneraResaStopPointsOutputCommand = new PlaneraResaGetDeparturesCommand()
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

    public IRelayCommand GeografiStopPointsOutputCommand { get; set; }
    public IRelayCommand PlaneraResaStopPointsOutputCommand { get; set; }
}