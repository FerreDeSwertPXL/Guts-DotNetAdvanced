using LinqExamples.Models;

namespace LinqExamples;

public class JoinExamples
{
    public int[] GetEvenNumbersOfIntersection(int[] firstList, int[] secondList)
    {
        return firstList.Intersect(secondList).Where(n => n % 2 == 0).ToArray() ;
    }

    public IList<string> MatchPersonsOnBirthMonth(IList<Person> group1, IList<Person> group2)
    {
        // TODO: join the two groups on the month of their birth date
        //       and return a list of strings formatted like this: "{person1.Name} and {person2.Name}"

        return group1.Join(group2, p1 => p1.BirthDate.Month, p2 => p2.BirthDate.Month, (p1, p2) => $"{p1.Name} and {p2.Name}" ).ToList() ;
    }
}