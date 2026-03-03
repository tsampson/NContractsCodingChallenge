using System;
using FluentAssertions;
using NUnit.Framework;

namespace CodingChallenge.FamilyTree.Tests;

[TestFixture]
public class FamilyTreeNavigatorTests
{
    private static Person _root;

    [OneTimeSetUp]
    public static void OneTimeSetup()
    {
        _root = FamilyTreeGenerator.Make();
    }

    [TestCase(1)]
    [TestCase(33)]
    [TestCase(22)]
    public void GetBirthMonth_QueriesForDescendentAndReturnsBirthMonth(int index)
    {
        var result = new FamilyTreeNavigator().GetBirthMonth(_root, "Name" + index);
        var expectedMonth = DateTime.Now.AddDays(index - 1).ToString("MMMM");
        result.Should().Be(expectedMonth);
    }

    [Test]
    public void GetBirthMonth_QueriesForDescendentAndReturnsEmptyStringIfNotFound()
    {
        var result = new FamilyTreeNavigator().GetBirthMonth(_root, "Jeebus");
        result.Should().Be(result);
    }
}
