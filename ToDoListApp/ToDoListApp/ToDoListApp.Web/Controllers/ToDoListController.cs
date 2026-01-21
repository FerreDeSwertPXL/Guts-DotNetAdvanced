using Microsoft.AspNetCore.Mvc;
using ToDoListApp.AppLogic;
using ToDoListApp.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Web.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public IActionResult Search(ToDoListSearchViewModel viewModel)
        {
            if (Request.Query.ContainsKey("TitleFilter"))
            {
                viewModel.ToDoLists = _toDoListRepository.Find(viewModel.TitleFilter);
            }
            else
            {
                viewModel.ShowNoListsFoundMessage = true;
            }
            
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            var list = _toDoListRepository.GetById(id);
            if (list == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var vm = new ToDoListDetailViewModel(list);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Detail(ToDoListDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var list = _toDoListRepository.GetById(model.ListId);
                var vm = new ToDoListDetailViewModel(list);
                vm.NewItemDescription = model.NewItemDescription;
                return View(vm);
            }

            _toDoListRepository.AddItemToExistingList(model.ListId, model.NewItemDescription);
            ModelState.Clear();
            return RedirectToAction("Detail", new { id = model.ListId });
        }
    }
}

