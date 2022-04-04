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

namespace Application.TodoLists.Queries.ListWithItems
{
    public class GetTodoListWithItemsQuery : IRequest<ICollection<TodoListWithItemsVm>>
    {

    }

    public class GetTodoListQueryHandler : IRequestHandler<GetTodoListWithItemsQuery, ICollection<TodoListWithItemsVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<TodoListWithItemsVm>> Handle(GetTodoListWithItemsQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoLists
                            .ProjectTo<TodoListWithItemsVm>(_mapper.ConfigurationProvider)
                            .OrderBy(x => x.Title)
                            .ToListAsync(cancellationToken);                       
        }
    }
}
