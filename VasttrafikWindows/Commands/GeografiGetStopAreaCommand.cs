using CommunityToolkit.Mvvm.Input;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Models;
using VasttrafikWindows.ViewModels;

namespace VasttrafikWindows.Commands;

public class GeografiGetStopAreaCommand : IRelayCommand
{
    private readonly PrimaryModel _primaryModel;
    private readonly PrimaryViewModel _primaryViewModel;

    public GeografiGetStopAreaCommand(PrimaryModel primaryModel, PrimaryViewModel primaryViewModel)
    {
        _primaryModel = primaryModel;
        _primaryViewModel = primaryViewModel;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public async void Execute(object? parameter)
    {
        var jsonResponse = await GeografiGetRequests.GeografiGetRequest(_primaryViewModel.GeografiEndPointInputString);
        var stopArea = Api.Deserializers.GeografiDeserializer.StopAreaDeserializer(jsonResponse);

        var uniqueStops = stopArea.stopAreas.DistinctBy(s => s.gid).OrderBy(s => s.name).ToList();

        var uniqueStopsString = string.Empty;

        foreach (var stop in uniqueStops)
        {
            uniqueStopsString += $"Name: {stop.name} gid: {stop.gid}\n";
        }

        _primaryViewModel.GeografiOutputString = uniqueStopsString;
    }

    public event EventHandler? CanExecuteChanged;
    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}