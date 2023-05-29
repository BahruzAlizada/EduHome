namespace EduHome.Models
{
    public class EventSpiker
    {
        public int Id { get;set; }
        public Event Event { get; set; }
        public int EventId { get; set; }
        public Spiker Spiker { get; set; }
        public int SpikerId { get; set; }
    }
}
