namespace TaskerAI.Api.ActionResults
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class RequestResultFactory : IRequestResultFactory
    {
        public IActionResult BadRequestFromInvalidModelState(ActionContext actionContext)
        {

            return new BadRequestObjectResult(new
            {
                ErrorCode = ErrorCodes.InvalidContract,
                ErrorMessages = actionContext.ModelState.Select
                (
                    m => new
                    {
                        m.Key,
                        Messages = m.Value.Errors.Select(e => e.ErrorMessage)
                    }
                )
            });
        }
    }
}
