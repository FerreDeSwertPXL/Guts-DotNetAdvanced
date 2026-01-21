using LinqExamples.Models;

namespace LinqExamples;

public class WhereExamples
{
    public int[] FilterOutNumbersDivisibleByTen(int[] numbers)
    {
        return numbers.Where(n => n % 10 == 0).ToArray();
    }

    public IList<Person> FilterOutPersonsThatAreEighteenOrOlder(List<Person> persons)
    {
        DateTime date = DateTime.Now;
        return persons.Where(p => date.Year - p.BirthDate.Year >= 18).ToList();
    }

    public IList<Person> FilterOutPersonsBornInFebruaryInAYearDividableBy4(List<Person> persons)
    {
        return persons
    .Where(p => p.BirthDate.Month == 1)
    .Where(p => p.BirthDate.Year % 4 == 0)
    .ToList();
    }
}
