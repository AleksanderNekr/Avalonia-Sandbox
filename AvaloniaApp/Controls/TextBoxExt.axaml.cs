using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace AvaloniaApp.Controls;

public partial class TextBoxExt : UserControl
{
    public static readonly StyledProperty<string> WatermarkProperty =
        AvaloniaProperty.Register<TextBoxExt, string>(nameof(Watermark));

    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<TextBoxExt, string>(nameof(Title));

    public static readonly StyledProperty<string> DescriptionProperty =
        AvaloniaProperty.Register<TextBoxExt, string>(nameof(Description));


    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<TextBoxExt, string>(nameof(Text), defaultBindingMode: BindingMode.TwoWay);

    public TextBoxExt()
    {
        this.InitializeComponent();
    }

    public string Watermark
    {
        get { return this.GetValue(WatermarkProperty); }
        set { this.SetValue(WatermarkProperty, value); }
    }

    public string Title
    {
        get { return this.GetValue(TitleProperty); }
        set { this.SetValue(TitleProperty, value); }
    }

    public string Description
    {
        get { return this.GetValue(DescriptionProperty); }
        set { this.SetValue(DescriptionProperty, value); }
    }

    public string? Text
    {
        get { return this.GetValue(TextProperty); }
        set { this.SetValue(TextProperty, value); }
    }
}
