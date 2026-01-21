using System.Drawing;

namespace BalloonFun.Console;

public class Balloon
{
    public Color Color { get; }
    public int Size { get; set; }
    public string? Name { get; set; }

    public Balloon(Color color, int size)
    {
        Color = color;
        Size = size;
        Name = null;
    }

    /// <summary>
    /// Personalizes the balloon by giving it a name.
    /// </summary>
    public void ChangeName(string name)
    {
        Name = name;
    }
    public void Baptize(string name)
    {
        Name = name;
    }
}