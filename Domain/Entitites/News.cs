namespace Domain.Entitites
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public Guid TeamId { get; set; }

    }
}
