using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Infrastructure
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly ToDoListContext _context;

        public ToDoItemRepository(ToDoListContext context)
        {
            _context = context;
        }

        public int GetTotalOfItemsThatAreNotDone()
        {
            return _context.Set<ToDoItem>().Count(item => !item.IsDone);
        }

        public ToDoItem Update(Guid id, bool isDone)
        {
            var item = _context.Set<ToDoItem>().FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException("ToDoItem not found.");
            }

            item.IsDone = isDone;

            _context.SaveChanges();

            return item; 
        }
    }
}
