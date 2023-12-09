using CommunityToolkit.Mvvm.Input;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Models;
using VasttrafikWindows.ViewModels;

namespace VasttrafikWindows.Commands;

public class GeografiGetCommand : IRelayCommand
{
    private readonly MainModel _demoModel;
    private readonly MainViewModel _mainViewModel;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        return GeografiGetRequests.GetStopPoints();
    }

    public event EventHandler? CanExecuteChanged;
    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}