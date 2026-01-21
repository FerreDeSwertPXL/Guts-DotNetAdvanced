using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Infrastructure
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly ToDoListContext _context;

        public ToDoListRepository(ToDoListContext context)
        {
            _context = context;
        }

        public void AddItemToExistingList(Guid listId, string itemDescription)
        {
            if (string.IsNullOrWhiteSpace(itemDescription))
            {
                throw new ArgumentException("Item description cannot be null or empty.", nameof(itemDescription));
            }

            var toDoList = _context.ToDoLists
                .Include(t => t.Items) // Zorg ervoor dat items geladen worden
                .FirstOrDefault(t => t.Id == listId);

            if (toDoList == null)
            {
                throw new KeyNotFoundException($"ToDoList with Id {listId} not found.");
            }

            var newItem = ToDoItem.CreateNew(itemDescription);
            toDoList.Items.Add(newItem);

            _context.SaveChanges();
        }

        public ToDoList AddNew(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }

            var newToDoList = ToDoList.CreateNew(title);
            _context.ToDoLists.Add(newToDoList);
            _context.SaveChanges();

            return newToDoList;
        }

        public IList<ToDoList> Find(string? titleFilter)
        {
            IQueryable<ToDoList> query = _context.ToDoLists.Include(t => t.Items);

            if (!string.IsNullOrWhiteSpace(titleFilter))
            {
                query = query.Where(t => EF.Functions.Like(t.Title, $"%{titleFilter}%"));
            }

            return query.ToList();
        }

        public ToDoList? GetById(Guid id)
        {
            return _context.ToDoLists
                .Include(t => t.Items) // Laad ook de bijbehorende items
                .FirstOrDefault(t => t.Id == id);
        }
    }
}
