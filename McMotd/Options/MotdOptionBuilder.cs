namespace McMotd.Options;

public class MotdOptionBuilder
{
    private MotdOption option;
    public MotdOptionBuilder()
    {
        option = new MotdOption();
    }

    public MotdOptionBuilder Stripped()
    {
        option.Stripped = true;
        return this;
    }

    public MotdOptionBuilder NoLineBreak()
    {
        option.LineBreak = true;
        return this;
    }
    
    
    public MotdOption build()
    {
        return option;
    }
}