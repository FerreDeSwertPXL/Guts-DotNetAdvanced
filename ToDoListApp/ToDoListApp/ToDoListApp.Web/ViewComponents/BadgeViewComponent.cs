using Microsoft.AspNetCore.Mvc;
using ToDoListApp.AppLogic;

namespace ToDoListApp.Web.ViewComponents
{
    public class BadgeViewComponent : ViewComponent
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public BadgeViewComponent(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public IViewComponentResult Invoke()
        {
            var count = _toDoItemRepository.GetTotalOfItemsThatAreNotDone();
            return View(count);
        }
    }
}
