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

namespace Application.TodoLists.Queries.List
{
    public class GetTodoListQuery : IRequest<ICollection<TodoListVm>>
    {

    }

    public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, ICollection<TodoListVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<TodoListVm>> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoLists
                            .ProjectTo<TodoListVm>(_mapper.ConfigurationProvider)
                            .OrderBy(x => x.Title)
                            .ToListAsync(cancellationToken);                       
        }
    }
}
