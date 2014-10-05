using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MVC_MyTimeTracker.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
