using CommunityToolkit.Mvvm.Input;
using System.Windows.Media;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Api.DataModels.GeografiStopPoints;
using VasttrafikWindows.Models;
using VasttrafikWindows.ViewModels;
using Geometry = System.Windows.Media.Geometry;

namespace VasttrafikWindows.Commands;

public class GeografiGetStopPointsCommand : IRelayCommand
{
    private readonly MainModel _mainModel;
    private readonly MainViewModel _mainViewModel;

    public GeografiGetStopPointsCommand(MainModel mainModel, MainViewModel mainViewModel)
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
        var jsonResponse = await GeografiGetRequests.GetStopPoints(_mainViewModel.GeografiEndPointInputString);
        var stopPoint = Api.Deserializers.GeografiDeserializer.StopPointDeserializer(jsonResponse);

        var uniqueStops = stopPoint.stopPoints.DistinctBy(s => s.gid).OrderBy(s => s.name).ToList();

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