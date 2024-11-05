using McMotd.Enum;
using McMotd.Model;

namespace McMotd.MAUI.View;

public class McMotdView: ContentView {
    public double? FontSize { get; set; }
    public string? FontFamily { get; set; }
    private MotdComponents motd;
    public McMotdView(MotdComponents components) {
        motd = components;
        Initailize();
    }

    private StackLayout hStack;
    private StackLayout vStack;
    private void Initailize() {
        this.
        
        vStack = new StackLayout() { Orientation = StackOrientation.Vertical };
        hStack = new StackLayout() { Orientation = StackOrientation.Horizontal };
        foreach (var component in motd.Components) {
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