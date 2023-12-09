using CommunityToolkit.Mvvm.Input;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Models;
using VasttrafikWindows.ViewModels;

namespace VasttrafikWindows.Commands;

public class GeografiGetStopAreaCommand : IRelayCommand
{
    private readonly MainModel _mainModel;
    private readonly MainViewModel _mainViewModel;

    public GeografiGetStopAreaCommand(MainModel mainModel, MainViewModel mainViewModel)
    {
        _mainModel = mainModel;
        _mainViewModel = mainViewModel;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public async void Execute(object? parameter)
    {
        var jsonResponse = await GeografiGetRequests.GeografiGetRequest(_mainViewModel.GeografiEndPointInputString);
        var stopArea = Api.Deserializers.GeografiDeserializer.StopAreaDeserializer(jsonResponse);

        var uniqueStops = stopArea.stopAreas.DistinctBy(s => s.gid).OrderBy(s => s.name).ToList();

        var uniqueStopsString = string.Empty;

        foreach (var stop in uniqueStops)
        {
            uniqueStopsString += $"Name: {stop.name} gid: {stop.gid}\n";
        }

        _mainViewModel.GeografiOutputString = uniqueStopsString;
    }

    public event EventHandler? CanExecuteChanged;
    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}