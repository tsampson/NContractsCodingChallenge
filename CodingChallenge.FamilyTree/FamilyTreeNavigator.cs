namespace CodingChallenge.FamilyTree;

public class FamilyTreeNavigator
{
    public string GetBirthMonth(Person person, string descendantName)
    {
        return BreadthFirstTraversal(person, descendantName);
    }

    private string BreadthFirstTraversal(Person person, string descendantName)
    {
        if (string.Equals(person.Name, descendantName, StringComparison.OrdinalIgnoreCase))
        {
            return person.Birthday.ToString("MMMM");
        }

        var childrenToProcess = person.Children as IEnumerable<Person>;
        var result = string.Empty;

        do
        {
            result = childrenToProcess.FirstOrDefault(x => string.Equals(x.Name, descendantName, StringComparison.OrdinalIgnoreCase))
                ?.Birthday.ToString("MMMM") ?? string.Empty;

            if (result != string.Empty)
            {
                break;
            }

            childrenToProcess = childrenToProcess.SelectMany(x => x.Children);

        } while (childrenToProcess.Any());

        return result;
    }
}