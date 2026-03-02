namespace CodingChallenge.FamilyTree;

public class Person
{
    public Person() => Children = new List<Person>();

    public string Name { get; set; }
    public List<Person> Children { get; set; }
    public DateTime Birthday { get; set; }
}