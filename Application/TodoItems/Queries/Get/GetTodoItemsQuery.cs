using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class GetTodoItemsQuery : IRequest<TodoItemVm>
    {
        public int Id { get; set; }

        public GetTodoItemsQuery(int id)
        {
            Id = id;
        }
    }

    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, TodoItemVm>
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

        public async Task<TodoItemVm> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
            .ProjectTo<TodoItemVm>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
