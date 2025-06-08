using Cashly.Communication.Responses;
using Cashly.Domain.Exceptions;
using Cashly.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cashly.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case CashflowException:
                    HandleProjectException(context);
                    break;
                case DomainExceptionValidation:
                    ThrowUnknownError(context);
                    break;
                default:
                    ThrowUnknownError(context);
                    break;

            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if(context.Exception is ErrorOnValidationException)
            {
                var ex = context.Exception as ErrorOnValidationException;
                var errorResponse = new ResponseErrorJson(ex!.Errors);

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
            if(context.Exception is DomainExceptionValidation)
            {
                var errorResponse = new ResponseErrorJson("Sorry, this data violates our business rules, please try again.");

                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                context.Result = new ObjectResult(errorResponse);
            }

        }

        private void ThrowUnknownError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson("An unexpected error occurred. Please try again later.");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(errorResponse);
        }
    }
}
