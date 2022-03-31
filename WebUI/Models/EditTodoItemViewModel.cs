using Application.TodoItems.Queries.Get;
using Application.TodoItems.Queries.List;
using Application.TodoLists.Queries.List;

namespace WebUI.Models
{
    public class EditTodoItemViewModel
    {
        public TodoItemVm TodoItem { get; set; }
        public ICollection<TodoListVm> TodoList { get; set; }
    }
}
