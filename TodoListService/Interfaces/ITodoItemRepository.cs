using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListService.Models;

namespace TodoListService.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetUserItemsAsync(string userName);
        Task AddItemAsync(TodoItem todoItem);
    }
}
