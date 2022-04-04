namespace Application.TodoItems.Queries.Get
{
    public class TodoItemsVm
    {
        public int ListId { get; set; }
        public string ListTitle { get; set; }

        public List<TodoItemDto> Items { get; set; } = new List<TodoItemDto>();
    }
}