using LinqExamples.Models;

namespace LinqExamples;

public class OrderByExamples
{
    public double[] SortAnglesFromBigToSmall(double[] angles)
    {
        return angles.OrderByDescending(a => a).ToArray()  ;
    }

    public IList<Person> SortPersonsFromYoungToOldAndThenOnNameAlphabetically(List<Person> persons)
    {
        return persons.OrderByDescending(p => p.BirthDate).OrderBy(p => p.Name).ToArray() ;
    }
}