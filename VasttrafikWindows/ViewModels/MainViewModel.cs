using CommunityToolkit.Mvvm.ComponentModel;
using VasttrafikWindows.Models;

namespace VasttrafikWindows.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly MainModel _mainModel;

    public MainViewModel(MainModel mainModel)
    {
        _mainModel = mainModel;
    }

    public string EndPointInput { get; set; }
}