namespace ToDoListApp.Domain.Tests
{
    [TestFixture] // niet verplicht)
    public class ToDoListTests
    {

        [Test]
        public void CreateNew_ValidTitle_ShouldReturnNewListWithIdAndTitle()
        {
            var title = "My To-Do list";

            var result = ToDoList.CreateNew(title);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo(title));
            Assert.That(result.Id, Is.Not.EqualTo(default(Guid)));
        }

        [TestCase(null, "title")]
        [TestCase("", "title")]
        public void CreateNew_TitleIsNullOrEmpty_ShouldThrowArgumentException(string? title, string expectedParamName)
        {
            // Act + Assert
            Assert.That(() => ToDoList.CreateNew(title),
                Throws.TypeOf<ArgumentException>()
                .With.Matches<ArgumentException>(ex => ex.ParamName == expectedParamName));
        }
    }
}