namespace TaskerAI.Api.Models
{
    public class TaskTypeModel
    {
        public int? Id { get; internal set; }
        public string Name { get; set; }
        public double? Cost { get; set; }
        public int? Duration { get; set; }
    }
}
