using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace EduHome.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime StartTime { get; set;}
        public DateTime EndTime { get; set; }
        public bool IsDeactive { get; set; }
        public EventDetail EventDetail { get; set; }
        public List<EventSpiker> EventSpikers { get; set; }
    }

    public class EventDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
    }
}
