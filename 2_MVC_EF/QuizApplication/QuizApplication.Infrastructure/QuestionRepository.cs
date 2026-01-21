using Microsoft.EntityFrameworkCore;
using QuizApplication.AppLogic.Contracts;
using QuizApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Infrastructure
{
    internal class QuestionRepository : IQuestionRepository
    {
        private readonly QuizDbContext _context;
        public QuestionRepository(QuizDbContext dbContext)
        {
            _context = dbContext;
        }

        public IReadOnlyList<Question> GetByCategoryId(int categoryId)
        {
            return _context.Questions.Where(q =>  q.CategoryId == categoryId).ToList();
        }

        public Question GetByIdWithAnswers(int id)
        {
            return _context.Questions.Include(q => q.Answers).Single(q => q.Id == id);
        }
    }
}
