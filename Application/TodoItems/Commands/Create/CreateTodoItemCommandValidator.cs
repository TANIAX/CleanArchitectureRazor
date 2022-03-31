using Application.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Commands.Create
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateTodoItemCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters")
                .NotEmpty().WithMessage("Title is required");

            RuleFor(v => v.ListId)
                .GreaterThanOrEqualTo(1)
                .Must(ListExist).WithMessage("List not found");

            RuleFor(v => v.Priority)
                .IsInEnum().WithMessage("Priority not found");
                
        }

        private bool ListExist(int listId)
        {
            if(_context.TodoLists.FirstOrDefault(x => x.Id == listId) == null)      
                return false;
            else
                return true;
        }
    }
}
