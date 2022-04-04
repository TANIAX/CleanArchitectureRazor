using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Queries.Get
{
    public class GetTodoItemsQuery : IRequest<TodoItemsVm>
    {
        public int Id { get; set; }

        public GetTodoItemsQuery(int id)
        {
            Id = id;
        }
    }

    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, TodoItemsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetTodoItemsQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<TodoItemsVm> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            TodoItemsVm vm = new TodoItemsVm();
            TodoList list;
            
            vm.Items = await _context.TodoItems
            .Where(x => x.ListId == request.Id)
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

            list = await _context.TodoLists
                .FirstOrDefaultAsync(x => x.Id == request.Id);  

            if (list != null)
            {
                vm.ListTitle = list.Title;
                vm.ListId = list.Id;
            }


            return vm;
        }
    }
}
