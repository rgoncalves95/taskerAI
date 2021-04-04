namespace TaskerAI.Infrastructure.Dto
{
    public class TaskDto
    {
        private LocationDto location;

        public string Name { get; set; }
        public string Type { get; set; }
        public LocationDto Location
        {
            get
            {
                if (this.location == null)
                {
                    this.location = new LocationDto();
                }
                return this.location;
            }

            set => this.location = value;
        }
        public string Date { get; set; }
        public string DueDate { get; set; }
        public string DurationInSeconds { get; set; }
        public string Notes { get; set; }
    }
}
