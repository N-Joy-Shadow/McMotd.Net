namespace McMotd.Data.Mc;

public class McColor {
    public static implicit operator McColor (string color) {
        return MotdData.ColorDict[color];
    }
}