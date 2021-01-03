namespace TaskerAI.ConfigurationOptions
{

    using Microsoft.Extensions.Options;
    using TaskerAI.Api.ActionResults;

    public class ApiBehaviorOptions : IConfigureOptions<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>
    {
        private readonly IRequestResultFactory _resultFactory;

        public ApiBehaviorOptions(IRequestResultFactory resultFactory) => this._resultFactory = resultFactory;

        public void Configure(Microsoft.AspNetCore.Mvc.ApiBehaviorOptions options)
            => options.InvalidModelStateResponseFactory = this._resultFactory.BadRequestFromInvalidModelState;
    }
}
