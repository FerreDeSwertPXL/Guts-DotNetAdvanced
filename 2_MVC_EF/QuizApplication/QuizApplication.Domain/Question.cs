using System.ComponentModel.DataAnnotations;

namespace QuizApplication.Domain
{
    public class Question
    {
        public int Id { get; set; }


        /* Please leave this MaxLength attribute on the QuestionString property, 
         * the GUTS tests will fail if removed */
        [MaxLength(100)]
        public string QuestionString { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public IList<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
