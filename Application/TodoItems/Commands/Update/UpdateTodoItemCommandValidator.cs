using Application.Common;
using Application.TodoItems.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Commands.Edit
{
    public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoItemCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(v => v.Id)
                .GreaterThanOrEqualTo(1).WithMessage("Id required");

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
            if (_context.TodoLists.FirstOrDefault(x => x.Id == listId) == null)
                return false;
            else
                return true;
        }
    }
}
