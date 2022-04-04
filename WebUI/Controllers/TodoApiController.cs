using Application.TodoItems.Commands.Create;
using Application.TodoItems.Commands.Update;
using Application.TodoLists.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    [ApiController]
    public class TodoApiController : ApiBaseController
    {

        // POST api/Todo/CreateList
        [HttpPost]
        [Route("api/{controller}/CreateList")]
        public async Task<ActionResult<int>> CreateList(CreateTodoListCommand command)
        {
            return await Mediator.Send(command);
        }

        // POST api/Todo/CreateList
        [HttpPost]
        [Route("api/{controller}/UpdateItem")]
        public async Task<ActionResult<Unit>> UpdateItem(UpdateTodoItemCommand command)
        {
            return await Mediator.Send(command);
        }

        // POST api/Todo/CreateItem
        [HttpPost]
        [Route("api/{controller}/CreateItem")]
        public async Task<ActionResult<int>> CreateItem(CreateTodoItemCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
