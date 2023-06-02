using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Avalonia.Themes.Fluent;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApp.ViewModels;

public partial class MainWindowViewModel : ObservableValidator
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ChangeThemeCommand))]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    [NotifyDataErrorInfo]
    [Required]
    [MaxLength(30, ErrorMessage = "The First Name length should be less than 30")]
    [Display(Name = "First Name")]
    private string? _firstName;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ChangeThemeCommand))]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    [NotifyDataErrorInfo]
    [Required]
    [MaxLength(30, ErrorMessage = "The Last Name length should be less than 30")]
    [Display(Name = "Last Name")]
    private string? _lastName;

    [ObservableProperty]
    private FluentThemeMode _themeMode;

    public string Greeting
    {
        get
        {
            return this.IsCorrectInput()
                       ? $"Welcome to Avalonia, {this.FirstName} {this.LastName}!"
                       : "Welcome to Avalonia!";
        }
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
        this.ValidateAllProperties();
        return !this.HasErrors;
    }
}
