using System.Collections.Generic;
using ToDoListApp.Domain;

namespace ToDoListApp.Web.Models
{
    public class ToDoListSearchViewModel
    {
        public string? TitleFilter { get; set; }
        public IList<ToDoList> ToDoLists { get; set; } = new List<ToDoList>();
        public bool ShowNoListsFoundMessage { get; set; }
    }
}
