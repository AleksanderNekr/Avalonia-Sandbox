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
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "This is a required field.")]
    [Display(Name = "First Name")]
    private string? _firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "This is a required field.")]
    [Display(Name = "Last Name")]
    private string? _lastName;

    public string Greeting
    {
        get
        {
            return !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName)
                       ? $"Welcome to Avalonia, {this.FirstName} {this.LastName}!"
                       : "Welcome to Avalonia!";
        }
    }

    [ObservableProperty]
    private ObservableCollection<Person> _people;

    [RelayCommand]
    private void Click()
    {
        this.ValidateAllProperties();
        if (this.HasErrors)
        {
            return;
        }

        this.People.Add(new Person { FirstName = this.FirstName, LastName = this.LastName });
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
