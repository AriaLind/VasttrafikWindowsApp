using System.Windows;
using VasttrafikWindows.Models;
using VasttrafikWindows.ViewModels;

namespace VasttrafikWindows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            PrimaryModel primaryModel = new();
            PrimaryViewModel primaryViewModel = new(primaryModel);

            var mainWindow = new MainWindow() { DataContext = new MainWindowViewModel(primaryViewModel) };

            mainWindow.Show();
        }
    }

}
