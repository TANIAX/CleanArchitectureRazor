using Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator _mediator { get; }
        
        public BaseController(IMediator mediator) => _mediator = mediator;

        protected void HandleException(Exception exception, string model = "")
        {
            string specificErrors;
            Type exceptionType = exception.GetType();

            //Display error from ValidationException object initialized in the application
            if (exceptionType == typeof(ValidationException))
            {
                //Cast exception to Validation exception
                var validationException = new ValidationException();
                validationException = (ValidationException)exception;

                //Clear errors
                foreach (var modelValue in ModelState.Values)
                {
                    modelValue.Errors.Clear();
                }

                //Display our custom error from validation class
                foreach (var error in validationException.Errors)
                {
                    specificErrors = "";

                    foreach (var errorValue in error.Value)
                    {
                        if (specificErrors != String.Empty)
                            specificErrors += Environment.NewLine;

                        specificErrors += errorValue;
                    }
                    ModelState.AddModelError("error." + error.Key, specificErrors);
                }
            }
            //The exception does not come from Validation exception
            else
            {
                ModelState.AddModelError(String.Empty, exception.Message);
            }
        }
    }
}

