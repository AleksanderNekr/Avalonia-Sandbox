using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApp.ViewModels;

public partial class MainWindowViewModel : ObservableValidator
{
    public MainWindowViewModel()
    {
        this.People = new();
        for (var i = 0; i < 10; i++)
        {
            this.People.Add(new Person
                            {
                                FirstName = Guid.NewGuid().ToString(),
                                LastName  = Guid.NewGuid().ToString(),
                            });
        }

        this.ValidateAllProperties();
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ClickCommand))]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "This is a required field.")]
    [Display(Name = "First Name")]
    private string? _firstName;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ClickCommand))]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "This is a required field.")]
    [Display(Name = "Last Name")]
    private string? _lastName;

    public string Greeting
    {
        get
        {
            return this.IsCorrectInput()
                       ? $"Welcome to Avalonia, {this.FirstName} {this.LastName}!"
                       : "Welcome to Avalonia!";
        }
    }

    [ObservableProperty]
    public ObservableCollection<Person> _people;

    [RelayCommand(CanExecute = nameof(IsCorrectInput))]
    private void Click()
    {
        this.People.Add(new Person { FirstName = "Qwe", LastName = "Rty" });
    }

    private bool IsCorrectInput()
    {
        return !this.HasErrors;
    }
}

public class Person
{
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Display(Name = "Age")]
    public int Age { get; set; } = 10;
}
