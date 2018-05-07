using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TodoListService.Interfaces;
using TodoListService.Models;

namespace TodoListService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TodoListController : Controller
    {
        private readonly ITodoItemRepository todoItemRepository;

        public TodoListController(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            var userName = (User.FindFirst(ClaimTypes.NameIdentifier))?.Value;

            return await todoItemRepository.GetUserItemsAsync(userName);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]TodoItem Todo)
        {
            var userName = (User.FindFirst(ClaimTypes.NameIdentifier))?.Value;

            await todoItemRepository.AddItemAsync(new TodoItem
            {
                Id = Guid.NewGuid().ToString(),
                Owner = userName,
                Title = Todo.Title
            });
        }
    }
}
