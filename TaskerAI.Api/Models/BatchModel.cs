namespace TaskerAI.Api.Models
{
    using Microsoft.AspNetCore.Http;

    public class BatchModel
    {
        public string Entity { get; set; }
        public IFormFile File { get; set; }
    }
}
