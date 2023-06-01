using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaApp.ViewModels;
using AvaloniaApp.Views;

namespace AvaloniaApp;

public class App : Application
{
    private static MainWindowViewModel MainWindowVM { get; set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        MainWindowVM     = new MainWindowViewModel();
        this.DataContext = MainWindowVM;
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
                                 {
                                     DataContext = MainWindowVM
                                 };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
