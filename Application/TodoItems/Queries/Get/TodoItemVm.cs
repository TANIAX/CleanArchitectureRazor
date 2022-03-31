using Application.Common.Mappings;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Queries.Get
{
    public class TodoItemVm : IMapFrom<TodoItem>
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public bool Done { get; set; }
        public PriorityLevel Priority { get; set; }
    }
}
