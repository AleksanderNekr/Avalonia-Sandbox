using Avalonia.Controls;
using AvaloniaApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
        this.DataContext = App.Current.Services.GetService<MainWindowViewModel>();
    }

    public static string AgeLocalized
    {
        get { return ViewModels.Resources.Age; }
    }

    public static string AddPersonLocalized
    {
        get { return ViewModels.Resources.AddPerson; }
    }

    public static string FirstNameWatermarkLocalized
    {
        get { return ViewModels.Resources.FirstNameWatermark; }
    }

    public static string LastNameWatermarkLocalized
    {
        get { return ViewModels.Resources.LastNameWatermark; }
    }
}
