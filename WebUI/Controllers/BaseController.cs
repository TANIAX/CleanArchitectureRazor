using Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator _mediator { get; }
        
        public BaseController(IMediator mediator) => _mediator = mediator;
        
        protected void HandleException(Exception exception)
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
                        TempData["Error." + error.Key] = specificErrors;
                    }
                }
                //The exception does not come from Validation exception
                else
                {
                    TempData["UnknownError"] = exception.Message;
                }
            }
        }        
  }
    public static class HttpRequestExtensions
    {
        private const string RequestedWithHeader = "X-Requested-With";
        private const string XmlHttpRequest = "XMLHttpRequest";

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Headers != null)
            {
                return request.Headers[RequestedWithHeader] == XmlHttpRequest;
            }

            return false;
        }
    }


