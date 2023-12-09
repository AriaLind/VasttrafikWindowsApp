using CommunityToolkit.Mvvm.Input;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Models;
using VasttrafikWindows.ViewModels;

namespace VasttrafikWindows.Commands;

public class GeografiGetCommand : IRelayCommand
{
    private readonly MainModel _mainModel;
    private readonly MainViewModel _mainViewModel;

    public GeografiGetCommand(MainModel mainModel, MainViewModel mainViewModel)
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
        _mainViewModel.ApiOutputString = await GeografiGetRequests.GetStopPoints(_mainViewModel.EndPointInputString);
    }

    public event EventHandler? CanExecuteChanged;
    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}