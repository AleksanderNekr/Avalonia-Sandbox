using Avalonia;
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

    public static string AgeLocalized => ViewModels.Resources.Age;
}
