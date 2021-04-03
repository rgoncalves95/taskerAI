namespace TaskerAI.Database.Entities
{
    public class TaskType
    {

        public string Name { get; set; }
        public double? Cost { get; set; }
        public int? Duration { get; set; }
        public int Id { get; set; }
        public bool IsNew => this.Id == default(int);
    }

}
