using System;
using System.ComponentModel.DataAnnotations;

namespace BookReadingEvents.Domain
{
    public class Invitee
    {
        [Key]
        public int InviteeId { get; set; }

        [Required]
        public string InviteeEmail { get; set; }

        [Required]
        public Event Event { get; set; }

        [Required]
        public Guid EventId { get; set; }
    }
}
