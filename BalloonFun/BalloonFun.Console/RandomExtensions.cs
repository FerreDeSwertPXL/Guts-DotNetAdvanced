using System.Drawing;

namespace BalloonFun.Console;

public static class RandomExtensions
{
    public static Balloon NextBalloon(this Random random, int maxSize)
    {
        int size = random.Next(1, maxSize+1);
        Color color = GenerateRandomColor(random);

        return new Balloon(color, size);
    }

    public static Balloon NextBalloonFromArray(this Random random, Balloon[] balloons)
    {
        int index = random.Next(0, balloons.Length);
        return balloons[index];
    }

    private static Color GenerateRandomColor(Random random)
    {
        int red = random.Next(0, 256);
        int green = random.Next(0, 256);
        int blue = random.Next(0, 256);
        return Color.FromArgb(red, green, blue);
    }
}