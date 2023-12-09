using System.Text.Json;
using CommunityToolkit.Mvvm.Input;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Api.Deserializers;
using VasttrafikWindows.Models;
using VasttrafikWindows.ViewModels;

namespace VasttrafikWindows.Commands;

public class PlaneraResaGetDeparturesCommand : IRelayCommand
{
    private readonly MainModel _mainModel;
    private readonly MainViewModel _mainViewModel;

    public PlaneraResaGetDeparturesCommand(MainModel mainModel, MainViewModel mainViewModel)
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
        var jsonResponse = await PlaneraResaGetRequest.GetStopAreaDepartures(_mainViewModel.PlaneraResaEndPointInputString);
        var departures = PlaneraResaDeserialization.DeparturesDeserializer(jsonResponse);

        var timeAndLine = string.Empty;

        foreach (var departuresResult in departures.results)
        {
            timeAndLine += departuresResult.serviceJourney.line.name + " ";
            timeAndLine += departuresResult.serviceJourney.direction + " ";
            timeAndLine += departuresResult.estimatedOtherwisePlannedTime + "\n";
        }

        _mainViewModel.PlaneraResaOutputString = timeAndLine;
    }

    public event EventHandler? CanExecuteChanged;
    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
