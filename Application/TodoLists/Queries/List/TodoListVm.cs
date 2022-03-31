using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoLists.Queries.List
{
    public class TodoListVm : IMapFrom<TodoList>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
