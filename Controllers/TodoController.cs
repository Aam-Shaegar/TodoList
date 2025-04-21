using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private static List<TodoItem> _todos = new List<TodoItem>();

        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok( _todos);
        }

        [HttpPost]
        public IActionResult CreateTodo([FromBody] TodoItemInput input)
        {
            var todoItem = new TodoItem
            {
                Id = _todos.Count + 1,
                Name = input.Name,
                IsDone = input.IsDone
            };
            _todos.Add(todoItem);
            return CreatedAtAction(nameof(GetTodos), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut]
        public IActionResult ChangeStatus(long ThisId, bool NewStatus)
        {
            var todoItem = _todos.FirstOrDefault(t => t.Id == ThisId);
            if (todoItem != null)
            {
                todoItem.IsDone = NewStatus;
                return Ok(todoItem);
            }
            else
            {
                return NotFound();

            }
        }
        [HttpDelete]
        public IActionResult DeleteTodo(int ThisId)
        {
            if (ThisId < _todos.Count)
            {
                _todos.RemoveAt(ThisId-1);
                return Ok(new { id = _todos.Count });
            }
            else return NotFound();
        }
    }
}