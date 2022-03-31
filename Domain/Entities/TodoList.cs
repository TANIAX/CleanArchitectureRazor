using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
