namespace McMotd.Options;

public class MotdOption
{
    /// <summary>
    /// remove left and right white space
    /// default value: false 
    /// </summary>
    public bool Stripped { get; set; } = false;

    /// <summary>
    /// remove "\n", result will one line.
    /// default value: true
    /// </summary>
    public bool LineBreak { get; set; } = true;
}