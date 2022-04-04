using Application.TodoItems.Commands.Create;
using Application.TodoItems.Commands.Delete;
using Application.TodoItems.Commands.Update;
using Application.TodoItems.Queries.Get;
using Application.TodoItems.Queries.List;
using Application.TodoLists.Commands.Create;
using Application.TodoLists.Commands.Delete;
using Application.TodoLists.Queries.GetTodos;
using Application.TodoLists.Queries.List;
using Application.TodoLists.Queries.ListWithItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class TodoController : BaseController
    {
        public TodoController(IMediator mediator) : base(mediator){}
        
        // GET: Todo
        public async Task<ActionResult> IndexAsync()
        {
            try
            {
                var response = await _mediator.Send(new GetTodosQuery());
                return View(response);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return View();
            }    
        }
        
        // GET: Todo/ListItem/5
        [Route("{controller}/ListItems/{id}")]
        public async Task<ActionResult> ListItems(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetTodoItemsQuery(id));
                return PartialView("_TodoItems", response);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return View();
            }
        }


        // GET: Todo/DeleteList/5
        [Route("{controller}/DeleteList/{id}")]
        public async Task<ActionResult> DeleteList(int id)
        {
            try
            {
                await _mediator.Send(new DeleteTodoListCommand(id));

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return View("Index");
            }

        }

        // GET: Todo/DeleteList/5
        [Route("{controller}/DeleteItem/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteTodoItemCommand(id));

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return View("Index");
            }

        }


        //// GET: Todo/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Todo/Create
        //public async Task<ActionResult> CreateAsync()
        //{
        //    var response = await _mediator.Send(new GetTodoListQuery());

        //    return View(response);
        //}

        //// POST: Todo/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateAsync(CreateTodoItemCommand command)
        //{
        //    await this.Send(command);
        //    return await this.CreateAsync();
        //}

        //// GET: Todo/Edit/5
        //public async Task<ActionResult> EditAsync(int id)
        //{
        //    var response = new EditTodoItemViewModel();

        //    //response.TodoItem = await this.Send(new GetTodoItemsQuery(id));
        //    response.TodoList = await this.Send(new GetTodoListQuery());

        //    return View(response);
        //}

        //// POST: Todo/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditAsync(int id, UpdateTodoItemCommand command)
        //{
        //    await this.Send(command);

        //    return await this.EditAsync(id);
        //}

        //// GET: Todo/Delete/5
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await this.Send(new DeleteTodoItemCommand(id));

        //    return RedirectToAction("Index");
        //}
    }
}
