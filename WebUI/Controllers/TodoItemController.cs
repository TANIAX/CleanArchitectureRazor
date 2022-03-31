using Application.TodoItems.Commands.Create;
using Application.TodoItems.Commands.Delete;
using Application.TodoItems.Commands.Update;
using Application.TodoItems.Queries.Get;
using Application.TodoItems.Queries.List;
using Application.TodoLists.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class TodoItemController : BaseController
    {
        public TodoItemController(IMediator mediator) : base(mediator){}
        // GET: TodoItem
        public async Task<ActionResult> IndexAsync()
        {
            var response = await _mediator.Send(new GetTodoItemListQuery());

            return View(response);
        }

        // GET: TodoItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoItem/Create
        public async Task<ActionResult> CreateAsync()
        {
            var response = await _mediator.Send(new GetTodoListQuery());
            
            return View(response);
        }

        // POST: TodoItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CreateTodoItemCommand command)
        {
            try
            {
                await _mediator.Send(command);

                return await this.CreateAsync();
            }
            catch(Exception ex)
            {
                HandleException(ex);

                return await this.CreateAsync();
            }

        }

        // GET: TodoItem/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var response = new EditTodoItemViewModel();

            response.TodoItem = await _mediator.Send(new GetTodoItemsQuery(id));
            response.TodoList = await _mediator.Send(new GetTodoListQuery());

            return View(response);
        }

        // POST: TodoItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, UpdateTodoItemCommand command)
        {
            await _mediator.Send(command);

            return await this.EditAsync(id);
        }

        // GET: TodoItem/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTodoItemCommand(id));

            return RedirectToAction("Index");
        }
    }
}
