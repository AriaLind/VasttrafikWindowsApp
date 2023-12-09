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
        ApiOutputCommand = new GeografiGetCommand(_mainModel, this);
    }


    public string EndPointInputString
    {
        get => _mainModel._apiEndPointString;
        set
        {
            SetProperty(ref _mainModel._apiEndPointString, value);
        }
    }

    public string ApiOutputString
    {
        get => _mainModel._apiOutPutString;
        set
        {
            SetProperty(ref _mainModel._apiOutPutString, value);
        }
    }

    public IRelayCommand ApiOutputCommand { get; set; }
}