using LinqExamples.Models;

namespace LinqExamples
{
    public class SelectExamples
    {
        public IList<int> GetLengthOfWords(IEnumerable<string?> words)
        {
            return words.Select(w => w?.Length ?? 0).ToList();
        }

        public IList<AngleInfo> ConvertAnglesToAngleInfos(IEnumerable<double> anglesInDegrees)
        {
            //Tip: You can use Math.Cos and Math.Sin methods to calculate the cosinus and sinus of an angle.
            //     These methods expect the angle to be in radians.
            //     You can convert degrees to radians using this formula: radians = degrees * Math.PI / 180

            return anglesInDegrees.Select(deg =>
            {
                var rad = deg * Math.PI / 180;
                return new AngleInfo
                {
                    Angle = deg,
                    Cosinus = Math.Cos(rad),
                    Sinus = Math.Sin(rad)
                };
            })
        .ToList();

        }
    }
}