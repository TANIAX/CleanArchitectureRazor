using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoLists.Queries.ListWithItems
{
    public class TodoListWithItemsVm : IMapFrom<TodoList>
    {
        public TodoListWithItemsVm()
        {
            Items = new List<TodoItemDto>();
        }

        public int Id { get; set; }

        public string? Title { get; set; }

        public IList<TodoItemDto> Items { get; set; }
    }
}
