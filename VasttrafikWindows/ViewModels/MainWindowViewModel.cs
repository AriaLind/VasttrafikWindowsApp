using CommunityToolkit.Mvvm.ComponentModel;

namespace VasttrafikWindows.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    public ObservableObject CurrentViewModel { get; set; }

    public MainWindowViewModel(ObservableObject currentViewModel)
    {
        CurrentViewModel = currentViewModel;
    }
}