using BookReadingEvents.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookReadingEvents.Domain
{
    public class Event
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public Guid EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public EventType TypeOfEvent { get; set; }

        public int Duration { get; set; }

        public string OtherDetails { get; set; }

        public string Description { get; set; }
    }
}
