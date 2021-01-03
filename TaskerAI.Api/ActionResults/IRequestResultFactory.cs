namespace TaskerAI.Api.ActionResults
{
    using Microsoft.AspNetCore.Mvc;

    public interface IRequestResultFactory
    {
        IActionResult BadRequestFromInvalidModelState(ActionContext actionContext);
    }
}