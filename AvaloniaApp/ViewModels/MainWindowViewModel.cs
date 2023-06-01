using System.Threading.Tasks;
using Avalonia.Themes.Fluent;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApp.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ChangeThemeCommand))]
    private string? _input;

    [ObservableProperty]
    private FluentThemeMode _themeMode;

    public static string Greeting
    {
        get { return "Welcome to Avalonia!"; }
    }

    [RelayCommand(CanExecute = nameof(IsCorrectInput))]
    private async Task ChangeThemeAsync()
    {
        await Task.Run(() => this.ThemeMode = this.ThemeMode == FluentThemeMode.Light
                                                  ? FluentThemeMode.Dark
                                                  : FluentThemeMode.Light);
    }

    private bool IsCorrectInput()
    {
        return !string.IsNullOrEmpty(this.Input);
    }
}
