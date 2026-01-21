namespace ToDoListApp.Domain.Tests;

public class ToDoItemTests
{
    [Test]
    public void CreateNew_ValidDescription_ShouldReturnNewItem_ThatIsNotDone_AndWithIdAndDescription()
    {
        // Arrange
        var description = "Buy milk";

        // Act
        var result = ToDoItem.CreateNew(description);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Description, Is.EqualTo(description));
        Assert.That(result.Id, Is.Not.EqualTo(default(Guid)));
        Assert.That(result.IsDone, Is.False);
    }

    [TestCase(null, "description")]
    [TestCase("", "description")]
    public void CreateNew_DescriptionIsNullOrEmpty_ShouldThrowArgumentException(string? description, string expectedParamName)
    {
        // Act + Assert
        Assert.That(() => ToDoItem.CreateNew(description),
            Throws.TypeOf<ArgumentException>()
            .With.Matches<ArgumentException>(ex => ex.ParamName == expectedParamName));
    }
}