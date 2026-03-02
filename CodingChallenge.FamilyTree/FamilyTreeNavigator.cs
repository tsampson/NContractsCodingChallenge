namespace CodingChallenge.FamilyTree;

public class FamilyTreeNavigator
{
    public string GetBirthMonth(Person person, string descendantName)
    {
        return GetBirthMonthRecursive(person, descendantName);
    }
    
    private string GetBirthMonthRecursive(Person person, string descendantName)
    {
        // Base case: if the current person's name matches the descendant's name
        if (person.Name.Equals(descendantName, StringComparison.OrdinalIgnoreCase))
        {
            // Return the birth month from the person's birthday
            return person.Birthday.ToString("MMMM"); // Returns the full month name
        }

        // Recursive case: search in the children
        foreach (var child in person.Children)
        {
            var result = GetBirthMonthRecursive(child, descendantName);
            if (!string.IsNullOrEmpty(result))
            {
                return result; // Return the found birth month
            }
        }

        // If not found, return an empty string
        return string.Empty;
    }
}