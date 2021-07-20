using System;
using System.ComponentModel.DataAnnotations;

namespace BookReadingEvents.Domain
{
    public class Invitee
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int InviteeId { get; set; }

        [Required]
        public string InviteeEmail { get; set; }
      
        [Required]
        public Guid EventId { get; set; }
    }
}
