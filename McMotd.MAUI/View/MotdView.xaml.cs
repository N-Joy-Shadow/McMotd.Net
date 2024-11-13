using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McMotd;
using McMotd.Enum;


namespace McMotdParser.MAUI.View;

public partial class MotdView : ContentView {
    public static readonly BindableProperty MotdProperty =
        BindableProperty.Create(nameof(Motd), typeof(Motd), typeof(MotdView),null,propertyChanged: OnMotdChanged);

    public Motd Motd
    {
        get => (Motd)GetValue(MotdProperty);
        set => SetValue(MotdProperty, value);
    }

    // BindableProperty for FontSize
    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(double?), typeof(MotdView), 12.0);

    public double? FontSize
    {
        get => (double?)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    // BindableProperty for FontFamily
    public static readonly BindableProperty FontFamilyProperty =
        BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MotdView));

    public string? FontFamily
    {
        get => (string?)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }
    
    public MotdView() {
        InitializeComponent();
    }
    
    private static void OnMotdChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (MotdView)bindable;
        view.Initailize();
    }


    private void Initailize() {
        var hStack = new StackLayout() { Orientation = StackOrientation.Horizontal };
        foreach (var component in Motd.components.Components) {
            if (component.LineBreak) {
                vStack.Children.Add(hStack);
                hStack = new StackLayout() { Orientation = StackOrientation.Horizontal };
            }

            var label = new Label();
            label.FontSize = FontSize ?? 12;
            label.Text = component.Text;
            label.TextColor = Color.FromArgb(component.Color);
            foreach (var format in component.TextFormatting) {
                label = this.ResolveTextFormat(label,format);
            }
            hStack.Children.Add(label);
        }
        vStack.Children.Add(hStack);
    }

    
    private Label ResolveTextFormat(Label label, MotdTextFormat formaat) {
        if (formaat == MotdTextFormat.Bold)
            label.FontAttributes = FontAttributes.Bold;
        if (formaat == MotdTextFormat.Italic)
            label.FontAttributes = FontAttributes.Italic;
        if (formaat == MotdTextFormat.Underline)
            label.TextDecorations = TextDecorations.Underline;
        if (formaat == MotdTextFormat.Striktethrough)
            label.TextDecorations = TextDecorations.Strikethrough;

        return label;
    } 
}