namespace BalloonFun.Console;

public class BalloonProgram
{
    private readonly IOutputWriter _output;
    private readonly Random _random;

    public BalloonProgram(IOutputWriter output)
    {
        _output = output;   
        _random = new Random();
    }

    public void Run()
    {
        var randomBalloons = new Balloon[5];
        for (int i = 0; i < randomBalloons.Length; i++)
        {
            randomBalloons[i] = _random.NextBalloon(100); //TODO: assign a random balloon with a maximum size of 100
        }
        WriteBalloons(randomBalloons);

        Balloon poppedBalloon = _random.NextBalloonFromArray(randomBalloons); //TODO: pick a random balloon from the array

        poppedBalloon.Baptize("Christian Baleoon");

        string nameToWrite = poppedBalloon.Name ?? "Anonymous"; //TODO: get the name of the balloon or use "Anonymous" if it has no name
        _output.Write($"Popped balloon '{nameToWrite}' of size '{poppedBalloon.Size}' and color '{poppedBalloon.Color}'");
    }

    private void WriteBalloons(Balloon[] balloons)
    {
        foreach (Balloon balloon in balloons)
        {
            _output.Write($"A balloon of size '{balloon.Size}' and color '{balloon.Color}'");
        }
    }
}