namespace McMotd.Options;

public class MotdOption
{
    /// <summary>
    /// remove left and right white space
    /// <value>false</value>
    /// </summary>
    public bool Stripped { get; set; } = false;

    /// <summary>
    /// remove "\n", result will one line.
    /// <value>false</value>
    /// </summary>
    public bool LineBreak { get; set; } = true;
}