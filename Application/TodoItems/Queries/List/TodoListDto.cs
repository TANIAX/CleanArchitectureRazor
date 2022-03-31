﻿using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Queries.List
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
