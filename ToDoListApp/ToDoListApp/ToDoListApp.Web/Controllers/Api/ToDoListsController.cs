using Microsoft.AspNetCore.Mvc;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;
using ToDoListApp.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Web.Controllers.Api
{
    [ApiController]
    [Route("api/todolists")]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoListsController(IToDoListRepository toDoListRepository, IToDoItemRepository toDoItemRepository)
        {
            _toDoListRepository = toDoListRepository;
            _toDoItemRepository = toDoItemRepository;
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var toDoList = _toDoListRepository.GetById(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return Ok(toDoList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddNewToDoListModel model)
        {
            var newList = _toDoListRepository.AddNew(model.Title);
            return CreatedAtAction(nameof(GetById), new { id = newList.Id }, newList);
        }

        [HttpPut("{listId:guid}/items/{itemId:guid}")]
        public IActionResult Put(Guid listId, Guid itemId, [FromBody] UpdateToDoItemModel model)
        {
            var item = _toDoItemRepository.Update(itemId, model.IsDone);
            return Ok(item);
        }
    }
}
