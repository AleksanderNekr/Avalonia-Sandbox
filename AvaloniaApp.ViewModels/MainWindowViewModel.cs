using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApp.ViewModels;

public partial class MainWindowViewModel : ObservableValidator
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    [NotifyCanExecuteChangedFor(nameof(ClickCommand))]
    [NotifyDataErrorInfo]
    [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FieldRequired")]
    [Display(ResourceType = typeof(Resources), Name = "FirstName")]
    private string? _firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    [NotifyCanExecuteChangedFor(nameof(ClickCommand))]
    [NotifyDataErrorInfo]
    [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FieldRequired")]
    [Display(ResourceType = typeof(Resources), Name = "LastName")]
    private string? _lastName;

    [ObservableProperty]
    private ObservableCollection<Person> _people = new();

    public string Greeting
    {
        get
        {
            return this.ClickCommand.CanExecute(null)
                       ? string.Format(Resources.WelcomeUser, this.FirstName, this.LastName)
                       : Resources.Welcome;
        }
    }

    [RelayCommand(CanExecute = nameof(CanClick))]
    private void Click()
    {
        this.People.Add(new Person { FirstName = this.FirstName, LastName = this.LastName });
    }

    private bool CanClick()
    {
        return !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName);
    }
}

public class Person : ObservableObject
{
    [Display(ResourceType = typeof(Resources), Name = "FirstName")]
    public string? FirstName { get; set; }

    [Display(ResourceType = typeof(Resources), Name = "LastName")]
    public string? LastName { get; set; }

    [Display(ResourceType = typeof(Resources), Name = "Age")]
    public int Age { get; set; } = 10;

    public string AgeString
    {
        get { return string.Format(Resources.AgeFormat, this.Age); }
    }
}
