using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public TodoListDto()
        {
            Items = new List<TodoItemDto>();
        }

        public int Id { get; set; }

        public string? Title { get; set; }

        public int NumberOfItems { get; set; }

        public IList<TodoItemDto> Items { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoList, TodoListDto>()
                .ForMember(d => d.NumberOfItems, opt => opt.MapFrom(s => s.Items.Count));
        }
    }
}