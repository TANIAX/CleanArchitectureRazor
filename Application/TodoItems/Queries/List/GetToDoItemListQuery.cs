using Application.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Queries.List
{
    public class GetTodoItemListQuery : IRequest<ICollection<TodoItemListVm>>
    {

    }

    public class GetTodoListQueryHandler : IRequestHandler<GetTodoItemListQuery, ICollection<TodoItemListVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<TodoItemListVm>> Handle(GetTodoItemListQuery request, CancellationToken cancellationToken)
        {
            var x =  await _context.TodoItems
                            .ProjectTo<TodoItemListVm>(_mapper.ConfigurationProvider)
                            .OrderBy(x => x.Title)
                            .ToListAsync(cancellationToken);   
            return x;
        }
    }
}
