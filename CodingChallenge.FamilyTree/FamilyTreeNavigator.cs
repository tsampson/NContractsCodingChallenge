namespace CodingChallenge.FamilyTree;

public class FamilyTreeNavigator
{
    public string GetBirthMonth(Person person, string descendantName)
    {
        return BreadthFirstTraversalRecursion(person.Children, descendantName);
    }

    private string BreadthFirstTraversalRecursion(IEnumerable<Person> children, string descendantName)
    {
        if (!children.Any() || string.IsNullOrEmpty(descendantName))
        {
            return string.Empty;
        }

        var result = children.FirstOrDefault(x => string.Equals(x.Name, descendantName, StringComparison.OrdinalIgnoreCase))
            ?.Birthday.ToString("MMMM") ?? string.Empty;

        if (result == string.Empty)
        {
            result = BreadthFirstTraversalRecursion(children.SelectMany(x => x.Children), descendantName);
        }

        return result;
    }
}