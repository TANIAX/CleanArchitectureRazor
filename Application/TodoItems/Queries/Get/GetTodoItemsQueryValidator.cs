using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Queries.Get
{
    public class GetTodoItemsQueryValidator : AbstractValidator<GetTodoItemsQuery>
    {
        public GetTodoItemsQueryValidator()
        {
            //RuleFor(x => x.ListId)
            //    .NotEmpty().WithMessage("ListId is required.");

            //RuleFor(x => x.PageNumber)
            //    .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            //RuleFor(x => x.PageSize)
            //    .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
