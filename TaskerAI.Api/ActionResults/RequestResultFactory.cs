namespace TaskerAI.Api.ActionResults
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class RequestResultFactory : IRequestResultFactory
    {
        public IActionResult BadRequestFromInvalidModelState(ActionContext actionContext)
        {

            return new BadRequestObjectResult(new
            {
                ErrorCode = ErrorCodes.InvalidContract,
                ErrorMessages = actionContext.ModelState.Where(m => m.Value.ValidationState == ModelValidationState.Invalid).Select
                (
                    m => new { m.Key, Messages = m.Value.Errors.Select(e => e.ErrorMessage) }
                )
            });
        }
    }
}
